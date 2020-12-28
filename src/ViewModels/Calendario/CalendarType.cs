using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class CalendarType : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.CalendarType>
    {
        public CalendarType(StudyWPF.Calendario.DTO.CalendarType value) : base(value)
        {
        }
    }
}
