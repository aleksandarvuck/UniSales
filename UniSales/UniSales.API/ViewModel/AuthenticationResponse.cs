using UniSales.API.Models;

namespace UniSales.API.ViewModel
{
    public class AuthenticationResponse
    {
        public bool IsAuthenticated { get; set; }
        public User User { get; set; }
    }
}