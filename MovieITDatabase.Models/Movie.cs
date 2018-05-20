using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieITDatabase.Models
{
    public class Movie
    {
        public System.Guid MovieGuid { get; set; }
        public string Title { get; set; }
        public Nullable<System.Guid> DirectorGuid { get; set; }
        public Nullable<System.DateTime> FirstNight { get; set; }
        public string URL { get; set; }
    }
}
