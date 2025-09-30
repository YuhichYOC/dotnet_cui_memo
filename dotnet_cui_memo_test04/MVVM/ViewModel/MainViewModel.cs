using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

using ICommandImpl;
using MVVM.Model;

namespace MVVM.ViewModel
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private readonly MainModel model;

        private ObservableCollection<INotifyPropertyChanged> devices;

        public MainViewModel()
        {
            model = new();
            devices = [];
        }

        public ICommand ScanCommand => new VoidCommand(() => true, RetrieveDeviceInfo);

        public ObservableCollection<INotifyPropertyChanged> Devices => devices;

        private void RetrieveDeviceInfo()
        {
            model.RetrieveDeviceInfo();
            devices.Clear();
            model.GetDeviceInfo().Select(d => new DeviceViewModel(d.Item1, d.Item2, d.Item3, d.Item4)).ToList().ForEach(devices.Add);
            model.GetDisplayInfo().Select(d => new DisplayViewModel(d.Item1, d.Item2, d.Item3, d.Item4)).ToList().ForEach(devices.Add);
            model.GetEDIDDeviceInfo().Select(d => new EDIDViewModel(d.Item1, d.Item2, d.Item3, d.Item4)).ToList().ForEach(devices.Add);
            NotifyPropertyChanged(nameof(Devices));
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string name = @"") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion INotifyPropertyChanged
    }
}