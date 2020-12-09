using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public sealed class CalendarType : Interfaces.ICalendarioDTO, Interfaces.IHaveId
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Calendars { get; set; } = new string[] { };
    }
}
