using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public class ToDoEvent: Event
    {
        public IEnumerable<Subject> Acceptors { get; set; }
        public IEnumerable<Subject> Perfomers { get; set; }
    }
}
