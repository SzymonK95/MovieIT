using HtmlAgilityPack;

namespace MovieITScrapper
{
    class CinemaMoviesModel
    {
        public CinemaMoviesModel(HtmlNode cinema, HtmlNode movies)
        {
            CinemaNode = cinema;
            MoviesNode = movies;
        }

        public HtmlNode CinemaNode { get; }
        public HtmlNode MoviesNode { get; }
    }
}
