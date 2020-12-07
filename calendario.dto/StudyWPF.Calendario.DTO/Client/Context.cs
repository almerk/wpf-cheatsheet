using StudyWPF.Calendario.DTO.Interfaces;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Client
{
    public class Context:Interfaces.IClientRepository
    {
        /// <summary>
        /// Should be created by context builder service or with it's participation
        /// </summary>
        public Context() { }
        public IReadOnlyCollection<Subjects.Group> Groups { get; internal set; } //aggregates users
        public IReadOnlyCollection<Subjects.User> Users { get; internal set; }
        public IReadOnlyCollection<Event> Events { get; internal set; } // aggregates groups, users and dates
        public IReadOnlyCollection<Comment> Comments { get; internal set; }
        public IReadOnlyCollection<ReadRecord> ReadRecords { get; internal set; }
        public IReadOnlyCollection<Calendar> Calendars { get; internal set; } //aggregates groups and users
        public IReadOnlyCollection<CalendarType> CalendarTypes { get; internal set; }
        public IReadOnlyCollection<Date> Dates { get; internal set; }
        public IReadOnlyCollection<Occurence> Occurences { get; internal set; }

        public IReadOnlyCollection<T> Get<T>() where T : ICalendarioDTO
        {
            var prop = (from p in this.GetType().GetProperties()
                        where p.PropertyType.IsGenericType
                        let type = p.PropertyType.GetGenericArguments()[0]
                        where type == typeof(T) || type.IsAssignableFrom(typeof(T))
                        select p).FirstOrDefault();
            if (prop == null) 
                return null;
            var value = prop.GetValue(this, null);
            if (value == null)
                return null;
            return ((IReadOnlyCollection<ICalendarioDTO>)value).OfType<T>().ToList();
            

        }
    }
}
