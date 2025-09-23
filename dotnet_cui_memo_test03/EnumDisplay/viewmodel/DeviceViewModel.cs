using System.ComponentModel;

using EnumDisplay.model;

namespace EnumDisplay.viewmodel
{
    public class DeviceViewModel : INotifyPropertyChanged
    {
        private readonly DeviceModel model;

        public DeviceViewModel(string name, string str, string id, string flags) => model = new(name, str, id, flags);

        public string DeviceName => model.DeviceName;

        public string DeviceString => model.DeviceString;

        public string DeviceID => model.DeviceID;

        public string StateFlags => model.StateFlags;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string name = @"") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion INotifyPropertyChanged
    }
}