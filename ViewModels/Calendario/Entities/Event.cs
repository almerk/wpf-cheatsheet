using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Entities
{
    public class Event:Utils.Entity
    {
        public string Name { get; private set; }
        public DateTime Date { get; private set; }
        public bool HasTime { get; private set; }
        public string Description { get; set; }
        public EventStatus Status { get; set; }
        public ObservableCollection<Subject> Related { get; private set; }
        public ObservableCollection<Subject> Acceptors { get; private set; }
        public ObservableCollection<Subject> Perfomers { get; private set; }
        public ObservableCollection<Comment> Comments { get; private set; } 
        public ObservableCollection<ReadRecord> LastTimeRead { get; private set; }
    }
}
