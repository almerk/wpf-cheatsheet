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
        /// Get DTO entities of specified type
        /// </summary>
        /// <typeparam name="T">ICalendarioDTO entity</typeparam>
        /// <returns></returns>
        Task<IReadOnlyCollection<T>> Get<T>() where T : ICalendarioDTO;
        Task<T> GetById<T>(string id) where T : IHaveId;

    }
}
