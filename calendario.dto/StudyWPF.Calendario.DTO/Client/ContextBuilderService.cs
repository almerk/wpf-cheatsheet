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
        /// Sequential steps to build full client context if it does not exists
        /// </summary>
        /// <returns>Calendario DTO context</returns>
        public Context Build()
        {
            var context = new Context();
            Build(context);
            return context;
        }
            


        /// <summary>
        /// Sequential steps to build full client context
        /// </summary>
        public void Build(Context context)
        {
            if (context == null) throw new ArgumentNullException("context");
            context.Users = _repository.Get<Subjects.User>();
            context.Groups = _repository.Get<Subjects.Group>();
            context.Dates = _repository.Get<Date>();
            context.CalendarTypes = _repository.Get<CalendarType>();
            context.Calendars = _repository.Get<Calendar>();
            context.Events = _repository.Get<Event>();
            context.Comments = _repository.Get<Comment>();
            context.Occurences = _repository.Get<Occurence>();
            context.ReadRecords = _repository.Get<ReadRecord>();
        }

    }
}
