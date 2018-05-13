using System;

namespace SM_Project.Model
{
    public partial class Seance
    {
        public Guid SeanceGuid { get; set; }
        public Guid? MovieGuid { get; set; }
        public Guid? CinemaGuid { get; set; }
        public DateTime? ShowDate { get; set; }

        public Cinema CinemaGu { get; set; }
        public Movie MovieGu { get; set; }
    }
}
