using System.Windows.Controls;

using MVVM.ViewModel;

namespace MVVM.View
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