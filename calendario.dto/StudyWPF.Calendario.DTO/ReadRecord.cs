using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public sealed class ReadRecord: Interfaces.ICalendarioDTO
    {
        public Occurence Related { get; set; }
        public string ByUser { get; set; }
        public DateTime When { get; set; }
        
    }
}
