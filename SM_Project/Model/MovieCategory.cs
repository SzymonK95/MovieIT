using System;

namespace SM_Project.Model
{
    public partial class MovieCategory
    {
        public Guid MovieCategoryGuid { get; set; }
        public Guid? CategoryGuid { get; set; }
        public Guid? MovieGuid { get; set; }

        public Category CategoryGu { get; set; }
        public Movie MovieGu { get; set; }
    }
}
