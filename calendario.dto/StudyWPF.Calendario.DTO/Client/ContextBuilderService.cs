using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.Client
{
    public class ContextBuilderService
    {
        /// <summary>
        /// Sequential steps to build full client context
        /// </summary>
        public async Task Build(Context context, Interfaces.IClientQueryRepository repository)
        {
            _ = context ?? throw new ArgumentNullException("context");
            _ = repository ?? throw new ArgumentNullException("repository");
            context.Users = await repository.Get<Subjects.User>();
            context.Groups = await repository.Get<Subjects.Group>();
            context.Dates = await repository.Get<Date>();
            context.CalendarTypes = await repository.Get<CalendarType>();
            context.Calendars = await repository.Get<Calendar>();
            context.Events = await repository.Get<Event>();
            context.Comments = await repository.Get<Comment>();
            context.Occurences = await repository.Get<Occurence>();
            context.ReadRecords = await repository.Get<ReadRecord>();
            context.IsBuilt = true;
        }

    }
}
