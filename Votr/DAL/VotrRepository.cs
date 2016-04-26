using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Votr.Models;

namespace Votr.DAL
{
    public class VotrRepository
    {
        public VotrContext context { get; set; }

        public VotrRepository()
        {
            // We need an instance of a Context
            context = new VotrContext();
        }

        public int GetPollCount()
        {
            //return GetPolls().Count;
            // Another way
            return context.Polls.Count();
        }

        public List<Poll> GetPolls()
        {
            return context.Polls.ToList<Poll>();
        }

        public void AddPoll(string title, DateTime start_time, DateTime end_time)
        {
            throw new NotImplementedException();
        }
        // Create a Poll

        // Delete a Poll

        // Vote
    }
}