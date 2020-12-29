using StudyWPF.Calendario.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Collections.ObjectModel;
using StudyWPF.Calendario.DTO.Subjects;

namespace StudyWPF.ViewModels
{
    public class CalendarioViewContext : StudyWPF.Calendario.DTO.Client.Context, INotifyPropertyChanged
    {
        private ObservableCollection<Calendario.CalendarType> calendarTypesVM;
        public ObservableCollection<Calendario.CalendarType> CalendarTypesVM { get => calendarTypesVM; set { calendarTypesVM = value; OnPropertyChanged();  } }
        public override IReadOnlyCollection<CalendarType> CalendarTypes { get => CalendarTypesVM?.Select(x => x.Value).ToList(); set => CalendarTypesVM = new ObservableCollection<Calendario.CalendarType>(value.Select(x => new Calendario.CalendarType(x))); }

        private ObservableCollection<Calendario.Calendar> calendarsVM;
        public ObservableCollection<ViewModels.Calendario.Calendar> CalendarsVM { get => calendarsVM; set { calendarsVM = value; OnPropertyChanged(); } }
        public override IReadOnlyCollection<Calendar> Calendars { get => calendarsVM?.Select(x => x.Value).ToList(); set => CalendarsVM = new ObservableCollection<Calendario.Calendar>(value.Select(x => new Calendario.Calendar(x))); }

        private ObservableCollection<Calendario.Event> eventsVM;
        public ObservableCollection<Calendario.Event> EventsVM { get => eventsVM; set { eventsVM = value; OnPropertyChanged(); } }
        public override IReadOnlyCollection<Event> Events { get => EventsVM?.Select(x => x.Value).ToList(); set => EventsVM = new ObservableCollection<Calendario.Event>(value.Select(x => new Calendario.Event(x))); }

        private ObservableCollection<Calendario.Subjects.Group> groupsVM;
        public ObservableCollection<Calendario.Subjects.Group> GroupsVM { get => groupsVM; set { groupsVM = value; OnPropertyChanged(); } }
        public override IReadOnlyCollection<Group> Groups { get => GroupsVM?.Select(x => x.GroupValue).ToList(); set => GroupsVM = new ObservableCollection<Calendario.Subjects.Group>(value.Select(x => new Calendario.Subjects.Group(x))); }

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
