using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Dates
{
    public sealed class ReccurenceDate: Date
    {
        public  DateTime Start { get; set; }
        public bool HasTime { get; set; }
        public IEnumerable<string> ReccurenceRules { get; set; }
    }
}
