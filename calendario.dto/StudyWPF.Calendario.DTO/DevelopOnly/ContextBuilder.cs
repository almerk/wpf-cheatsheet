using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.DevelopOnly
{
#if DEBUG
    public class ContextBuilder
    {
        private List<Subjects.Group> _groupsAsTree = new List<Subjects.Group>();
        private List<Subjects.Group> _groupsAsList= new List<Subjects.Group>();
        private List<Subjects.User> _users = new List<Subjects.User>();
        private List<CalendarType> _calendarTypes = new List<CalendarType>();
        private List<Calendar> _calendars = new List<Calendar>();
        private List<Event> _events = new List<Event>();
        private List<Comment> _comments = new List<Comment>();
        private List<ReadRecord> _readRecords = new List<ReadRecord>();
        
      

        public ContextBuilder() 
        {
            
        }

        public ContextBuilder WithGroupsAndUsers() 
        {
            var allGroup = new Subjects.Group()
            {
                Id = CreateId(),
                Name = "All",
            };
            _groupsAsList.Add(allGroup);
            AddUser(allGroup, new Subjects.User()
            {
                Appeal = "Admin",
                ShortName = "Admin"
            });
       
            var mainGroup = new Subjects.Group()
            {
                Id = CreateId(),
                Name = "Main characters",
                ParentGroup = allGroup.Id,
            };
            AddGroup(allGroup, mainGroup);
            var pinesGroup = new Subjects.Group()
            {
                Id=CreateId(),
                Name="Pines Family",
            };
            AddUser(mainGroup, new Subjects.User()
            {
                ShortName= "Wendy Corduroy",
                Appeal = "Wendy"
            });
            AddUser(mainGroup, new Subjects.User()
            {
                ShortName = "Jesus Alzamirano Ramírez",
                Appeal = "Soos"
            });
            AddGroup(mainGroup, pinesGroup);
            AddUser(pinesGroup, new Subjects.User() 
            {
                ShortName="Mason Pines",
                Appeal = "Dipper"
            });
            AddUser(pinesGroup, new Subjects.User()
            {
                ShortName = "Mabel Pines",
                Appeal = "Mabel"
            });
            AddUser(pinesGroup, new Subjects.User()
            {
                ShortName = "Stanley Pines",
                Appeal = "Grunkle Stan"
            });
            AddUser(pinesGroup, new Subjects.User() 
            {
                ShortName="Stanford Pines",
                Appeal = "Grunkle Ford"
            });
            var antogonists = new Subjects.Group()
            {
                Id = CreateId(),
                Name = "Antagonists",
                ParentGroup = allGroup.Id,
            };
            AddGroup(allGroup, antogonists);
            AddUser(antogonists, new Subjects.User() 
            {
                ShortName = "Bill Cipher",
                Appeal = "Bill"
            });
            AddUser(antogonists, new Subjects.User()
            {
                ShortName = "Gideon Charles Gleeful",
                Appeal = "Lil Gideon"
            });
            var characters = new Subjects.Group()
            {
                Id = CreateId(),
                Name = "Reccuring characters",
                ParentGroup = allGroup.Id,
            };
            AddGroup(allGroup, characters);
            AddUser(characters, new Subjects.User() { 
                ShortName="Waddles",
                Appeal="Waddles"
            });
            AddUser(characters, new Subjects.User()
            {
                ShortName = "Fiddleford Hadron McGucket",
                Appeal = "Old man McGucket"
            });
            _groupsAsTree.Add(allGroup);
            return this;
        }

        public ContextBuilder WithCalendarTypes() 
        {
            _calendarTypes = new List<CalendarType>() 
            {
                new CalendarType()
                {
                    Id = CreateId(),
                    Name="Birthdays"
                },
                new CalendarType()
                {
                    Id = CreateId(),
                    Name="Personal"
                },
                new CalendarType()
                {
                    Id = CreateId(),
                    Name="Adventures"
                }
            };
            return this;
        }

        public ContextBuilder WithCalendars() 
        {
            var personalCalendars = new[]
            {
                new Calendar()
                {
                    Id = CreateId(),
                    Name = "Dippers's tasks",
                    Owner = GetUserByAppeal("Dipper"),
                    CalendarType = TypeByName("Personal").Id,
                    Related = new []
                    {
                        GetUserByAppeal("Dipper"),
                        GetUserByAppeal("Mabel"),
                        GetUserByAppeal("Grunkle Stan")
                    }
                    
                },
                new Calendar()
                {
                    Id = CreateId(),
                    Name = "Mabels's tasks",
                    Owner = GetUserByAppeal("Mabel"),
                    CalendarType = TypeByName("Personal").Id,
                    Related = new[]
                    {
                        GetUserByAppeal("Mabel"),
                        GetUserByAppeal("Waddles")
                    }

                },
                new Calendar()
                {
                    Id = CreateId(),
                    Name = "Mabels's tasks",
                    Owner = GetUserByAppeal("Lil Gideon"),
                    CalendarType = TypeByName("Personal").Id,
                    Related = new[]
                    {
                        GetUserByAppeal("Lil Gideon")
                    }
                }
            };
            TypeByName("Personal").Calendars = personalCalendars.Select(x => x.Id);
            var birthdayCalendars = new[]
            {
                new Calendar()
                {
                    Id = CreateId(),
                    Name = "Birthdays",
                    Owner = GetUserByAppeal("Admin"),
                    CalendarType = TypeByName("Birthdays").Id,
                    Related = new[]
                    {
                        GetGroupByName("All")
                    }

                }
            };
            TypeByName("Birthdays").Calendars = birthdayCalendars.Select(x => x.Id);
            var adventureCalendars = new[]
             {
                new Calendar()
                {
                    Id = CreateId(),
                    Name = "Ford's Adventures",
                    Owner = GetUserByAppeal("Grunkle Ford"),
                    CalendarType = TypeByName("Adventures").Id,
                    Related= new Subject[]
                    {
                        GetGroupByName("Main characters"),
                        GetUserByAppeal("Waddles")
                    }
                }
            };
            TypeByName("Adventures").Calendars = adventureCalendars.Select(x => x.Id);
            _calendars = personalCalendars
                .Union(birthdayCalendars)
                .Union(adventureCalendars)
                .ToList();
            return this;
        }

        public Context Build()
            => new Context() 
        {
            Users=_users,
            Groups=_groupsAsTree,
            Comments=_comments,
            Events=_events,
            ReadRecords=_readRecords,
            CalendarTypes=_calendarTypes,
            Calendars = _calendars
        };
        
        private static string CreateId() => Guid.NewGuid().ToString();

        private void AddUser(Subjects.Group group, Subjects.User user)
        {
            if (user.Id == null) user.Id = CreateId();
            user.GroupId = group.Id;
            group.Users = group.Users.Union(new[] { user.Id }).ToList();
            _users.Add(user);
        }
        private void AddGroup(Subjects.Group parent, Subjects.Group group)
        {
            if (group.Id == null) group.Id = CreateId();
            group.ParentGroup = parent.Id;
            parent.Groups = parent.Groups.Union(new[] { group }).ToList();
            _groupsAsList.Add(group);
        }
        private Subjects.User GetUserByAppeal(string appeal) 
            => _users.Find(x => string.Equals(x.Appeal, appeal, StringComparison.InvariantCultureIgnoreCase));
        private Subjects.Group GetGroupByName(string name) => _groupsAsList.Find(x => x.Name == name);

        private CalendarType TypeByName(string name) => _calendarTypes.Find(x => x.Name == name);
    }

#endif
}
