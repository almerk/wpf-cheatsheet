using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class ReadRecord: Utils.NotifyPropertyChangedObject
    {
        public Occurence Related { get; set; }
        public Subjects.User ByUser { get; set; }
        public DateTime When { get; set; }
    }
}
