using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyWPF.Calendario.DTO;
using StudyWPF.Calendario.DTO.Subjects;
using StudyWPF.Calendario.DTO.DevelopOnly;
using System.Threading.Tasks;

namespace StudyWPF.UnitTests.Calendario.DTO
{
    [TestClass]
    public class SerializationTests
    {
        public static TestData data = new TestData();
        [TestMethod]
        public async Task SerilizeUsers_Success ()
        {
            var json = await data.GetData<Group>();
        }

        [TestMethod]
        public async Task SerilizeOccurencies_Success()
        {
            var json = await data.GetData<Occurence>();
        }
    }
}
