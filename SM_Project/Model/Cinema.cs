using System;
using System.Collections.Generic;

namespace SM_Project.Model
{
    public partial class Cinema
    {
        public Cinema()
        {
            Seance = new HashSet<Seance>();
        }

        public Guid CinemaGuid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public ICollection<Seance> Seance { get; set; }
    }
}
