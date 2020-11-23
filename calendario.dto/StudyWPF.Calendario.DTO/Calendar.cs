using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public sealed class Calendar
    {
        public string Id { get; set; }
        public string CalendarType { get; set; }
        public string Name { get; set; }
        public Subject Owner { get; set; }
        public IEnumerable<Subject> Related { get; set; }
        public IEnumerable<string> Events { get; set; }
    }
}
