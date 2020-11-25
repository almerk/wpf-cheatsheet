using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyWPF.Calendario.DTO.Utils;

namespace StudyWPF.Calendario.DTO.DevelopOnly
{
#if DEBUG
    public class TestData
    {
        
        private Context _context = new ContextBuilder()
            .Full()
            .Build();
        public async Task<string> GetData<T>() 
        {
            IEnumerable<Interfaces.ICalendarioDTO> result = new Interfaces.ICalendarioDTO[] { };
            if (typeof(T) == typeof(Subjects.User)) 
            {
                result = _context.Users;
            }
            else if (typeof(T) == typeof(Subjects.Group))
            {
                result = _context.Groups;
            }
            else if(typeof(T) == typeof(CalendarType)) 
            {
                result = _context.CalendarTypes;
            }
            else if (typeof(T) == typeof(Calendar))
            {
                result = _context.Calendars;
            }
            else if (typeof(T) == typeof(Event))
            {
                result = _context.Events;
            }
            else if (typeof(T) == typeof(Comment))
            {
                result = _context.Comments;
            }
            else if (typeof(T) == typeof(ReadRecord))
            {
                result = _context.ReadRecords;
            }
            else if (typeof(T) == typeof(Occurence))
            {
                result = _context.Occurences.Cast<Interfaces.ICalendarioDTO>();
            }
            return await Task.Run(() => result.SerializeJson());
        }
        
    }
#endif
}
