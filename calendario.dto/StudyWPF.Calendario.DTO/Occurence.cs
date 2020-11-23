using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public sealed class Occurence
    {
        public string EventId { get; set; }
        public OccurenceDate Date { get; set; }
        public EventStatus Status { get; set; }
    }
}
