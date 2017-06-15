using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Net.Http;
using System.Web.Mvc;

namespace AquarioVirtual.Web.Models
{
    public class Artigo
    {
        public string Id { get; set; }
        [AllowHtml]
        [Display( Name ="Artigo")]
        public string Texto { get; set; }
        public Categoria Categoria { get; set; }
        public DateTime DataPublicacao { get; set; }
        public IEnumerable<string> Fotos { get; set; }
        public Usuario Usuario { get; set; }
        public Peixe Peixe { get; set; }
        public string Status { get; set; }

        public static async System.Threading.Tasks.Task<List<Artigo>> Get(System.Net.Http.HttpClient api)
        {
            api.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            List<Artigo> artigos = null;
            System.Net.Http.HttpResponseMessage response = await api.GetAsync("http://aquariovirtual-aquariovirtualapi.azurewebsites.net/ObterUltimosArtigos").ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                artigos = await response.Content.ReadAsAsync<List<Artigo>>();
            }

            return artigos;

        }

        public static async System.Threading.Tasks.Task<Artigo> Save(System.Net.Http.HttpClient api, Artigo artigo )
        {
            var r = System.Web.HttpContext.Current.Request;
            var f = r.Files;

            api.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
           Artigo result = null;
            System.Net.Http.HttpResponseMessage response = await api.PostAsJsonAsync("http://aquariovirtual-aquariovirtualapi.azurewebsites.net/CadastrarArtigo", artigo).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Artigo>();
            }

            return result;

        }

        

    }
}