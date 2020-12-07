using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyWPF.Calendario.DTO;
using StudyWPF.Calendario.DTO.Subjects;
using StudyWPF.Calendario.DTO.DevelopOnly;
using StudyWPF.Calendario.DTO.Utils;
using System.Threading.Tasks;

namespace StudyWPF.UnitTests.Calendario.DTO
{
    [TestClass]
    public class SerializationTests
    {
        public static TestRepository data = new TestRepository();
        [TestMethod]
        public async Task SerilizeEvents_Success ()
        {
            var json = await data.GetJsonEnties<Event>();
            var objects = Deserialization.DeserializeObject<Event[]>(json, data);
        }

        [TestMethod]
        public async Task SerilizeOccurencies_Success()
        {
            var json = await data.GetJsonEnties<Occurence>();
        }

        [TestMethod]
        public async Task SerilizeDates_Success()
        {
            var json = await data.GetJsonEnties<Date>();
            var objects = Deserialization.DeserializeObject<Date[]>(json, data);
        }
    }
}
