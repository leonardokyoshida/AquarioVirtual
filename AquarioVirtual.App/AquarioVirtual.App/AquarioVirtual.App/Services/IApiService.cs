using AquarioVirtual.App.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AquarioVirtual.App.Services
{
    public interface IApiService
    {
        Task<Artigo> GetArtigoByIdAsync(string Id);
        Task<List<Artigo>> GetArtigosAsync();
        Task<List<Artigo>> GetArtigosByFilterAsync(string filter);
        Task<bool> LoginAsync();
        Task LogoutAsync();
        Task<RetornoIRRF> GetSalary(string salary);
    }
}
