using StudyWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.ViewModels
{
    public class Application: Utils.NotifyPropertyChanged
    {
        private CalendarioContext _context;

        public Application(Models.CalendarioContext context) 
        {
            this._context = context;
        }
    }
}
