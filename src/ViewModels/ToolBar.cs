using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels
{
    public class ToolBar : Utils.NotifyPropertyChangedObject
    {
        private ToolBarModels.Dates dates;
        private bool displayOnlyTasks = false;
        private bool displayTasksUserNotResponsibleFor = true;
        private bool displayArchiveEvents;

        public ToolBarModels.Dates Dates { get => dates; set { dates = value; OnPropertyChanged(); } }
        public bool DisplayOnlyTasks
        {
            get => displayOnlyTasks;
            set
            {
                displayOnlyTasks = value;
                OnPropertyChanged();
                DisplayTasksUserNotResponsibleFor = value ? DisplayTasksUserNotResponsibleFor : value;
            }
        }
        public bool DisplayTasksUserNotResponsibleFor { get => displayTasksUserNotResponsibleFor; set { displayTasksUserNotResponsibleFor = value; OnPropertyChanged(); } }
        public bool DisplayArchiveEvents { get => displayArchiveEvents; set { displayArchiveEvents = value; OnPropertyChanged(); } }
    }
}
