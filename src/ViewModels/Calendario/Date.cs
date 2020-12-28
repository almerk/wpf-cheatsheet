using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public abstract class Date : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Date>
    {
        protected Date(StudyWPF.Calendario.DTO.Date value) : base(value)
        {
        }
    }
}
