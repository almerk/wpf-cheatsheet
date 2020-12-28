using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Dates
{
    public sealed class SimpleDate : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Dates.SimpleDate>
    {
        public SimpleDate(StudyWPF.Calendario.DTO.Dates.SimpleDate value) : base(value)
        {
        }
    }
}
