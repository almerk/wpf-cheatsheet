using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using StudyWPF.Calendario.DTO.Client;
using StudyWPF.Calendario.DTO.Interfaces;

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
            contextBuilderService.Build(result.DTOContext);
            return result;
        }

        public IReadOnlyCollection<T> Get<T>() where T : ICalendarioDTO
        {
            var json = _server.GetJsonEnities<T>().GetAwaiter().GetResult(); //TODO: This smells bad, rewrite
            return Calendario.DTO.Utils.Deserialization.DeserializeObject<List<T>>(json, _proxy);
        }
        private class ProxyDecorator : IClientRepository
        {
            private CalendarioRepository _repository;

            public ProxyDecorator(CalendarioRepository repository)
            {
                _repository = repository;
            }

            public IReadOnlyCollection<T> Get<T>() where T : ICalendarioDTO
            {
               var entities = _repository.DTOContext.Get<T>();
               return entities ?? _repository.Get<T>();
            }
        }
    }
}
