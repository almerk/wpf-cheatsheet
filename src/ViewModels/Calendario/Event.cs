using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Event : Utils.NotifyPropertyChangedObject
    {
        private string name;
        private string description = string.Empty;

        public string Id { get; private set; }
        public Calendar Calendar { get; private set; }
        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public ObservableCollection<Date> Dates { get; set; } = new ObservableCollection<Date>();
        public string Description { get => description; set { description = value; OnPropertyChanged(); } }
        public ObservableCollection<Subject> Related { get; set; } = new ObservableCollection<Subject>();
        public ObservableCollection<Comment> Comments { get; set; } = new ObservableCollection<Comment>();
    }
}
