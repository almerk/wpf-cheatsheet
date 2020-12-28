using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Comment : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Comment>
    {
        public Comment(StudyWPF.Calendario.DTO.Comment value) : base(value)
        {
        }
    }
}
