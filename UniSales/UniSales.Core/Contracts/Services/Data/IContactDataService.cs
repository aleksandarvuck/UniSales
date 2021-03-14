using System.Threading.Tasks;
using UniSales.Core.Models;

namespace UniSales.Core.Contracts.Services.Data
{
    public interface IContactDataService
    {
        Task<ContactInfo> AddContactInfo(ContactInfo contactInfo);
    }
}