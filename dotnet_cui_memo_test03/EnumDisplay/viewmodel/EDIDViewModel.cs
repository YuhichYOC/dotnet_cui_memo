using System.ComponentModel;

using EnumDisplay.model;

namespace EnumDisplay.viewmodel
{
    public class EDIDViewModel : INotifyPropertyChanged
    {
        private readonly EDIDModel model;

        public EDIDViewModel(string sId, string tId, string tech, string rate) => model = new EDIDModel(sId, tId, tech, rate);

        public string SourceId => model.SourceId;

        public string TargetId => model.TargetId;

        public string OutputTechnology => model.OutputTechnology;

        public string RefreshRate => model.RefreshRate;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string name = @"") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion INotifyPropertyChanged
    }
}