using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudyWPF.Calendario.DTO
{
    public class ToDoEvent: Event
    {
        [JsonConverter(typeof(Utils.DerivedTypesConverter))]
        public IEnumerable<Subject> Acceptors { get; set; }

        [JsonConverter(typeof(Utils.DerivedTypesConverter))]
        public IEnumerable<Subject> Perfomers { get; set; }
    }
}
