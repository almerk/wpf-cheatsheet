using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Interfaces
{
    /// <summary>
    /// Calendario client repository 
    /// </summary>
    public interface IClientRepository
    {
        /// <summary>
        /// All enities of type get method MUST BE only sync (caused by DI)
        /// </summary>
        /// <typeparam name="T">ICalendarioDTO entity</typeparam>
        /// <returns></returns>
        IReadOnlyCollection<T> Get<T>() where T : ICalendarioDTO;

    }
}
