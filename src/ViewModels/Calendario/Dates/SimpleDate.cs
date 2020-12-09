using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Dates
{
    public sealed class SimpleDate: Date
    {
        public DateTime Value { get; set; }
        public bool HasTime { get; set; }
    }
}
