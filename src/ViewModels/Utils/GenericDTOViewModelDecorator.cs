using StudyWPF.Calendario.DTO.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Utils
{
    public abstract class GenericDTOViewModelDecorator<T> : Utils.NotifyPropertyChangedObject
        where T : ICalendarioDTO

    {
        private bool isVisible = false;

        public GenericDTOViewModelDecorator(T value)
        {
            this.Value = value;
        }
        public T Value { get; }

        public bool IsVisible { get => isVisible; set { isVisible = value; OnPropertyChanged(); } }

        public virtual void InitializeProperties(CalendarioViewContext context) { }
    }
}
