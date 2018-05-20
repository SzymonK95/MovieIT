using System;
using System.Collections.Generic;

namespace MovieITScrapper
{
    class Program
    {
        private readonly string _url = "http://www.poznan.pl/mim/events/seances/";
        private WebScraper _scraper;

        static void Main(string[] args)
        {
            new Program().Start();
            Console.ReadLine();
        }

        private void Start()
        {
            _scraper = new WebScraper(_url);

            List<Repertuar> results = _scraper.GetResults();
        }
    }
}
