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
            //var requestTypeIsIInhertiable = obj.GetType().GetInterfaces().Contains(typeof(Interfaces.IInheritable));
            return JsonConvert.SerializeObject(obj, DefaultSerializerSettings);
        }
        public static string SerializeJson(this IEnumerable<Interfaces.ICalendarioDTO> objects)
        {
            //var requestTypeIsIInhertiable = false;
            //var first = objects.FirstOrDefault();
            //if (first != null) 
            //{
            //    requestTypeIsIInhertiable = first.GetType().GetInterfaces().Contains(typeof(Interfaces.IInheritable));
            //}
            return JsonConvert.SerializeObject(objects, DefaultSerializerSettings);
        }

        private static JsonSerializerSettings DefaultSerializerSettings =>
            new JsonSerializerSettings()
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver(),
                Converters = new[] { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Auto
            };
    }
}
