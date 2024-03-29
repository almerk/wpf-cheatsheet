﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyWPF.Calendario.DTO.Client;
using StudyWPF.Calendario.DTO.Interfaces;
using StudyWPF.Calendario.DTO.Utils;

namespace StudyWPF.Services
{
    public class CalendarioServer
    {
        private static Calendario.DTO.DevelopOnly.TestRepository _repoMock = new Calendario.DTO.DevelopOnly.TestRepository();
        public async Task<string> GetJsonEnities<T>() where T: ICalendarioDTO
        {
            await Task.Delay(20);//Request time imitation
            return  await _repoMock.GetJsonEntities<T>();
        }
    }
}
