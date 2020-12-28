using StudyWPF.Calendario.DTO.Interfaces;
using System;
using System.Reflection;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyWPF.Calendario.DTO.Utils;

namespace StudyWPF.Calendario.DTO.Client
{
    public class Context:Interfaces.IClientQueryRepository
    {

        public bool IsBuilt { get; internal set; } = false;
        /// <summary>
        /// Should be created by context builder service or with it's participation
        /// </summary>
        public Context() { }
        public virtual IReadOnlyCollection<Subjects.Group> Groups { get; set; } //aggregates users
        public virtual IReadOnlyCollection<Subjects.User> Users { get; set; }
        public virtual IReadOnlyCollection<Event> Events { get; set; } // aggregates groups, users and dates
        public virtual IReadOnlyCollection<Comment> Comments { get; set; }
        public virtual IReadOnlyCollection<ReadRecord> ReadRecords { get; set; }
        public virtual IReadOnlyCollection<Calendar> Calendars { get; set; } //aggregates groups and users
        public virtual IReadOnlyCollection<CalendarType> CalendarTypes { get; set; }
        public virtual IReadOnlyCollection<Date> Dates { get; set; }
        public virtual IReadOnlyCollection<Occurence> Occurences { get; set; }

        public Task<IReadOnlyCollection<T>> Get<T>() where T : ICalendarioDTO
        {
            return Task.Run(()=> 
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
                return (IReadOnlyCollection<T>)((IReadOnlyCollection<ICalendarioDTO>)value).OfType<T>().ToList();
            });
        }

        public async Task<T> GetById<T>(string id) where T : IHaveId
        {
            return await this.GetByIdFromCollection<T>(id);
        }
    }
}
