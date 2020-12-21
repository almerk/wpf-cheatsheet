using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.ToolBarModels
{
    public class Dates : Utils.NotifyPropertyChanged
    {
        private DateTime? start;
        public DateTime? Start { get => start; set { start = value; OnPropertyChanged(); } }
        private DateTime? finish;
        public DateTime? Finish { get => finish; set { finish = value; OnPropertyChanged(); } }
    }
}
