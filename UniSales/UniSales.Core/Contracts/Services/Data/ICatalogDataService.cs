using System.Collections.Generic;
using System.Threading.Tasks;
using UniSales.Core.Models;

namespace UniSales.Core.Contracts.Services.Data
{
    public interface ICatalogDataService
    {
        Task<IEnumerable<Product>> GetAllProductsAsync();

        Task<IEnumerable<Product>> GetProductsOfTheWeekAsync();
    }
}