using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class ReadRecord : Utils.GenericDTOViewModelDecorator<StudyWPF.Calendario.DTO.ReadRecord>
    {
        public ReadRecord(StudyWPF.Calendario.DTO.ReadRecord value) : base(value)
        {
        }
    }
}
