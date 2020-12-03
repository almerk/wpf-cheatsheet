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
        public async Task SerilizeUsers_Success ()
        {
            var json = await data.GetServerJson<Event>();
            var objects = Deserialization.DeserializeObject<Event[]>(json, data);
        }

        [TestMethod]
        public async Task SerilizeOccurencies_Success()
        {
            var json = await data.GetServerJson<Occurence>();
        }
    }
}
