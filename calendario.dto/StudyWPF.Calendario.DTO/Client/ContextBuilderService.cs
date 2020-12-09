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
        public async Task<Context> Build()
        {
            var context = new Context();
            await Build(context);
            return context;
        }
            


        /// <summary>
        /// Sequential steps to build full client context
        /// </summary>
        public async Task Build(Context context)
        {
            if (context == null) throw new ArgumentNullException("context");
            context.Users = await _repository.Get<Subjects.User>();
            context.Groups = await _repository.Get<Subjects.Group>();
            context.Dates = await _repository.Get<Date>();
            context.CalendarTypes = await _repository.Get<CalendarType>();
            context.Calendars = await _repository.Get<Calendar>();
            context.Events = await _repository.Get<Event>();
            context.Comments = await _repository.Get<Comment>();
            context.Occurences = await _repository.Get<Occurence>();
            context.ReadRecords = await _repository.Get<ReadRecord>();
        }

    }
}
