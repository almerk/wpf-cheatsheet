using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels.Calendario
{
    public class Comment : Utils.NotifyPropertyChangedObject
    {
        private string text;

        public string Id { get; private set; }
        public Event Event { get; private set; }
        public Subjects.User User { get; private set; }
        public DateTime DateTime { get; private set; }
        public string Text { get => text; set { text = value; OnPropertyChanged(); } }
    }
}
