using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Dates
{
    public class ContinuousDate:Date
    {
        public bool HasTime { get; set; }
        public DateTime Start { get; set; }
        public DateTime End { get; set; }
    }
}
