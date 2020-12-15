using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels
{
    public class Error: Utils.NotifyPropertyChanged
    {
        public string Message { get; set; }
    }
}
