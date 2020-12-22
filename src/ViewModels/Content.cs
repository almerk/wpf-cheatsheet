using StudyWPF.Models;
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
    public class Content : Utils.NotifyPropertyChanged
    {
        private CalendarioRepository _repository;
        private ContentService _service;
        private bool isLoading=true;

        public bool IsLoading { get => isLoading; private set { isLoading = value; OnPropertyChanged(); } }
        public ObservableCollection<Calendario.Subjects.Group> AllGroups { get; private set; }
        public ObservableCollection<CalendarType> CalendarTypes { get; private set; }

        public Content(Models.CalendarioRepository repository, Services.ContentService service)
        {
            _repository = repository;
            _service = service;
        }
        public async Task Load()
        {
            AllGroups = new ObservableCollection<Calendario.Subjects.Group>(await _service.GetGroupTree(_repository));
            CalendarTypes = new ObservableCollection<Calendario.CalendarType>(await _service.GetUserCalendarTypes(_repository));
            IsLoading = false;
        }

    }
}
