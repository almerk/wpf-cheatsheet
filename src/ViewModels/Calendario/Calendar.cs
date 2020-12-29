using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace StudyWPF.ViewModels.Calendario
{
    public class Calendar : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Calendar>
    {
        private bool isActive;
        private int eventsCount;
        private ObservableCollection<Event> events = new ObservableCollection<Event>();

        public Calendar(StudyWPF.Calendario.DTO.Calendar value) : base(value)
        {
            this.PropertyChanged += Calendar_PropertyChanged;
            this.Events.CollectionChanged += Events_CollectionChanged;
            IsVisible = true;
        }

        public bool IsActive { get => isActive; set { isActive = value; OnPropertyChanged(); } }
        public int EventsCount { get => eventsCount; set { eventsCount = value; OnPropertyChanged(); } }
        public ObservableCollection<Event> Events { get => events; set { events = value; OnPropertyChanged(); } }
        public ICollectionView EventsFiltered 
        {
            get 
            {
                var source = CollectionViewSource.GetDefaultView(Events);
                source.Filter = x => ((Event)x).IsVisible;
                return source;
            }
        }
        
        
        private void Calendar_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsVisible":
                    foreach (var ev in Events)
                    {
                        ev.IsVisible = IsVisible;
                    }
                    break;
                case "Events":
                    Events.CollectionChanged += Events_CollectionChanged;
                    break;
                case "EventsCount":
                    IsActive = EventsCount > 0;
                    IsVisible = IsActive ? IsVisible : false;
                    break;
                default:
                    break;
            }
        }

        private void Events_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            EventsCount = Events.Count;
            EventsFiltered.Refresh();
        }

        public override void InitializeProperties(CalendarioViewContext context)
        {
            base.InitializeProperties(context);
            this.Events.Clear();
            foreach (var ev in context.EventsVM.Where(x => string.Equals(this.Value.Id, x.Value.CalendarId))) 
            {
                ev.PropertyChanged += (s, e) =>
                {
                    if (e.PropertyName == "IsVisible")
                    {
                        EventsFiltered.Refresh();
                    }
                };
                this.Events.Add(ev);
            }
        }
    }
}
