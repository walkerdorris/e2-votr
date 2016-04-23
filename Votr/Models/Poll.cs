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
        public int PollId { get; set; }
        [MaxLength(500)]
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }
        //Need Options
        public virtual ICollection<Option> Options { get; set; }
        //Tag Relation
        //User Relation
        //Vote Relation
    }
}
