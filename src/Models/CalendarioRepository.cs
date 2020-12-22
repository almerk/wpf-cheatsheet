using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudyWPF.Calendario.DTO.Client;
using StudyWPF.Calendario.DTO.Interfaces;
using StudyWPF.Calendario.DTO.Utils;

namespace StudyWPF.Models
{
    public class CalendarioRepository : IClientRepository
    {
        public CalendarioRepository(CalendarioServer server) 
        {
            this._server = server;
            this._proxy = new ProxyDecorator(this);
        }
        public bool IsInitialized => DTOContext != null;

        private Context DTOContext { get; set; }
        private CalendarioContext _context;
        private CalendarioServer _server;
        private ProxyDecorator _proxy;

        private object contextLock = new object();
        public async Task<CalendarioContext> GetContext() //TODO: Rewrite to AsyncLazy
        {
            if (_context != null) return _context;
            if (!IsInitialized) await Initialize();
            lock(contextLock)
            {
                return _context ?? (_context = new CalendarioContext(DTOContext));
            }
        }
            
        
        public static async Task<CalendarioRepository> CreateAndInitialize(CalendarioServer server)
        {
            var result = new CalendarioRepository(server);
            await result.Initialize();
            return result;
        }

        public async Task Initialize()
        {
            var contextBuilderService = new ContextBuilderService(_proxy);
            DTOContext = new Context();
            await contextBuilderService.Build(DTOContext);
        }

        public async Task<IReadOnlyCollection<T>> Get<T>() where T : ICalendarioDTO
        {
            var json = await _server.GetJsonEnities<T>();
            return Deserialization.DeserializeObject<List<T>>(json, _proxy);
        }

        public async Task<T> GetById<T>(string id) where T : IHaveId
        {
            var entity = await DTOContext.GetById<T>(id);
            if (entity == null) throw new ArgumentException($"Could not find entity of type{typeof(T).Name} with id {id} in state storage");
            return entity;
        }

        private class ProxyDecorator : IClientRepository
        {
            private CalendarioRepository _repository;

            public ProxyDecorator(CalendarioRepository repository)
            {
                _repository = repository;
            }

            public async Task<IReadOnlyCollection<T>> Get<T>() where T : ICalendarioDTO
            {
                var entities = await _repository.DTOContext.Get<T>();
                return entities ?? await _repository.Get<T>();
            }

            public async Task<T> GetById<T>(string id) where T : IHaveId
            {
                return await this.GetByIdFromCollection<T>(id);
            }
        }
    }
}
