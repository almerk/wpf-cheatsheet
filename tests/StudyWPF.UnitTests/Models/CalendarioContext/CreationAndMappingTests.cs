using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StudyWPF.Models;
using AutoMapper;
using StudyWPF.Calendario.DTO.Client;

namespace StudyWPF.UnitTests.Models.CalendarioContext
{
    [TestClass]
    public class CreationAndMappingTests
    {
        StudyWPF.Calendario.DTO.Client.Context _dtoContext = new StudyWPF.Calendario.DTO.DevelopOnly.TestContextBuilder().Full().Build();

        [TestMethod]
        public void MappingConfiguration_IsValid() 
        {
            var configuration = new MapperConfiguration(cfg =>
               cfg.CreateMap<Context, StudyWPF.Models.CalendarioContext>());
            configuration.AssertConfigurationIsValid();
        }


        //[TestMethod]
        //public void MappedEntitiesCount_Match()
        //{
        //    var context = StudyWPF.Models.CalendarioContext.Create(_dtoContext);
        //    Assert.AreEqual(_dtoContext.Users.Count, context.Users.Count);
        //    Assert.AreEqual(_dtoContext.Groups.Count, context.Groups.Count);
        //    Assert.AreEqual(_dtoContext.Occurences.Count, context.Occurences.Count);
        //    Assert.AreEqual(_dtoContext.ReadRecords.Count, context.ReadRecords.Count);
        //    Assert.AreEqual(_dtoContext.Dates.Count, context.Dates.Count);
        //    Assert.AreEqual(_dtoContext.Calendars.Count, context.Calendars.Count);
        //    Assert.AreEqual(_dtoContext.CalendarTypes.Count, context.CalendarTypes.Count);
        //    Assert.AreEqual(_dtoContext.Events.Count, context.Events.Count);
        //    Assert.AreEqual(_dtoContext.Comments.Count, context.Comments.Count);
        //}


    }
}
