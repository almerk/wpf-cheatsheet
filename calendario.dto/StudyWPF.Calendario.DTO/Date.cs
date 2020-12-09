namespace StudyWPF.Calendario.DTO
{
    public abstract class Date : Interfaces.IInheritable, Interfaces.ICalendarioDTO, Interfaces.IHaveId
    {
        public string Id { get; set; }
        public string TypeUniqueId => Id;
    }
}