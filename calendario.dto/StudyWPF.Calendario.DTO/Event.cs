using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StudyWPF.Calendario.DTO
{
    [JsonObject()]
    public class Event : Interfaces.IInheritable, Interfaces.ICalendarioDTO
    {
        public string Id { get; set; }
        public string OfType => GetType().Name;
        public string TypeUniqueId => Id;
        public string CalendarId { get; set; }
        public string Name { get; set; }
        [JsonConverter(typeof(Utils.DerivedTypesConverter))]
        public IEnumerable<Date> Dates { get; set; }
        public string Description { get; set; } = string.Empty;
        [JsonConverter(typeof(Utils.DerivedTypesConverter))]
        public IEnumerable<Subject> Related { get; set; } = new Subject[] { };
        public IEnumerable<string> Comments { get; set; } = new string[] { };
    }
}
