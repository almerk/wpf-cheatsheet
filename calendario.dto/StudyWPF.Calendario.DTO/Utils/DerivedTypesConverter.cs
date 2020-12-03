using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Schema;
using Newtonsoft.Json.Serialization;
using StudyWPF.Calendario.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using System.Reflection;

namespace StudyWPF.Calendario.DTO.Utils
{
    internal class DerivedTypesConverter : JsonConverter
    {
        public override bool CanRead => true;
        public override bool CanConvert(Type objectType)
        {
            return objectType.GetInterfaces().Contains(typeof(Interfaces.IInheritable));
        }
        public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
        {
            JsonSerializer proxySerializer;
            if (serializer.ContractResolver is Deserialization.ProxyDeserializeContractResolver proxyResolver)
            {
                proxySerializer = DerivedTypesSerializer(proxyResolver.ProxyRepository);
            }
            else
            {
                proxySerializer = DerivedTypesSerializer();
            }
            return proxySerializer.Deserialize(reader, objectType);
        }

        JsonSerializer _derivedTypesSerializer;
        /// <summary>
        /// Special serializer for derived types
        /// </summary>
        private JsonSerializer DerivedTypesSerializer(Interfaces.IClientRepository repository = null) => LazyInitializer.EnsureInitialized(ref _derivedTypesSerializer, 
            () =>
            JsonSerializer.Create(new JsonSerializerSettings()
            {
                ContractResolver = new InterfaceContractResolver(typeof(Interfaces.IInheritable)),
                Converters = new JsonConverter[] 
                { 
                    new StringEnumConverter(),
                    new ProxyDeserializeConverter(repository)
                },
                NullValueHandling = NullValueHandling.Ignore,
                TypeNameHandling = TypeNameHandling.Objects,
            }));

        public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
        {
            DerivedTypesSerializer().Serialize(writer, value);
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

        private class ProxyDeserializeConverter : JsonConverter
        {
            private IClientRepository _repository;
            public ProxyDeserializeConverter(IClientRepository repository)
            {
                this._repository = repository;
            }

            public override bool CanWrite => false;

            public override bool CanConvert(Type objectType)
            {
                return typeof(Interfaces.IInheritable).IsAssignableFrom(objectType);
            }

            public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer)
            {
                var jToken = JToken.Load(reader);
                var typeName = jToken.Value<string>("$type");
                var uniqueIdString = jToken.Value<string>("typeUniqueId");
                if (string.IsNullOrEmpty(typeName)) throw new JsonException($"Deserializing error. Json object of type {objectType} doesn't contain $type member.");
                if (string.IsNullOrEmpty(uniqueIdString)) throw new JsonException($"Deserializing error. Json object of type {objectType} doesn't contain typeUniqueId member.");
                var type = Type.GetType(typeName, true);
                if (_repository != null) 
                {
                    MethodInfo mi = _repository.GetType().GetMethod("Get");
                    MethodInfo miConstructed = mi.MakeGenericMethod(type);
                    var elements = miConstructed.Invoke(_repository, new object[] { });
                    var refferedElement = (elements as IEnumerable<IInheritable>).FirstOrDefault(x => x.TypeUniqueId == uniqueIdString);
                    if (refferedElement == null)
                        throw new DeserializationException(type, uniqueIdString, $"Could not find object of type {type} and id {uniqueIdString} in deserialization proxy repository");
                    return refferedElement;
                }
                return new NotRecognizedItem()
                {
                    Type = type,
                    TypeUniqueId = uniqueIdString
                }; 
            }

            public override void WriteJson(JsonWriter writer, object value, JsonSerializer serializer)
            {
                throw new NotImplementedException();
            }
        }
    }
}
