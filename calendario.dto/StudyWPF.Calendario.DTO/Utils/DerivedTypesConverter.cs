using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Utils
{
    internal class DerivedTypesConverter : JsonConverter
    {
        public override bool CanRead => false;
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(Interfaces.ICalendarioDTO));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            throw new NotImplementedException();
        }
        private JsonSerializerSettings InterfaceSerializationSettings = new JsonSerializerSettings()
        {
            ContractResolver = new InterfaceContractResolver(typeof(Interfaces.IInheritable))
        };

        JsonSerializer _derivedTypesSerializer;
        /// <summary>
        /// Special serializer for derived types
        /// </summary>
        private JsonSerializer DerivedTypesSerializer => LazyInitializer.EnsureInitialized(ref _derivedTypesSerializer, 
            () =>
            JsonSerializer.Create(new JsonSerializerSettings()
            {
                ContractResolver = new InterfaceContractResolver(typeof(Interfaces.IInheritable)),
                Converters = new[] { new StringEnumConverter() },
                NullValueHandling = NullValueHandling.Ignore
            }));

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DerivedTypesSerializer.Serialize(writer, value);
        }
        /// <summary>
        /// This contract resolver saves only that data, which is specified in the interface
        /// </summary>
        private class InterfaceContractResolver : CamelCasePropertyNamesContractResolver
        {
            private readonly Type _interfaceType;
            public InterfaceContractResolver(Type InterfaceType)
            {
                _interfaceType = InterfaceType;
            }
            protected override IList<JsonProperty> CreateProperties(Type type, MemberSerialization memberSerialization)
            {
                IList<JsonProperty> properties = base.CreateProperties(_interfaceType, memberSerialization);
                return properties;
            }
        }
    }
}
