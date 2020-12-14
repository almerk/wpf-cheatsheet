using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;

namespace StudyWPF.ViewModels.Calendario.Subjects
{
    public class Group : Subject
    {
        private string name;
        private Group parentGroup;

        public string Name { get => name; set { name = value; OnPropertyChanged(); } }
        public Group ParentGroup { get => parentGroup; set { parentGroup = value; OnPropertyChanged(); } }
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();
        public ObservableCollection<Group> Groups { get; set; } = new ObservableCollection<Group>();
    }
}
