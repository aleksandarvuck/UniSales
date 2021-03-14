using Akavache;
using System;
using System.Collections.Generic;
using System.Reactive.Linq;
using System.Threading.Tasks;
using UniSales.Core.Constants;
using UniSales.Core.Contracts.Repository;
using UniSales.Core.Contracts.Services.Data;
using UniSales.Core.Models;

namespace UniSales.Core.Services.Data
{
    public class CatalogDataService : BaseService, ICatalogDataService
    {
        private readonly IGenericRepository _genericRepository;

        public CatalogDataService(IGenericRepository genericRepository, IBlobCache cache = null) : base(cache)
        {
            _genericRepository = genericRepository;
        }

        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            List<Product> productsFromCache = await GetFromCache<List<Product>>(CacheNameConstants.AllProducts);

            if (productsFromCache != null)//loaded from cache
            {
                return productsFromCache;
            }
            else
            {
                UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
                {
                    Path = ApiConstants.CatalogEndpoint
                };

                var products = await _genericRepository.GetAsync<List<Product>>(builder.ToString());

                await Cache.InsertObject(CacheNameConstants.AllProducts, products, DateTimeOffset.Now.AddSeconds(20));

                return products;
            }
        }

        public async Task<IEnumerable<Product>> GetProductsOfTheWeekAsync()
        {
            List<Product> productsFromCache = await GetFromCache<List<Product>>(CacheNameConstants.ProductsOfTheWeek);

            if (productsFromCache != null)//loaded from cache
            {
                return productsFromCache;
            }

            UriBuilder builder = new UriBuilder(ApiConstants.BaseApiUrl)
            {
                Path = ApiConstants.ProductsOfTheWeekEndpoint
            };

            var products = await _genericRepository.GetAsync<List<Product>>(builder.ToString());

            await Cache.InsertObject(CacheNameConstants.ProductsOfTheWeek, products, DateTimeOffset.Now.AddSeconds(20));

            return products;
        }
    }
}