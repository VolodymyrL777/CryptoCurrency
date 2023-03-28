using System.Windows.Controls;

namespace CryptoCurrency.Pages
{
    public partial class Chart : Page
    {
        public Chart()
        {
            InitializeComponent();
        }

        public Chart(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }   
    }
}
