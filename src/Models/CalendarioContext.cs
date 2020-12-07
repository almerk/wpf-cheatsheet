using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyWPF.Calendario.DTO.Client;


namespace StudyWPF.Models
{
    public class CalendarioContext
    {
        public Context ContextDTO { get; private set; }

        public CalendarioContext(Context contextDTO)
        {
            ContextDTO = contextDTO;
        }
    }
}
