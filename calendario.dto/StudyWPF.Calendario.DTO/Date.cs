﻿namespace StudyWPF.Calendario.DTO
{
    public abstract class Date : Interfaces.IInheritable, Interfaces.ICalendarioDTO
    {
        public string Id { get; set; }
        public string OfType => GetType().Name;
        public string TypeUniqueId => Id;
    }
}