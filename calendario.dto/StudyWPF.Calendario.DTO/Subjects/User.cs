using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Subjects
{
    public class User: Subject
    {
        public string GroupId { get; set; }
        public string Appeal { get; set; }
        public string ShortName { get; set; }
    }
}
