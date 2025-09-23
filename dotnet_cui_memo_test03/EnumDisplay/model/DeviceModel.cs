using System.ComponentModel;

namespace EnumDisplay.model
{
    public class DeviceModel : INotifyPropertyChanged
    {
        private readonly string deviceName;
        private readonly string deviceString;
        private readonly string deviceID;
        private readonly string stateFlags;

        public DeviceModel(string name, string str, string id, string flags)
        {
            deviceName = name;
            deviceString = str;
            deviceID = id;
            stateFlags = flags;
        }

        public string DeviceName => deviceName;

        public string DeviceString => deviceString;

        public string DeviceID => deviceID;

        public string StateFlags => stateFlags;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string name = @"") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion INotifyPropertyChanged
    }
}