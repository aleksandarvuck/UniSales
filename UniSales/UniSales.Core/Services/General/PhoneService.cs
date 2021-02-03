using Plugin.Messaging;
using UniSales.Core.Contracts.Services.General;

namespace UniSales.Core.Services.General
{
    public class PhoneService : IPhoneService
    {
        public void MakePhoneCall()
        {
            CrossMessaging.Current.PhoneDialer.MakePhoneCall("5554885002");
        }
    }
}