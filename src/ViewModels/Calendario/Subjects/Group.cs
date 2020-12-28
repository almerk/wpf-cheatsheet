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
        public Group(StudyWPF.Calendario.DTO.Subjects.Group group) : base(group) 
        {
            this.GroupValue = group;
        }
        public StudyWPF.Calendario.DTO.Subjects.Group GroupValue { get; }

        public override string Label => GroupValue.Name;
    }
}
