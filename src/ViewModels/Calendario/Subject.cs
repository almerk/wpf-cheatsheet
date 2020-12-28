using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public abstract class Subject : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.Subject>
    {
        public Subject(StudyWPF.Calendario.DTO.Subject subject) : base(subject) { }

        public abstract string Label { get; }
    }
}
