using AquarioVirtual.App.Authentication;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.MobileServices;
using Xamarin.Forms;
using AquarioVirtual.App.Helpers;
using AquarioVirtual.App.UWP.Authentication;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace AquarioVirtual.App.UWP.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
           MobileServiceAuthenticationProvider provider,
           IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(provider);

                Settings.AuthToken = user?.MobileServiceAuthenticationToken ?? string.Empty;
                Settings.UserId = user?.UserId;

                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LogoutAsync(MobileServiceClient client)
        {
           await client.LogoutAsync();
        }
    }
}
