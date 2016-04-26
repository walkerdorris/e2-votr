using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votr.Models;
using Votr.DAL;
using System.Data.Entity;

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

        [TestMethod]
        public void PollEnsureICanSaveAPoll()
        {
            // Arrange
            VotrContext context = new VotrContext();
            Poll p = new Poll();

            // Act
            context.Polls.Add(p);
            context.SaveChanges();

            // Assert
            Assert.AreEqual(1, context.Polls.Find().PollId);



        }
    }
}
