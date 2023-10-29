using System.ComponentModel;
using System.Windows;

namespace model {
    public class MainWindowModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string windowList;

        public string WindowList { get { return windowList; } }

        public MainWindowModel() {
            windowList = string.Empty;
        }

        public void FillWindowList() {
            windowList = string.Empty;
            foreach (var p in System.Diagnostics.Process.GetProcesses()) {
                if (string.IsNullOrEmpty(p.MainWindowTitle)) {
                    continue;
                }
                windowList += p.ProcessName + "\n";
            }
            NotifyPropertyChanged(nameof(WindowList));
        }

        private void NotifyPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}