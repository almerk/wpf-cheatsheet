using Ninject;
using StudyWPF.Models;
using StudyWPF.ViewModels.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels
{
    public class Application : Utils.NotifyPropertyChanged
    {
        private bool hasErrors;
        private WindowLoadedCommand windowLoaded;
        private CalendarioRepository _repository;

        public bool CanHandleExceptions { get; set; } = false;
        public string Name => "📅 Informer";
        public bool HasErrors { get => hasErrors; private set { hasErrors = value; OnPropertyChanged(); } }
        public ObservableCollection<Error> Errors { get; } = new ObservableCollection<Error>();
        
        [Inject]
        public ToolBar ToolBar { get; set; }
        
        [Inject]
        public Content Content { get; set; }
        
        public Application()
        {
            Errors.CollectionChanged += (s, e) => { HasErrors = Errors.Any(); };
        }

        internal void HandleException(Exception ex)
        {
            Errors.Add(new Error() { Message = ex.Message });
        }

        public WindowLoadedCommand WindowLoaded => LazyInitializer.EnsureInitialized(ref windowLoaded, () =>  
        new WindowLoadedCommand(async () => 
        {
            CanHandleExceptions = true;
            await Content.Load();
        }));
    }
}
