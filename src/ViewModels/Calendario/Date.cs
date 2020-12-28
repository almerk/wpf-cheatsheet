using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public abstract class Date: Utils.NotifyPropertyChangedObject
    {
        public string Id { get; protected set; }
    }
}
