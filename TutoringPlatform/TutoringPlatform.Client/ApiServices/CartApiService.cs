using Blazored.LocalStorage;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Shared.Models;
using TutoringPlatform.Shared.Responses;
using System.Text.Json;
using System.Text.Json.Serialization;
using TutoringPlatform.Shared.PrivateModels;
using System.Linq;
using TutoringPlatform.Client.PrivateInterfaces;

namespace TutoringPlatform.Client.ApiServices
{
    public class CartApiService : ICart
    {
        private static string SerializeObj(object modelObject) => JsonSerializer.Serialize(modelObject, JsonOptions());
        private static T DeserializeJsonString<T>(string jsonString) => JsonSerializer.Deserialize<T>(jsonString, JsonOptions())!;
        private static StringContent GenerateStringContent(string serializedObj) => new(serializedObj, System.Text.Encoding.UTF8, "application/json");
        private static IEnumerable<T> DeserializeJsonStringList<T>(string jsonString) => JsonSerializer.Deserialize<IEnumerable<T>>(jsonString, JsonOptions())!;
        private static JsonSerializerOptions JsonOptions()
        {
            return new JsonSerializerOptions
            {
                AllowTrailingCommas = true,
                PropertyNameCaseInsensitive = true,
                PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
                UnmappedMemberHandling = JsonUnmappedMemberHandling.Skip
            };
        }

        public Action? CartAction { get ; set; }
        public int CartCount { get; set; }
        public bool IsCartLoaderVisible { get; set; }
        
        private readonly HttpClient httpClient;

        private readonly ILocalStorageService localStorageService;

        private readonly ICourseService courseService;

        public CartApiService(HttpClient httpClient, ILocalStorageService localStorageService, ICourseService courseService)
        {
            this.httpClient = httpClient;
            this.localStorageService = localStorageService;
            this.courseService = courseService;
        }

        public async Task<ServiceResponse> AddToCart(Course course, int updQuantity = 1)
        {
            //throw new NotImplementedException();
            string message = string.Empty;
            var myCart = new List<StorageCart>();
            var getCartFromStorage = await GetCartFromLocalStorage();

            if (!string.IsNullOrEmpty(getCartFromStorage))
            {
                myCart = (List<StorageCart>)DeserializeJsonStringList<StorageCart>(getCartFromStorage);
                var checkIfAddedAlready = myCart.FirstOrDefault(c => c.CourseId == course.CourseId);
                if (checkIfAddedAlready is null)
                {
                    myCart.Add(new StorageCart() { CourseId = course.CourseId, Quantity = 1 });
                    message = "Course added to cart";
                }
                else
                {
                    message = "Course already added to cart";
                }
            }
            else
            {
                myCart.Add(new StorageCart() { CourseId = course.CourseId, Quantity = 1 });
                message = "Course added to cart";
            }
            await RemoveCartFromLocalStorage();
            await SetCartToLocalStorage(SerializeObj(myCart));
            await GetCartCount();
            return new ServiceResponse(true, message);
        }

        public async Task<ServiceResponse> DeleteCart(Order cart)
        {
            //throw new NotImplementedException();
            var myCart = DeserializeJsonStringList<StorageCart>(await GetCartFromLocalStorage());
            IList<StorageCart> myCartList = myCart.ToList();
            if (myCartList is null) return new ServiceResponse(false, "Course not found");

            myCartList.Remove(myCartList.FirstOrDefault(c => c.CourseId == cart.CourseId)!);
            await RemoveCartFromLocalStorage();
            await SetCartToLocalStorage(SerializeObj(myCartList));
            await GetCartCount();
            return new ServiceResponse(true, "Course removed successfully");
        }

        public async Task GetCartCount()
        {
            //throw new NotImplementedException();
            string cartString = await GetCartFromLocalStorage();
            if (string.IsNullOrEmpty(cartString))
            {
                CartCount = 0;
            }
            else
            {
                CartCount = DeserializeJsonStringList<StorageCart>(cartString).Count();
            }
            CartAction?.Invoke();
        }

        public async Task<List<Order>> MyOrders(string userId)
        {
            //throw new NotImplementedException();
            IsCartLoaderVisible = true;
            var cartList = new List<Order>();
            string myCartString = await GetCartFromLocalStorage();
            if (string.IsNullOrEmpty(myCartString)) return null;

            var myCartList = DeserializeJsonStringList<StorageCart>(myCartString);
            var publishedCoursesEn = await courseService.GetPublishedCoursesAsync();
            var publishedCourses = publishedCoursesEn.ToList();
            foreach (var cartItem in myCartList)
            {
                var course = publishedCourses.FirstOrDefault(c => c.CourseId == cartItem.CourseId);
                cartList.Add(new Order()
                {
                    CourseId = course.CourseId,
                    UserId = userId,
                    Name = course.Title,
                    Quantity = cartItem.Quantity,
                    Price = course.Price,
                    Image = course.ImageUrl
                });
            }
            IsCartLoaderVisible = false;
            await GetCartCount();
            return cartList;
        }

        public async Task<string> Checkout(List<Order> cartItems)
        {
            var response = await httpClient.PostAsync("api/Payment/Checkout", GenerateStringContent(SerializeObj(cartItems)));

            var url = await response.Content.ReadAsStringAsync();
            return url;
        }

        private async Task<string> GetCartFromLocalStorage() => await localStorageService.GetItemAsStringAsync("cart");
        private async Task SetCartToLocalStorage(string cart) => await localStorageService.SetItemAsStringAsync("cart", cart);
        private async Task RemoveCartFromLocalStorage() => await localStorageService.RemoveItemAsync("cart");
    }
}
