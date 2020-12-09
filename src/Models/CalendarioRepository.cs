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
        private CalendarioRepository(CalendarioServer server) 
        {
            this._server = server;
            this._proxy = new ProxyDecorator(this);
        }
        private Context DTOContext { get; } = new Context();
        private CalendarioContext _context;
        private CalendarioServer _server;
        private ProxyDecorator _proxy;

        public CalendarioContext Context
        {
            get
            {
                return LazyInitializer.EnsureInitialized(ref _context, () => new CalendarioContext(DTOContext));
            }
        }
        public static async Task<CalendarioRepository> Create(CalendarioServer server) 
        {
            var result = new CalendarioRepository(server);
            var contextBuilderService = new ContextBuilderService(result._proxy);
            await contextBuilderService.Build(result.DTOContext);
            return result;
        }

        public async Task<IReadOnlyCollection<T>> Get<T>() where T : ICalendarioDTO
        {
            var json = await _server.GetJsonEnities<T>();
            return Calendario.DTO.Utils.Deserialization.DeserializeObject<List<T>>(json, _proxy);
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
