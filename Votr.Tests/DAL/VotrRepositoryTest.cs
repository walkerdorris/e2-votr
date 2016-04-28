﻿using System;
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
        [TestInitialize]
        public void Initialize()
        {

        }

        [TestCleanup]
        public void Cleanup()
        {

        }

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
            //Mocking
            List<Poll> datasource = new List<Poll>();
            Mock<VotrContext> mock_context = new Mock<VotrContext>();
            Mock<DbSet<Poll>> mock_polls_table = new Mock<DbSet<Poll>>(); //Fake Polls table            

            // Arrange 
            VotrRepository repo = new VotrRepository(mock_context.Object); // Injects mocked (fake) VotrContext
            //IQueryable<Poll> data = datasource.AsQueryable(); //Turn List<Poll> into something we can query with LINQ
            var data = datasource.AsQueryable(); // This is cool too. Casting (too)

            // Telling our fake DbSet to use our datasource like something Queryable
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.GetEnumerator()).Returns(data.GetEnumerator());
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.ElementType).Returns(data.ElementType);
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.Expression).Returns(data.Expression);
            mock_polls_table.As<IQueryable<Poll>>().Setup(m => m.Provider).Returns(data.Provider);

            // Tell our mocked VotrContext to use our fully mocked Datasource. (List<Poll>)
            mock_context.Setup(m => m.Polls).Returns(mock_polls_table.Object);
            
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
