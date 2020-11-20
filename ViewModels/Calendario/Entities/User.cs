using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Entities
{
    public class User: Subject
    {
        public string Appeal { get; private set; }
        public string ShortName { get; private set; }
        public string GroupId { get; private set; }
    }
}
