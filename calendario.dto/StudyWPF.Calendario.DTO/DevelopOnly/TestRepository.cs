using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyWPF.Calendario.DTO.Client;
using StudyWPF.Calendario.DTO.Interfaces;
using StudyWPF.Calendario.DTO.Utils;

namespace StudyWPF.Calendario.DTO.DevelopOnly
{
#if DEBUG
    public class TestRepository:Interfaces.IClientRepository
    {
        
        private Context _context = new TestContextBuilder()
            .Full()
            .Build();

        public IReadOnlyCollection<T> Get<T>() where T : ICalendarioDTO
        {
            IReadOnlyCollection<ICalendarioDTO> result = new ICalendarioDTO[] { };
            var type = typeof(T);
            Predicate<Type> refersTo = (t) => type == t || type.IsSubclassOf(t);

            if (refersTo(typeof(Subjects.User)))
                result = _context.Users;
            else if (refersTo(typeof(Subjects.Group)))
                result = _context.Groups;
            else if (refersTo(typeof(CalendarType)))
                result = _context.CalendarTypes;
            else if (refersTo(typeof(Calendar)))
                result = _context.Calendars;
            else if (refersTo(typeof(Event)))
                result = _context.Events;
            else if (refersTo(typeof(Date)))
                result = _context.Dates;
            else if (refersTo(typeof(Comment)))
                result = _context.Comments;
            else if (refersTo(typeof(ReadRecord)))
                result = _context.ReadRecords;
            else if (refersTo(typeof(Occurence)))
                result = _context.Occurences.Cast<Interfaces.ICalendarioDTO>().ToList();
            return result.OfType<T>().Cast<T>().ToList();
        }

        public async Task<string> GetServerJson<T>() where T : Interfaces.ICalendarioDTO
        {
            return await Task.Run(() => 
            {
                return this.Get<T>().Cast<ICalendarioDTO>().SerializeJson();
            });
        }
        
    }
#endif
}
