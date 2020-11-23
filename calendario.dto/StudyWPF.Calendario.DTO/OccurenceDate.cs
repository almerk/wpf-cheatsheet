using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public class OccurenceDate
    {
        public DateTime Value { get; set; }
        public bool HasTime { get; set; }
        public DateBelonging? Belonging { get; set; }
    }
}
