using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Subjects
{
    public class Group: Subject
    {
        public string Name { get; set; }
        public string ParentGroup { get; set; }
        public IEnumerable<string> Users { get; set; } = new string[] { };
        public IEnumerable<string> Groups { get; set; } = new string[] { };
        public override string ToString() => Name;
    }
}
