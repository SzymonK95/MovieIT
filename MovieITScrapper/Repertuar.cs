using System.Collections.Generic;

namespace MovieITScrapper
{
    public class Repertuar
    {
        public Repertuar(Cinema cinema, List<Movie> movies)
        {
            Cinema = cinema;
            Movies = movies;
        }

        public Cinema Cinema { get; }
        public List<Movie> Movies { get; }
    }
}
