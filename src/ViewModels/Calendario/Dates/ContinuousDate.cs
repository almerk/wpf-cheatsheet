using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Dates
{
    public class ContinuousDate:Date
    {
        public bool HasTime { get; private set; }
        public DateTime Start { get; private set; }
        public DateTime End { get; private set; }
    }
}
