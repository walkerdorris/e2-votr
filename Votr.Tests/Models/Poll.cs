using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Votr.Models
{
    public class Poll
    {
        int PollId { get; set; }
        [MaxLength(500)]
        [Required]
        string Title { get; set; }

        [Required]
        DateTime StartDate { get; set; }

        [Required]
        DateTime EndDate { get; set; }
        //Need Options
        public virtual ICollection<Option> Options { get; set; }
        //Tag Relation
        //User Relation
        //Vote Relation
    }
}
