using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace StudyWPF.Calendario.DTO.Utils
{

    [Serializable]
    public sealed class DeserializationException : JsonException
    {
        public Type ObjectType { get; }
        public string TypeUniqueId { get; }
        public DeserializationException(Type objectType, string typeUniqueId)
        {
            ObjectType = objectType;
            TypeUniqueId = typeUniqueId;
        }
        public DeserializationException(Type objectType, string typeUniqueId, string message) : base(message) 
        {
            ObjectType = objectType;
            TypeUniqueId = typeUniqueId;
        }
        public DeserializationException(Type objectType, string typeUniqueId, string message, Exception inner) : base(message, inner) 
        {
            ObjectType = objectType;
            TypeUniqueId = typeUniqueId;
        }
       
    }

}
