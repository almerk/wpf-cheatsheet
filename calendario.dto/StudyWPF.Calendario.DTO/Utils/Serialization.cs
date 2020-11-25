using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace StudyWPF.Calendario.DTO.Utils
{
    public static class Serialization
    {
        public static string SerializeJson(this Interfaces.ICalendarioDTO obj) 
        {
            return JsonConvert.SerializeObject(obj, DefaultSerializerSettings);
        }
        public static string SerializeJson(this IEnumerable<Interfaces.ICalendarioDTO> obj)
        {
            return JsonConvert.SerializeObject(obj, DefaultSerializerSettings);
        }

        private static JsonSerializerSettings DefaultSerializerSettings =>
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new[] { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore
            };
    }
}
