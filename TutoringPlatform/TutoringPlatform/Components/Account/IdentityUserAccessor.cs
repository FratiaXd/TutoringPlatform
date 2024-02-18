using TutoringPlatform.Data;
using Microsoft.AspNetCore.Identity;
using TutoringPlatform.Shared.Models;

namespace TutoringPlatform.Components.Account
{
    internal sealed class IdentityUserAccessor(UserManager<TutoringPlatformUser> userManager, IdentityRedirectManager redirectManager)
    {
        public async Task<TutoringPlatformUser> GetRequiredUserAsync(HttpContext context)
        {
            var user = await userManager.GetUserAsync(context.User);

            if (user is null)
            {
                redirectManager.RedirectToWithStatus("Account/InvalidUser", $"Error: Unable to load user with ID '{userManager.GetUserId(context.User)}'.", context);
            }

            return user;
        }
    }
}
