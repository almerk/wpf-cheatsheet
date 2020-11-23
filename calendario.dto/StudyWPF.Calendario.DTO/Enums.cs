using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public enum EventStatus 
    {
        Late,
        Coming,
        Done,
        Archive
    }

    public enum DateBelonging
    {
        Start,
        Middle,
        End
    }
}
