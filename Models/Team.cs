using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace SportsOrganizer.Models
{
    public class Team
    {
        [Key]
        public int TeamId { get; set; }
        public string Name { get; set; }
        public string Captain { get; set; }
        public int DivisionId { get; set; }
        public virtual Division Division { get; set; }
        public virtual ICollection<Player> Players { get; set;}
    }
}
