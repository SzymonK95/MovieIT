using System;
using System.Collections.Generic;

namespace SM_Project.Model
{
    public partial class Category
    {
        public Category()
        {
            MovieCategory = new HashSet<MovieCategory>();
        }

        public Guid CategoryGuid { get; set; }
        public string Name { get; set; }

        public ICollection<MovieCategory> MovieCategory { get; set; }
    }
}
