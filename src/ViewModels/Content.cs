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
        private CalendarioContextBuilderService _contextBuilderService;
        private bool isLoading = true;

        public bool IsLoading { get => isLoading; private set { isLoading = value; OnPropertyChanged(); } }
        public ObservableCollection<Calendario.Subjects.Group> AllGroups { get; private set; }

        public Content(ContentService service, CalendarioViewContext context, CalendarioContextBuilderService contextBuilderService)
        {
            _service = service;
            _context = context;
            _contextBuilderService = contextBuilderService;
        }
        public async Task Load()
        {
            await _contextBuilderService.Build(_context);
            IsLoading = false;
        }

    }
}
