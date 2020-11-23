using StudyWPF.ViewModels.Calendario.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Entities
{
    public class Comment : Entity
    {
        public User User { get; set; } 
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
    }
}
