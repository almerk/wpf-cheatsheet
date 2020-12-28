using StudyWPF.Calendario.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace StudyWPF.ViewModels
{
    public class CalendarioViewContext: StudyWPF.Calendario.DTO.Client.Context, INotifyPropertyChanged
    {
        //public override IReadOnlyCollection<CalendarType> CalendarTypes { get => base.CalendarTypes; set => base.CalendarTypes = value; }


        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

    }
}
