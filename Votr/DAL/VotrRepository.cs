using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Votr.DAL
{
    public class VotrRepository
    {
        public VotrContext context { get; set; }

        public VotrRepository()
        {
            //We need an instance of a Context
            context = new VotrContext();
        }

        public void AddPoll(string title, DateTime start_time, DateTime end_time);
        //Create a Poll

        public List<Poll> GetPolls()
            {
            return ContextBoundObject.Polls.ToList<Poll>();
            }

        //Delete a Poll

        //Vote
    }
}