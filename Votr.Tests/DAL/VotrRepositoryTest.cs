using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Votr.DAL;
using System.Collections.Generic;
using Votr.Models;
using Moq;
using System.Linq;
using System.Data.Entity;

namespace Votr.Tests.DAL
{
    [TestClass]
    public class VotrRepositoryTest
    {
        List<Poll> datasource { get; set; }
        Mock<VotrContext> mock_context { get; set; }
        Mock<DbSet<Poll>> mock_polls_table { get; set; } // Fake Polls table
        VotrRepository repo { get; set; } // Injects mocked (fake) VotrContext
        IQueryable<Poll> data { get; set; }// Turns List<Poll> into something we can query with LINQ

        [TestInitialize]
        public void Initialize()
        {
            datasource = new List<Poll>();
            mock_context = new Mock<VotrContext>();
            mock_polls_table = new Mock<DbSet<Poll>>(); // Fake Polls table

            repo = new VotrRepository(mock_context.Object); // Injects mocked (fake) VotrContext
            data = datasource.AsQueryable(); // Turns List<Poll> into something we can query with LINQ
        }

        [TestCleanup]
        public void Cleanup()
        {
            datasource = null;
        }

        void ConnectMocksToDatastore() // Utility method
        {
            // Telling our fake DbSet to use our datasource like something Queryable
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.Expression).Returns(data.Expression);
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.Provider).Returns(data.Provider);

            // Tell our mocked VotrContext to use our fully mocked Datasource. (List<Poll>)
            mock_context.Setup(m => m.Polls).Returns(mock_polls_table.Object);
        }

        [TestMethod]
        public void RepoEnsureICanCreateInstance()
        {
            //VotrRepository repo = new VotrRepository();
            Assert.IsNotNull(repo);
        }

        [TestMethod]
        public void RepoEnsureIsUsingContext()
        {
            // Arrange 
            //VotrRepository repo = new VotrRepository();

            // Act

            // Assert
            Assert.IsNotNull(repo.context);
        }

        [TestMethod]
        public void RepoEnsureThereAreNoPolls()
        {
            // Arrange 
            ConnectMocksToDatastore();

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
