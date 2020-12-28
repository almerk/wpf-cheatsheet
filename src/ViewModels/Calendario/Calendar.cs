using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Calendar : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Calendar>
    {
        public Calendar(StudyWPF.Calendario.DTO.Calendar value) : base(value) { }
    }
}
