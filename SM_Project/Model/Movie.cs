using System;
using System.Collections.Generic;

namespace SM_Project.Model
{
    public partial class Movie
    {
        public Movie()
        {
            MovieCategory = new HashSet<MovieCategory>();
            Reminder = new HashSet<Reminder>();
            Seance = new HashSet<Seance>();
        }

        public Guid MovieGuid { get; set; }
        public string Title { get; set; }
        public Guid? DirectorGuid { get; set; }
        public DateTime? FirstNight { get; set; }
        public string Url { get; set; }

        public Director DirectorGu { get; set; }
        public ICollection<MovieCategory> MovieCategory { get; set; }
        public ICollection<Reminder> Reminder { get; set; }
        public ICollection<Seance> Seance { get; set; }
    }
}
