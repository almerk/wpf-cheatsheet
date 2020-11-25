using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudyWPF.Calendario.DTO
{
    public sealed class Calendar: Interfaces.ICalendarioDTO
    {
        public string Id { get; set; }
        public string CalendarType { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(Utils.DerivedTypesConverter))]
        public Subject Owner { get; set; }
        [JsonConverter(typeof(Utils.DerivedTypesConverter))]
        public IEnumerable<Subject> Related { get; set; } = new Subject[] { };
        public IEnumerable<string> Events { get; set; } = new string[] { };
    }
}
