using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votr.Models;

namespace Votr.Tests.Models
{
    [TestClass]
    public class PollTests
    {
        [TestMethod]
        public void PollEnsureICanCreateInstance()
        {
            Poll p = new Poll();
            Assert.IsNotNull(p);
        }
    }
}
