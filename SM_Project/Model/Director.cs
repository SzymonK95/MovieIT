using System;
using System.Collections.Generic;

namespace SM_Project.Model
{
    public partial class Director
    {
        public Director()
        {
            Movie = new HashSet<Movie>();
        }

        public Guid DirectorGuid { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Movie> Movie { get; set; }
    }
}
