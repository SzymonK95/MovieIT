using System.Collections.Generic;

namespace MovieITDatabase.DatabaseProvider
{
    public interface IDatabaseProvider
    {
        void AddMovie(Movie movie);
        void AddSeance(Seance seance);
        void AddCinema(Cinema cinema);
        void AddDirector(Director director);
        List<MovieITDatabase.Models.Movie> GetMovies();
        List<MovieITDatabase.Models.Cinema> GetCinemas();
        List<MovieITDatabase.Models.Seance> GetSeances();
    }
}
