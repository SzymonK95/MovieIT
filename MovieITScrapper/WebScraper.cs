using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace MovieITScrapper
{
    public class WebScraper
    {
        private readonly string _url;

        public WebScraper(string url)
        {
            _url = url;
        }

        public List<Repertuar> GetResults()
        {
            HtmlDocument document = GetHtmlDocument();
            HtmlNode articleNode = document.DocumentNode.SelectNodes("//article").FirstOrDefault();

            if(articleNode == null)
                throw new ArgumentException("Document does not contains article");

            List<HtmlNode> interesandNodes = GetInteresantNodes(articleNode);

            List<CinemaMoviesModel> cinemaMoviesModels = GetCinemaMoviesModels(interesandNodes);

            List<Repertuar> repertuars = GetRepertuars(cinemaMoviesModels);

            return repertuars;
        }

        private List<Repertuar> GetRepertuars(List<CinemaMoviesModel> cinemaMoviesModels)
        {
            List<Repertuar> repertuars = new List<Repertuar>();

            foreach (CinemaMoviesModel cinMov in cinemaMoviesModels)
            {
                Cinema cinema = GetCinema(cinMov.CinemaNode);
                List<Movie> movies = GetMovies(cinMov.MoviesNode);

                repertuars.Add(new Repertuar(cinema, movies));
            }

            return repertuars;
        }

        private List<CinemaMoviesModel> GetCinemaMoviesModels(List<HtmlNode> interesandNodes)
        {
            List<CinemaMoviesModel> cinemaMovies = new List<CinemaMoviesModel>();

            for (int i = 0; i < interesandNodes.Count - 1; i = i + 2)
            {
                cinemaMovies.Add(new CinemaMoviesModel(interesandNodes.ElementAt(i), interesandNodes.ElementAt(i + 1)));
            }

            return cinemaMovies;
        }

        private static List<HtmlNode> GetInteresantNodes(HtmlNode articleNode)
        {
            return articleNode.ChildNodes.Where(c => c.Name == "h3" || c.Name == "ul")
                .ToList();
        }

        private HtmlDocument GetHtmlDocument()
        {
            HtmlWeb web = new HtmlWeb();
            HtmlDocument htmlDoc = web.Load(_url);
            return htmlDoc;
        }

        private List<Movie> GetMovies(HtmlNode cinMovMoviesNode)
        {
            List<Movie> listofMovies = new List<Movie>();
            IEnumerable<HtmlNode> movies = cinMovMoviesNode.ChildNodes.Where(c => c.Name == "li");
            foreach (HtmlNode movie in movies)
            {
                List<HtmlNode> attributes = movie.ChildNodes.Where(n => n.Name == "div").ToList();

                string startDate = RemoveUnrelevantNewLine(attributes.ElementAt(0).InnerText);
                string startHour = RemoveUnrelevantNewLine(attributes.ElementAt(1).InnerText);
                string name = RemoveUnrelevantNewLine(attributes.ElementAt(2).InnerText);
                string age = RemoveUnrelevantNewLine(attributes.ElementAt(3).InnerText);

                Int32.TryParse(age, out int result);

                listofMovies.Add(new Movie(name, DateTime.Parse(startDate + "t" + startHour), result));
            }

            return listofMovies;
        }

        private Cinema GetCinema(HtmlNode cinMovCinemaNode)
        {
            string cinemaName = cinMovCinemaNode.InnerText.Replace(@"\n", String.Empty);
            string replacement = RemoveUnrelevantNewLine(cinemaName);
            return new Cinema(Guid.NewGuid(), replacement);
        }

        private string RemoveUnrelevantNewLine(string input)
        {
            Match regexMath = Regex.Match(input, @"\n");

            if (regexMath.Length % 2 == 0)
                return Regex.Replace(input, @"\t|\n|\r", "");

            string[] splitted = input.Split('\n');
            return splitted[1];
        }
    }
}
