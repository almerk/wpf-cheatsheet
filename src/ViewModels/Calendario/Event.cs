using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Event : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Event>
    {
        public Event(StudyWPF.Calendario.DTO.Event value) : base(value)
        {
        }
    }
}
