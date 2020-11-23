using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public sealed class CalendarType
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<string> Calendars { get; set; }
    }
}
