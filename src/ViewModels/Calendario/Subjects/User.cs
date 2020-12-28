using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Subjects
{
    public class User : Subject
    {
        public User(StudyWPF.Calendario.DTO.Subjects.User user) : base(user) { }

        private string appeal;
        private string shortName;

        public string Appeal { get => appeal; set { appeal = value; OnPropertyChanged(); } }
        public string ShortName { get => shortName; set { shortName = value; OnPropertyChanged(); } }

        public override string Label => ShortName;
    }
}
