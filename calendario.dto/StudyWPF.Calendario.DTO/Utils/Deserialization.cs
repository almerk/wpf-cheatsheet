using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using StudyWPF.Calendario.DTO.Interfaces;

namespace StudyWPF.Calendario.DTO.Utils
{
    public static class Deserialization
    {
        public static T DeserializeObject<T>(string jsonString, Interfaces.IClientRepository proxyRepository) 
        {

            return JsonConvert.DeserializeObject<T>(jsonString, new JsonSerializerSettings() 
            {
                ContractResolver = new ProxyDeserializeContractResolver(proxyRepository),
                TypeNameHandling = TypeNameHandling.Auto
            });
        }
        internal class ProxyDeserializeContractResolver : DefaultContractResolver
        {
            public IClientRepository ProxyRepository { get; }

            public ProxyDeserializeContractResolver(IClientRepository proxyRepository)
            {
                this.ProxyRepository = proxyRepository;
            }
        }
    }
}
