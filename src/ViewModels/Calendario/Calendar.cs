using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Calendar : Utils.NotifyPropertyChangedObject
    {
        private string name;
        private Subject owner;
        public string Id { get; private set; }
        public CalendarType CalendarType { get; private set; }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public Subject Owner { get => owner; set { owner = value; OnPropertyChanged(); } }
        public ObservableCollection<Subject> Related { get; set; } = new ObservableCollection<Subject>();
        public ObservableCollection<Event> Events { get; set; } = new ObservableCollection<Event>();

    }
}
