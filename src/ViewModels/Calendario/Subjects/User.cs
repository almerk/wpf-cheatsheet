using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario.Subjects
{
    public class User : Subject
    {
        private Group group;
        private string appeal;
        private string shortName;

        public Group Group { get => group; set { group = value; OnPropertyChanged();  } }
        public string Appeal { get => appeal; set { appeal = value; OnPropertyChanged(); } }
        public string ShortName { get => shortName; set { shortName = value; OnPropertyChanged(); } }
    }
}
