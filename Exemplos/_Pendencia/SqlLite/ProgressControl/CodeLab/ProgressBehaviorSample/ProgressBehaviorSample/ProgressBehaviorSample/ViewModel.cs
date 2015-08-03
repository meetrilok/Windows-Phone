using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace ProgressBehaviorSample
{
    class ViewModel : INotifyPropertyChanged
    {
        private bool _loading;
        private double? _loadingValue;
        private double _lastValue;

        public ViewModel()
        {
            _lastValue = .5;
        }

        public double? LoadingValue
        {
            get { return _loadingValue; }
            set { _loadingValue = value; OnPropertyChanged(); }
        }

        private bool _determinate;

        public bool Determinate
        {
            get { return _determinate; }
            set
            {
                _determinate = value;
                if (value)
                {
                    LoadingValue = _lastValue;
                }
                else
                {
                    _lastValue = _loadingValue.Value;
                    LoadingValue = null;
                }
                OnPropertyChanged();
            }
        }

        public bool Loading
        {
            get { return _loading; }
            set { _loading = value; OnPropertyChanged(); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
