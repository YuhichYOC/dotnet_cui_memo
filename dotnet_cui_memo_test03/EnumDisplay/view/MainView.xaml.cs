using System.Windows.Controls;

using EnumDisplay.viewmodel;

namespace EnumDisplay.view
{
    public partial class MainView : UserControl
    {
        public MainView()
        {
            InitializeComponent();

            DataContext = new MainViewModel();
        }
    }
}