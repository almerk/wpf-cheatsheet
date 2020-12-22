using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Services
{
    public class ContentService
    {
        public async Task<IEnumerable<ViewModels.Calendario.CalendarType>> GetUserCalendarTypes(Models.CalendarioRepository repository)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ViewModels.Calendario.Subjects.Group>> GetGroupTree(Models.CalendarioRepository repository)
        {
            throw new NotImplementedException();
        }
    }
}
