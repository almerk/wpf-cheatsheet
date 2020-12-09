using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Utils
{
    public static class DTOExtensions
    {
        public static async Task<T> GetByIdFromCollection<T>(this Interfaces.IClientRepository repository, string id) where T:Interfaces.IHaveId
        {
            var entities = await repository.Get<T>();
            if (entities == null) return default(T);
            return entities.FirstOrDefault(x => x.Id == id);
        } 
    }
}
