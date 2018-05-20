using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieITDatabase.Models
{
    public class Seance
    {
        public Guid SeanceGuid { get; set; }
        public Guid MovieGuid { get; set; }
        public Guid CinemaGuid { get; set; }
        public DateTime ShowDate { get; set; }
    }
}
