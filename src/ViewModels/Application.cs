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
        public bool CanHandleExceptions { get; set; } = false;
        public string Name => "Informer";
        public bool HasErrors { get => hasErrors; private set { hasErrors = value; OnPropertyChanged(); } }
        public ObservableCollection<Error> Errors { get; }
        public Application()
        {
            Errors = new ObservableCollection<Error>();//TODO: DI errors
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
            throw new Exception("Test exception after loading");
        }));
    }
}
