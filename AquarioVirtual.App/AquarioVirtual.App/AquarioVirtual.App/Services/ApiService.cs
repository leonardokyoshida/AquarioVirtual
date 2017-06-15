
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;
using AquarioVirtual.App.Models;
using Microsoft.WindowsAzure.MobileServices;
using AquarioVirtual.App.Helpers;
using AquarioVirtual.App.Authentication;

[assembly: Dependency(typeof(AquarioVirtual.App.Services.ApiService))]
namespace AquarioVirtual.App.Services
{
    public class ApiService : IApiService
    {
       
        public MobileServiceClient Client { get; set; } = null;
        List<AppServiceIdentity> identities = null;

        public async Task<List<Artigo>> GetArtigosAsync()
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{Constants.BaseUrl}ObterUltimosArtigos").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Artigo>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<Artigo> GetArtigoByIdAsync(string Id)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{Constants.BaseUrl}ObterArtigo/?idArtigo={Id}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<Artigo>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<List<Artigo>> GetArtigosByFilterAsync(string filter)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{Constants.BaseUrl}PesquisarArtigo/?filter={Uri.EscapeUriString(filter)}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<List<Artigo>>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }

        public async Task<bool> LoginAsync()
        {
            Initialize();
            var auth = DependencyService.Get<IAuthentication>();
            var user = await auth.LoginAsync(Client, MobileServiceAuthenticationProvider.Facebook);

            if (user == null)
            {
                Settings.AuthToken = string.Empty;
                Settings.UserId = string.Empty;

                Device.BeginInvokeOnMainThread(async () =>
                {
                    await App.Current.MainPage.DisplayAlert("Ops!", "Não conseguimos efetuar o seu login, tente novamente", "Ok");
                });

                return false;
            }

            else
            {
                Settings.AuthToken = user.MobileServiceAuthenticationToken;
                Settings.UserId = user.UserId;

                identities = await Client.InvokeApiAsync<List<AppServiceIdentity>>("/.auth/me");
                var name = identities[0].UserClaims.Find(c => c.Type.Equals("http://schemas.xmlsoap.org/ws/2005/05/identity/claims/givenname")).Value;

                var userToken = identities[0].AccessToken;

                var requestUrl = $"https://graph.facebook.com/v2.9/me/?fields=picture&access_token={userToken}";

                var userJson = await new HttpClient().GetStringAsync(requestUrl);

                var facebookProfile = JsonConvert.DeserializeObject<FacebookProfile>(userJson);

                Settings.Name = name;
                Settings.Image = facebookProfile.Picture.Data.Url;


            }
            return true;
        }



        public void Initialize()
        {
            Client = new MobileServiceClient(Constants.MobileAppUrl);

            if (!string.IsNullOrWhiteSpace(Settings.AuthToken) && !string.IsNullOrWhiteSpace(Settings.UserId))
            {
                Client.CurrentUser = new MobileServiceUser(Settings.UserId)
                {
                    MobileServiceAuthenticationToken = Settings.AuthToken
                };
            }
        }

        public async Task LogoutAsync()
        {
            Initialize();
            Settings.AuthToken = string.Empty;
            Settings.UserId = string.Empty;
            Settings.Image = string.Empty;
            Settings.Name = string.Empty;
            var auth = DependencyService.Get<IAuthentication>();
            await auth.LogoutAsync(Client);
        }

        public async Task<RetornoIRRF> GetSalary(string salary)
        {
            var httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            var response = await httpClient.GetAsync($"{Constants.LambdaUrl}/v1/IRRF/{Uri.EscapeUriString(salary)}").ConfigureAwait(false);

            if (response.IsSuccessStatusCode)
            {
                using (var responseStream = await response.Content.ReadAsStreamAsync().ConfigureAwait(false))
                {
                    return JsonConvert.DeserializeObject<RetornoIRRF>(
                        await new StreamReader(responseStream)
                            .ReadToEndAsync().ConfigureAwait(false));
                }
            }

            return null;
        }
    }
}
