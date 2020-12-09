using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class OccurenceDate
    {
        public DateTime Value { get; private set; }
        public bool HasTime { get; private set; }
        public DateBelonging? Belonging { get; private set; }
    }
}
