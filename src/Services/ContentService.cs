using StudyWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Services
{
    public class ContentService
    {


        public async Task<IEnumerable<ViewModels.Calendario.CalendarType>> GetUserCalendarTypes(CalendarioViewContext context)
        {
            //var calendarTypesDTO = 
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<ViewModels.Calendario.Subjects.Group>> GetGroupTree(CalendarioViewContext context)
        {
            throw new NotImplementedException();
        }
    }
}
