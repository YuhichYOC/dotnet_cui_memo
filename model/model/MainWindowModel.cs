using System.ComponentModel;
using System.Windows;

namespace model {
    public class MainWindowModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler? PropertyChanged;

        private string _input;

        private string _output;

        public string Input {
            set {
                if (_input.Equals(value)) {
                    return;
                }
                _input = value;
                Convert();
                NotifyPropertyChanged(nameof(Output));
            }
            get { return _input; }
        }

        public string Output { get { return _output; } }

        public MainWindowModel() {
            _input = string.Empty;
            _output = string.Empty;
        }

        private void Convert() {
            Func<long, DateTime> longToDate = (arg) => DateTimeOffset.FromUnixTimeSeconds(arg).DateTime + TimeSpan.FromHours(9);
            Func<DateTime, long> dateToLong = (arg) => (long)(arg.ToUniversalTime() - new DateTime(1970, 1, 1, 0, 0, 0)).TotalSeconds;
            if (long.TryParse(_input, out long lInput)) {
                _output = longToDate(lInput).ToString(@"yyyy/MM/dd HH:mm:ss");
            }
            else if (DateTime.TryParse(_input, out DateTime dInput)) {
                _output = dateToLong(dInput).ToString();
            }
            else {
                _output = string.Empty;
            }
        }

        private void NotifyPropertyChanged(string name) => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}