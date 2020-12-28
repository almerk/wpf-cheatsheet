﻿using StudyWPF.Calendario.DTO.Client;
using StudyWPF.Calendario.DTO.Interfaces;
using StudyWPF.Calendario.DTO.Utils;
using StudyWPF.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Services
{
    public class CalendarioContextBuilderService
    {
        private ContextBuilderService _contextBuildService;
        private CalendarioServer _server;

        public CalendarioContextBuilderService(ContextBuilderService contextBuilderService, CalendarioServer server) 
        {
            this._contextBuildService = contextBuilderService ?? throw new ArgumentNullException("contextBuildService");
            this._server = server ?? throw new ArgumentNullException("server");
        }
        public async Task Build(CalendarioViewContext context) 
        {
            var proxy = new ProxyContext(context, _server);
            await _contextBuildService.Build(context, proxy);
            _ = context ?? throw new ArgumentNullException();
        }

        private class ProxyContext : IClientQueryRepository
        {
            private CalendarioViewContext _context;
            private CalendarioServer _server;

            public ProxyContext(CalendarioViewContext context, CalendarioServer server)
            {
                _context = context;
                _server = server;
            }

            public async Task<IReadOnlyCollection<T>> Get<T>() where T : ICalendarioDTO
            {
                var entities = await _context.Get<T>();
                if (entities == null) 
                {
                    var json = await _server.GetJsonEnities<T>();
                    entities = Deserialization.DeserializeObject<List<T>>(json, this);
                }
                return entities;
            }

            public async Task<T> GetById<T>(string id) where T : IHaveId
            {
                return await _context.GetById<T>(id);
            }
        }

    }
}
