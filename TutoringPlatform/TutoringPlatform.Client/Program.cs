using TutoringPlatform.Client;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using TutoringPlatform.Shared.Interfaces;
using TutoringPlatform.Client.ApiServices;
using Blazored.LocalStorage;
using TutoringPlatform.Client.PrivateInterfaces;

var builder = WebAssemblyHostBuilder.CreateDefault(args);

builder.Services.AddScoped(http => new HttpClient
{
    BaseAddress = new Uri(builder.HostEnvironment.BaseAddress),
});

builder.Services.AddAuthorizationCore();
builder.Services.AddCascadingAuthenticationState();
builder.Services.AddSingleton<AuthenticationStateProvider, PersistentAuthenticationStateProvider>();

builder.Services.AddScoped<ICourseService, CourseApiService>();
builder.Services.AddScoped<IEnrollmentService, EnrollmentApiService>();
builder.Services.AddScoped<ILessonProgressService, LessonProgressApiService>();
builder.Services.AddScoped<ILessonService, LessonApiService>();
builder.Services.AddScoped<IQuizService, QuizApiService>();
builder.Services.AddScoped<ICart, CartApiService>();
builder.Services.AddScoped<IOrderService, OrderApiService>();

builder.Services.AddBlazorBootstrap();
builder.Services.AddBlazoredLocalStorage();

await builder.Build().RunAsync();
