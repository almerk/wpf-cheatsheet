using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Occurence : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Occurence>
    {
        public Occurence(StudyWPF.Calendario.DTO.Occurence value) : base(value)
        {
        }
    }
}
