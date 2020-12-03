using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Client
{
    public class Context
    {
        internal Context() { }
        public IReadOnlyCollection<Subjects.Group> Groups { get; internal set; } //aggregates users
        public IReadOnlyCollection<Subjects.User> Users { get; internal set; } //before groups
        public IReadOnlyCollection<Event> Events { get; internal set; } // aggregates groups, users and dates
        public IReadOnlyCollection<Comment> Comments { get; internal set; }
        public IReadOnlyCollection<ReadRecord> ReadRecords { get; internal set; }
        public IReadOnlyCollection<Calendar> Calendars { get; internal set; } //aggregates groups and users
        public IReadOnlyCollection<CalendarType> CalendarTypes { get; internal set; }
        public IReadOnlyCollection<Date> Dates { get; internal set; } //before events
        public IReadOnlyCollection<Occurence> Occurences { get; internal set; }
    }
}
