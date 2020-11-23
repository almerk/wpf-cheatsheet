using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.DevelopOnly
{
#if DEBUG
    public class Context
    {
        public IEnumerable<Subjects.Group> Groups { get; internal set; }
        public IEnumerable<Subjects.User> Users { get; internal set; }
        public IEnumerable<Event> Events { get; internal set; }
        public IEnumerable<Comment> Comments { get; internal set; }
        public IEnumerable<ReadRecord> ReadRecords { get; internal set; }
        public IEnumerable<Calendar> Calendars { get; internal set; }
        public IEnumerable<CalendarType> CalendarTypes { get; internal set; }
    }
#endif
}
