using StudyWPF.Calendario.DTO.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.Calendario.DTO.DevelopOnly
{
    //TODO: Move to tests, when client project will be ready
#if DEBUG
    public class TestContextBuilder
    {
        private List<Subjects.Group> _groupsAsList= new List<Subjects.Group>();
        private List<Subjects.User> _users = new List<Subjects.User>();
        private List<CalendarType> _calendarTypes = new List<CalendarType>();
        private List<Calendar> _calendars = new List<Calendar>();
        private List<Event> _events = new List<Event>();
        private List<Date> _dates = new List<Date>();
        private List<Comment> _comments = new List<Comment>();
        private List<ReadRecord> _readRecords = new List<ReadRecord>();
        private List<Occurence> _occurences = new List<Occurence>();

        public TestContextBuilder() 
        {
            
        }

        public TestContextBuilder WithGroupsAndUsers() 
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
            return this;
        }

        public TestContextBuilder WithCalendarTypes() 
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

        public TestContextBuilder WithCalendars() 
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

        public TestContextBuilder WithEventsAndOccurencies() 
        {
            var soosBD = new Event()
            {
                Id = CreateId(),
                CalendarId = CalendarByName("Birthdays").Id,
                Related = new[] { GetGroupByName("All") },
                Name = "Soos's birthday",
                Description = "No one should remind him of it",
                Dates = new[] { new Dates.SimpleDate() 
                {
                    Id = CreateId(),
                    HasTime = false,
                    Value = DateTime.Parse("13.07.2020") 
                } 
                },
            };
            _dates.AddRange(soosBD.Dates);
            var soosBDComments = new[]
            {
                new Comment()
                {
                    Id = CreateId(),
                    EventId = soosBD.Id,
                    Text = "But i still want to!",
                    UserId = GetUserByAppeal("Mabel").Id,
                    DateTime = DateTime.Parse("25.11.2020 12:00")
                },
                new Comment()
                {
                    Id = CreateId(),
                    EventId = soosBD.Id,
                    Text = "Me too",
                    UserId = GetUserByAppeal("Dipper").Id,
                    DateTime = DateTime.Parse("25.11.2020 13:45")
                }
            };
            soosBD.Comments = soosBDComments.Select(x => x.Id).ToList();
            _comments.AddRange(soosBDComments);
            _events.Add(soosBD);
            var soosBDOccurences = new[]
            {
                new Occurence()
                {
                    Date = new OccurenceDate()
                    {
                        Value = DateTime.Parse("13.07.2020"),
                        HasTime = false
                    },
                    EventId = soosBD.Id,
                    Status = EventStatus.Late
                },
                new Occurence()
                {
                    Date = new OccurenceDate()
                    {
                        Value = DateTime.Parse("14.07.2020"),
                        HasTime = false
                    },
                    EventId = soosBD.Id,
                    Status = EventStatus.Coming
                },
                new Occurence()
                {
                    Date = new OccurenceDate()
                    {
                        Value = DateTime.Parse("15.07.2020"),
                        HasTime = false
                    },
                    EventId = soosBD.Id,
                    Status = EventStatus.Done
                },
                new Occurence()
                {
                    Date = new OccurenceDate()
                    {
                        Value = DateTime.Parse("14.07.2020"),
                        HasTime = true
                    },
                    EventId = soosBD.Id,
                    Status = EventStatus.Archive
                }
            };
            _occurences.AddRange(soosBDOccurences);
            var soosBDReadRecords = new[]
            {
                new ReadRecord()
                {
                    Related = soosBDOccurences[0],
                    ByUser = GetUserByAppeal("Waddles").Id,
                    When = DateTime.Parse("12.07.2020 14:30")
                },
                new ReadRecord()
                {
                    Related = soosBDOccurences[0],
                    ByUser = GetUserByAppeal("Mabel").Id,
                    When = DateTime.Parse("12.07.2020 14:30")
                }
            };
            _readRecords.AddRange(soosBDReadRecords);
            return this;
            
        }

        public TestContextBuilder Full() => this
                .WithGroupsAndUsers()
                .WithCalendarTypes()
                .WithCalendars()
                .WithEventsAndOccurencies();

        public Context Build()
            => new Context() 
        {
            Users=_users,
            Groups=_groupsAsList,
            Comments=_comments,
            Events=_events,
            ReadRecords=_readRecords,
            CalendarTypes=_calendarTypes,
            Calendars = _calendars,
            Occurences = _occurences,
            Dates = _dates
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
            parent.Groups = parent.Groups.Union(new[] { group.Id }).ToList();
            _groupsAsList.Add(group);
        }
        private Subjects.User GetUserByAppeal(string appeal) 
            => _users.Find(x => string.Equals(x.Appeal, appeal, StringComparison.InvariantCultureIgnoreCase));
        private Subjects.Group GetGroupByName(string name) => _groupsAsList.Find(x => x.Name == name);
        private Calendar CalendarByName(string name) => _calendars.Find(x => x.Name == name);
        private CalendarType TypeByName(string name) => _calendarTypes.Find(x => x.Name == name);
    }

#endif
}
