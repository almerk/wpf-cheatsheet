using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyWPF.Calendario.DTO.DevelopOnly;

namespace StudyWPF.UnitTests.Calendario.DTO
{
#if DEBUG
    [TestClass]
    public class ContextBuilderTests
    {
        [TestMethod]
        public void UserTree_ContainsWaddles()
        {
            var context = new TestContextBuilder().WithGroupsAndUsers().Build();
            Assert.IsNotNull(context.Users.FirstOrDefault(x => x.Appeal == "Waddles"));
        }
        [TestMethod]
        public void GroupTree_IsCreated()
        {
            var context = new TestContextBuilder().WithGroupsAndUsers().Build();
            var allGroup = context.Groups.First();
            Assert.IsNotNull(allGroup);
            Assert.AreEqual(3, allGroup.Groups.Count());        
        }
        [TestMethod]
        public void Calendars_Created()
        {
            var context = new TestContextBuilder()
                .WithGroupsAndUsers()
                .WithCalendarTypes()
                .WithCalendars()
                .Build();
            Assert.AreEqual(5, context.Calendars.Count());
            Assert.AreEqual(3, context.CalendarTypes.Count());
        }
        [TestMethod]
        public void Events_Exist()
        {
            var context = new TestContextBuilder().Full().Build();
            Assert.IsTrue(context.Events.Any());
        }
    }
#endif
}
