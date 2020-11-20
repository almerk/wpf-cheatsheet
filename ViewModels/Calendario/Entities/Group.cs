using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Entities
{
    public class Group: Subject
    {
        public ObservableCollection<Group> Groups { get; private set; }
        public ObservableCollection<User> Users  { get; private set; }
    }
}
