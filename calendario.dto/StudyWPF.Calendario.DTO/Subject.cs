﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public abstract class Subject:Interfaces.IInheritable, Interfaces.ICalendarioDTO
    {
        public string Id { get; set; }
        public string OfType => GetType().Name;
        public string TypeUniqueId => Id;
    }
}
