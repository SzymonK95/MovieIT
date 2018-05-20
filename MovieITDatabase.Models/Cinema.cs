using System;

namespace MovieITDatabase.Models
{
    public class Cinema
    {
        public Guid CinemaGuid { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
