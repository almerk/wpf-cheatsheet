﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public abstract class Subject:Interfaces.IInheritable, Interfaces.ICalendarioDTO, Interfaces.IHaveId
    {
        public string Id { get; set; }
        public string TypeUniqueId => Id;
    }
}
