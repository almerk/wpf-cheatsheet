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
        public string Name => "Informer";
        public bool HasErrors { get => hasErrors; private set { hasErrors = value; OnPropertyChanged(); } }
        public ObservableCollection<Error> Errors { get; }
        public Application()
        {
            Errors = new ObservableCollection<Error>();//TODO: DI errors
            Errors.CollectionChanged += (s, e) => { HasErrors = Errors.Any(); };
        }

        public WindowLoadedCommand WindowLoaded => LazyInitializer.EnsureInitialized(ref windowLoaded, () =>  
        new WindowLoadedCommand(async () => 
        {
            await Task.Delay(1000);
            Errors.Add(new Error() { Message = "Test error" });
            Errors.Add(new Error() { Message = "Another test error" });
        }));
    }
}
