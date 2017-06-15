using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using AquarioVirtual.App.Droid.Authentication;
using AquarioVirtual.App.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using AquarioVirtual.App.Helpers;
using Android.Webkit;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace AquarioVirtual.App.Droid.Authentication
{

    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null)
        {
            try
            {
                var user = await client.LoginAsync(Forms.Context, provider);
                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task LogoutAsync(MobileServiceClient client)
        {
            CookieManager.Instance.RemoveAllCookie();
            await client.LogoutAsync();
        }
    }
}