using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Entities
{
    public class ReadRecord:Utils.Entity
    { 
        public User By { get; private set; }
        public DateTime DateTime { get; private set; }
    }
}
