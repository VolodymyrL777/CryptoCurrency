using System.Windows.Controls;

namespace CryptoCurrency.Pages
{
    public partial class Top : Page
    {
        public Top()
        {
            InitializeComponent();
        }        

        public Top(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
