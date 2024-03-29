﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace StudyWPF.Calendario.DTO
{
 
    public class Event : Interfaces.IInheritable, Interfaces.ICalendarioDTO, Interfaces.IHaveId
    {
        public string Id { get; set; }
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
