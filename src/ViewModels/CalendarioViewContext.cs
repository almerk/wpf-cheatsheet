using StudyWPF.Calendario.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;

namespace StudyWPF.ViewModels
{
    public class CalendarioViewContext : StudyWPF.Calendario.DTO.Client.Context, INotifyPropertyChanged
    {
        private ObservableCollection<Calendario.CalendarType> calendarTypesVM;
        public ObservableCollection<ViewModels.Calendario.CalendarType> CalendarTypesVM { get => calendarTypesVM; set { calendarTypesVM = value; OnPropertyChanged();  } }
        public override IReadOnlyCollection<CalendarType> CalendarTypes { get => calendarTypesVM?.Select(x => x.Value).ToList(); set => CalendarTypesVM = new ObservableCollection<Calendario.CalendarType>(value.Select(x => new Calendario.CalendarType(x))); }



        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
