namespace StudyWPF.Calendario.DTO
{
    public abstract class Date : Interfaces.IInheritable
    {
        public string EventId { get; set; }
        public string OfType => GetType().Name;
    }
}