using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Occurence
    {
        public Event Event { get; private set; }
        public OccurenceDate Date { get; private set; }
        public EventStatus Status { get; private set; }
    }
}
