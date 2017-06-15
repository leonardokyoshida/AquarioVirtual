using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Web;

namespace AquarioVirtual.Web.Models
{
    public class Usuario
    {
        public string Id { get; set; }
        [Display(Name ="Nome")]
        public string Nome { get; set; }
        [Display(Name ="Último nome")]
        public string UltimoNome { get; set; }
        [Required]
        [EmailAddress]
        [DataType(DataType.EmailAddress)]
        [Display(Name ="Email")]
        public string Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Senha { get; set; }
        public string Foto { get; set; }

        [Display(Name ="Lembrar-me?")]
        public bool LembreMe { get; set; }


        public static async System.Threading.Tasks.Task<Usuario> Autentica(System.Net.Http.HttpClient api, Usuario usuario)
        {
            api.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Usuario result = null;
            System.Net.Http.HttpResponseMessage response = await api.PostAsJsonAsync("http://aquariovirtual-aquariovirtualapi.azurewebsites.net/Autenticar", usuario).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Usuario>();
            }

            return result;
        }

        public static async System.Threading.Tasks.Task<Usuario> Registrar(System.Net.Http.HttpClient api, Usuario usuario)
        {
            api.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            Usuario result = null;
            System.Net.Http.HttpResponseMessage response = await api.PostAsJsonAsync("http://aquariovirtual-aquariovirtualapi.azurewebsites.net/RegistrarUsuario", usuario).ConfigureAwait(false);
            if (response.IsSuccessStatusCode)
            {
                result = await response.Content.ReadAsAsync<Usuario>();
            }

            return result;
        }
    }
}