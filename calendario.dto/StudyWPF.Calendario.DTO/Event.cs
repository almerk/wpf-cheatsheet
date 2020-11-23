using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public class Event:Interfaces.IInheritable
    {
        public string Id { get; set; }
        public string OfType => GetType().Name;
        public string CalendarId { get; set; }
        public string Name { get; set; }
        public IEnumerable<Date> Dates { get; set; }
        public bool HasTime { get; set; }
        public string Description { get; set; }
        public IEnumerable<Subject> Related { get; set; }
        public IEnumerable<string> Comments { get; set; }
        public IEnumerable<string> ReadRecords { get; set; }
        
    }
}
