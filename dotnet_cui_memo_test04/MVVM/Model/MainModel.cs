using System.ComponentModel;

using DisplayOperator;

namespace MVVM.Model
{
    public class MainModel : INotifyPropertyChanged
    {
        private readonly Operator op;

        private readonly EDIDOperator edidOp;

        public MainModel()
        {
            op = new();
            edidOp = new();
        }

        public void RetrieveDeviceInfo()
        {
            op.FetchDevices();
            op.FetchModes();
            edidOp.Fetch();
        }

        public List<Tuple<string, string, string, string>> GetDeviceInfo() => op.GetDeviceInfo();

        public List<Tuple<string, string, string, string>> GetDisplayInfo() => op.GetDisplayInfo();

        public List<Tuple<string, string, string, string>> GetEDIDDeviceInfo() => edidOp.GetDeviceInfo();

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string name = @"") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion INotifyPropertyChanged
    }
}