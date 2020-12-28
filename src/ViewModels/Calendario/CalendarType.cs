using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class CalendarType : Utils.NotifyPropertyChangedObject
    {
        private string name;
        public string Id { get; private set; }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public ObservableCollection<Calendar> Calendars { get; set; } = new ObservableCollection<Calendar>();
    }
}
