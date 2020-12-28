using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using StudyWPF.Calendario.DTO.Client;
using StudyWPF.Calendario.DTO.Interfaces;
using StudyWPF.Calendario.DTO.Utils;

namespace StudyWPF.Calendario.DTO.DevelopOnly
{
#if DEBUG
    public class TestRepository:Interfaces.IClientQueryRepository
    {
        
        private Context _context = new TestContextBuilder()
            .Full()
            .Build();

        public async Task<IReadOnlyCollection<T>> Get<T>() where T : ICalendarioDTO
        {
            return await _context.Get<T>();
        }

        public async Task<T> GetById<T>(string id) where T : IHaveId
        {
            return await _context.GetById<T>(id);
        }

        public async Task<string> GetJsonEntities<T>() where T : Interfaces.ICalendarioDTO
        {
          
            return (await this.Get<T>()).Cast<ICalendarioDTO>().SerializeJson();
         
        }
        
    }
#endif
}
