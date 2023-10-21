namespace model {
    public class MainWindowViewModel {
        private MainWindowModel _model;

        public MainWindowModel Data { set { _model = value; } get { return _model; } }

        public MainWindowViewModel() => _model = new MainWindowModel();
    }
}