using System;

namespace MovieITScrapper
{
    public class Movie
    {
        public Movie(string name, DateTime time, int minimumAge)
        {
            MovieName = name;
            PlayMovie = time;
            MinimumAge = minimumAge;
        }

        public string MovieName { get; }
        public DateTime PlayMovie { get; }
        public int MinimumAge { get; }

        public override string ToString()
        {
            return MovieName + " " + PlayMovie;
        }
    }
}
