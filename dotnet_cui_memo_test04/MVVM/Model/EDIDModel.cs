using System.ComponentModel;

namespace MVVM.Model
{
    public class EDIDModel : INotifyPropertyChanged
    {
        private readonly string sourceId;
        private readonly string targetId;
        private readonly string outputTechnology;
        private readonly string refreshRate;

        public EDIDModel(string sId, string tId, string tech, string rate)
        {
            sourceId = sId;
            targetId = tId;
            outputTechnology = tech;
            refreshRate = rate;
        }

        public string SourceId => sourceId;

        public string TargetId => targetId;

        public string OutputTechnology => outputTechnology;

        public string RefreshRate => refreshRate;

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string name = @"") => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        #endregion INotifyPropertyChanged
    }
}