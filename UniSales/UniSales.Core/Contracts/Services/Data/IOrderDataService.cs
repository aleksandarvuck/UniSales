using System.Threading.Tasks;
using UniSales.Core.Models;

namespace UniSales.Core.Contracts.Services.Data
{
    public interface IOrderDataService
    {
        Task<Order> PlaceOrder(Order order);
    }
}