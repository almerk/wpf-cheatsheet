using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO
{
    public sealed class Comment
    {
        public string Id { get; set; }
        public string EventId { get; set; }
        public string UserId { get; set; }
        public DateTime DateTime { get; set; }
        public string Text { get; set; }
    }
}
