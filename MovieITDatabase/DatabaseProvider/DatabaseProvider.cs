using System.Collections.Generic;
using System.Linq;

namespace MovieITDatabase.DatabaseProvider
{
    public class DatabaseProvider : IDatabaseProvider
    {
        public void AddMovie(Movie movie)
        {
            using (MovieITEntities context = new MovieITEntities())
            {
                Movie existingMovie = context.Movies.FirstOrDefault(m => m.MovieGuid == movie.MovieGuid);

                if (existingMovie == null)
                    context.Movies.Add(movie);

                context.SaveChanges();
            }
        }

        public void AddSeance(Seance seance)
        {
            using (MovieITEntities context = new MovieITEntities())
            {
                Seance existingSeance = context.Seances.FirstOrDefault(s => s.SeanceGuid == seance.SeanceGuid);

                if (existingSeance == null)
                    context.Seances.Add(seance);

                context.SaveChanges();
            }
        }

        public void AddCinema(Cinema cinema)
        {
            using (MovieITEntities context = new MovieITEntities())
            {
                Cinema existingCinema = context.Cinemas.FirstOrDefault(c => c.CinemaGuid == cinema.CinemaGuid);

                if (existingCinema == null)
                    context.Cinemas.Add(cinema);

                context.SaveChanges();
            }
        }

        public void AddDirector(Director director)
        {
            using (MovieITEntities context = new MovieITEntities())
            {
                Director existingDirector =
                    context.Directors.FirstOrDefault(c => c.DirectorGuid == director.DirectorGuid);

                if (existingDirector == null)
                    context.Directors.Add(director);

                context.SaveChanges();
            }
        }

        public List<Models.Movie> GetMovies()
        {
            using (MovieITEntities context = new MovieITEntities())
            {
                return context.Movies.Select(_ => new Models.Movie
                {
                    DirectorGuid = _.DirectorGuid,
                    FirstNight = _.FirstNight,
                    MovieGuid = _.MovieGuid,
                    Title = _.Title,
                    URL = _.URL
                }).ToList();
            }
        }

        public List<Models.Cinema> GetCinemas()
        {
            using (MovieITEntities context = new MovieITEntities())
            {
                return context.Cinemas.Select(_ => new Models.Cinema
                {
                    CinemaGuid = _.CinemaGuid,
                    Name = _.Name,
                    Url = _.URL
                }).ToList();
            }
        }

        public List<MovieITDatabase.Models.Seance> GetSeances()
        {
            using (MovieITEntities context = new MovieITEntities())
            {
                return context.Seances.ToList();
            }
        }
    }
}
