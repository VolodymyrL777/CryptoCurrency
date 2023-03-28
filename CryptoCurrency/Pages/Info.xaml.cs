using System.Windows.Controls;

namespace CryptoCurrency.Pages
{
    public partial class Info : Page
    {
        public Info()
        {
            InitializeComponent();
        }

        public Info(object dataContext)
        {
            InitializeComponent();
            DataContext = dataContext;
        }
    }
}
