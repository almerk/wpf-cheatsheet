using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Dates
{
    public sealed class ContinuousReccurenceDate: Date
    {
        public DateTime Start { get; private set; }
        public bool HasTime { get; private set; }
        public IReadOnlyCollection<string> ReccurenceRules { get; private set; }
        public DateTime End { get; private set; }
    }
}
