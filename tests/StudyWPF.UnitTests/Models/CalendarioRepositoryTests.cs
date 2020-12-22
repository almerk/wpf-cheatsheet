using Microsoft.VisualStudio.TestTools.UnitTesting;
using StudyWPF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudyWPF.UnitTests.Models
{
    [TestClass]
    public class CalendarioRepositoryTests
    {
        [TestMethod]
        public async Task ContextCreate_Success()
        {
            var repo = await CalendarioRepository.CreateAndInitialize(new CalendarioServer());
            Assert.IsNotNull(repo.GetContext());
        }
    }
}
