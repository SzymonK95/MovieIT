using System;

namespace MovieITScrapper
{
    public class Cinema
    {
        public Cinema(Guid cinemaGuid, string name)
        {
            CinemaGuid = cinemaGuid;
            Name = name;
        }

        public Guid CinemaGuid { get; }
        public string Name { get; }

        public override string ToString()
        {
            return Name;
        }
    }
}
