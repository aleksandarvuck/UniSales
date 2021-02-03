using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace UniSales.Core.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class UniSalesNavigationPage
    {
        public UniSalesNavigationPage()
        {
            InitializeComponent();
        }

        public UniSalesNavigationPage(Page root) : base(root)
        {
            InitializeComponent();
        }
    }
}