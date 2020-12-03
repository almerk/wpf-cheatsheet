using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Utils
{
    public class NotRecognizedItem:Interfaces.IInheritable
    {
        public Type Type { get; internal set; }
        public string TypeUniqueId { get; internal set; } 
    }
}
