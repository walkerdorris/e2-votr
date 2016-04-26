using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votr.DAL;
using System.Collections.Generic;
using Votr.Models;

namespace Votr.Tests.DAL
{
    [TestClass]
    public class VotrRepositoryTest
    {
        [TestMethod]
        public void RepoEnsureICanCreateInstance()
        {
            VotrRepository repo = new VotrRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureIsUsingContext()
        {
            // Arrange 
            VotrRepository repo = new VotrRepository();

            // Act

            // Assert
            Assert.IsNotNull(repo.context);
        }

        [TestMethod]
        public void RepoEnsureThereAreNoPolls()
        {
            // Arrange 
            VotrRepository repo = new VotrRepository();

            // Act
            List<Poll> list_of_polls = repo.GetPolls();
            List<Poll> expected = new List<Poll>();

            // Assert
            Assert.AreEqual(expected.Count, list_of_polls.Count);
        }

        [TestMethod]
        public void RepoEnsurePollCountIsZero()
        {
            // Arrange 
            VotrRepository repo = new VotrRepository();

            // Act
            int expected = 0;
            int actual = repo.GetPollCount();

            // Assert
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void RepoEnsureICanAddPoll()
        {
            // Arrange
            VotrRepository repo = new VotrRepository();

            // Act
            repo.AddPoll("Some Title", DateTime.Now, DateTime.Now); // Not there yet.
            int actual = repo.GetPollCount(); 
            int expected = 1;

            // Assert
            Assert.AreEqual(expected, actual);
        }
    }
}
