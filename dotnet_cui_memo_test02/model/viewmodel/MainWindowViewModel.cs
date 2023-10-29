using ICommandImpl;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace model {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        private MainWindowModel model;

        public ICommand ListOpenedWindowsCommand { get; }

        public string WindowList { get { return model.WindowList; } }

        public MainWindowViewModel() {
            model = new MainWindowModel();
            ListOpenedWindowsCommand = new ListWindowsCommand(CanExecuteFillWindowList, ExecuteFillWindowList);
            model.PropertyChanged += ModelPropertyChanged;
        }

        private bool CanExecuteFillWindowList() => true;

        private void ExecuteFillWindowList() => model.FillWindowList();

        private void ModelPropertyChanged(object? s, PropertyChangedEventArgs e) {
            NotifyPropertyChanged(nameof(WindowList));
        }

        private void NotifyPropertyChanged(string name = @"") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}