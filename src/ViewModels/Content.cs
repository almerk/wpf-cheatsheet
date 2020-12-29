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
        public  CalendarioViewContext Context { get; }
        private CalendarioContextBuilderService _contextBuilderService;
        private bool isLoading = true;

        public bool IsLoading { get => isLoading; private set { isLoading = value; OnPropertyChanged(); } }
        public ObservableCollection<Calendario.Subjects.Group> AllGroups { get; private set; }

        public Content(ContentService service, CalendarioViewContext context, CalendarioContextBuilderService contextBuilderService)
        {
            Context = context;
            _service = service;
            _contextBuilderService = contextBuilderService;
            this.PropertyChanged += Content_PropertyChanged;
        }

        private async void Content_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName) 
            {
                case "IsLoading" when IsLoading == false:
                    await InitializeVMProperties();
                    break;
                default:
                    break;
            };
        }

        public async Task Load()
        {
            await _contextBuilderService.Build(Context);
            IsLoading = false;
        }

        public async Task InitializeVMProperties()
        {
            foreach (var c in Context.CalendarTypesVM) 
            {
                c.InitializeProperties(Context);
            }
            foreach (var c in Context.CalendarsVM)
            {
                c.InitializeProperties(Context);
            }
        }
    }
}
