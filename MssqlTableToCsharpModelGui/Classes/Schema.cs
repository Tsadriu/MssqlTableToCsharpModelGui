using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MssqlTableToCsharpModelGui.Classes
{
    public class Schema : INotifyPropertyChanged
    {
        private bool _isSelected;

        public string SchemaName { get; set; }

        public bool IsSelected
        {
            get { return _isSelected; }
            set
            {
                if (_isSelected != value)
                {
                    _isSelected = value;
                    OnPropertyChanged("IsSelected");

                    // Also update all the table check boxes.
                    foreach (var table in Tables)
                    {
                        table.IsSelected = _isSelected;
                    }
                }
            }
        }

        public ObservableCollection<Table> Tables { get; set; } = new ObservableCollection<Table>();

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
