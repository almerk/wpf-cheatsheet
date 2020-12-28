using StudyWPF.Services;
using StudyWPF.ViewModels.Calendario;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels
{
    public class Content : Utils.NotifyPropertyChangedObject
    {
  
        private ContentService _service;
        private CalendarioViewContext _context;
        private bool isLoading=true;

        public bool IsLoading { get => isLoading; private set { isLoading = value; OnPropertyChanged(); } }
        public ObservableCollection<Calendario.Subjects.Group> AllGroups { get; private set; }
        public ObservableCollection<CalendarType> CalendarTypes { get; private set; }

        public Content(ContentService service, CalendarioViewContext context)
        {
            _service = service;
            _context = context;
        }
        public async Task Load()
        {
            AllGroups = new ObservableCollection<Calendario.Subjects.Group>(await _service.GetGroupTree(_context));
            CalendarTypes = new ObservableCollection<Calendario.CalendarType>(await _service.GetUserCalendarTypes(_context));
        }

    }
}
