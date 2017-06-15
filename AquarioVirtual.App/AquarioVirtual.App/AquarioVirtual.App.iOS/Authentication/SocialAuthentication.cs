using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AquarioVirtual.App.Authentication;
using Microsoft.WindowsAzure.MobileServices;
using System.Threading.Tasks;
using Xamarin.Forms;
using AquarioVirtual.App.Helpers;
using AquarioVirtual.App.iOS.Authentication;
using Foundation;
using System.Net.Http;

[assembly: Xamarin.Forms.Dependency(typeof(SocialAuthentication))]
namespace AquarioVirtual.App.iOS.Authentication
{
    public class SocialAuthentication : IAuthentication
    {
        public async Task<MobileServiceUser> LoginAsync(MobileServiceClient client,
            MobileServiceAuthenticationProvider provider,
            IDictionary<string, string> parameters = null)
        {
            try
            {
                var current = GetController();

#pragma warning disable CS1701 // Assuming assembly reference matches identity
                var user = await client.LoginAsync(current, provider);           
#pragma warning restore CS1701 // Assuming assembly reference matches identity

                

                return user;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public async Task LogoutAsync(MobileServiceClient client)
        {
            Settings.AuthToken = null;
            Settings.UserId = null;

            foreach (var cookie in NSHttpCookieStorage.SharedStorage.Cookies)
            {
                NSHttpCookieStorage.SharedStorage.DeleteCookie(cookie);
            }
            await client.LogoutAsync();
        }

        private UIKit.UIViewController GetController()
        {
            var window = UIKit.UIApplication.SharedApplication.KeyWindow;
            var root = window.RootViewController;

            if (root == null) return null;

            var current = root;
            while (current.PresentedViewController != null)
            {
                current = current.PresentedViewController;
            }
            return current;
        }

    }
}