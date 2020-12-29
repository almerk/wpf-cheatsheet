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
    public class CalendarType : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.CalendarType>
    {
        private bool isActive;
        private ObservableCollection<Calendar> calendars = new ObservableCollection<Calendar>();
        private int calendarsCount;

        public CalendarType(StudyWPF.Calendario.DTO.CalendarType value) : base(value)
        {
            Calendars.CollectionChanged += Calendars_CollectionChanged;
            PropertyChanged += CalendarType_PropertyChanged;
            IsVisible = true;
        }

        private void Calendars_CollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
        {
            CalendarsCount = Calendars.Count;
            CalendarsFiltered.Refresh();
        }

        public bool IsActive { get => isActive; set { isActive = value; OnPropertyChanged(); } }

        public ObservableCollection<Calendar> Calendars { get => calendars; set 
            { 
                calendars = value; 
                OnPropertyChanged(); 
            } 
        }

        public ICollectionView CalendarsFiltered
        {
            get
            {
                var source = CollectionViewSource.GetDefaultView(Calendars);
                source.Filter = x => ((Calendar)x).IsVisible;
                return source;
            }
        }

        public int CalendarsCount { get => calendarsCount; set { calendarsCount = value; OnPropertyChanged(); } }

        private void CalendarType_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            switch (e.PropertyName)
            {
                case "IsVisible":
                    foreach (var c in Calendars)
                    {
                        c.IsVisible = IsVisible;
                    }
                    break;
                case "Calendars":
                    Calendars.CollectionChanged += Calendars_CollectionChanged;
                    break;
                case "CalendarsCount":
                    IsActive = CalendarsCount > 0;
                    IsVisible = IsActive ? IsVisible : false;
                    break;
                default:
                    break;
            }

        }

        public override void InitializeProperties(CalendarioViewContext context)
        {
            base.InitializeProperties(context);
            this.Calendars.Clear();
            foreach (var calendar in context.CalendarsVM.Where(x => string.Equals(x.Value.CalendarType, this.Value.Id)))
            {
                calendar.PropertyChanged += (object sender, PropertyChangedEventArgs e) =>
                {
                    if (e.PropertyName == "IsVisible")
                    {
                        CalendarsFiltered.Refresh();
                    }
                };
                this.Calendars.Add(calendar);
            }


        }

    }
}
