using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Client
{
    public class ContextBuilderService
    {
        private readonly Interfaces.IClientRepository _repository;
        public ContextBuilderService(Interfaces.IClientRepository repository) 
        {
            if (repository == null) throw new ArgumentNullException("repository");
            _repository = repository;
        }

        /// <summary>
        /// Sequential steps to build full client context
        /// </summary>
        /// <returns>Calendario DTO context</returns>
        public Context Build() 
        {
            return new Context()
            {
                Users = _repository.Get<Subjects.User>(),//1
                Groups = _repository.Get<Subjects.Group>(),//2
                Dates = _repository.Get<Date>(),//3
                CalendarTypes = _repository.Get<CalendarType>(),//4
                Calendars = _repository.Get<Calendar>(),//5
                Events= _repository.Get<Event>(),//6
                Comments = _repository.Get<Comment>(),//7
                Occurences = _repository.Get<Occurence>(),//8
                ReadRecords = _repository.Get<ReadRecord>()//9
            };
        }
    }
}
