namespace EducationPortal.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class BookMaterial : Material
    {
        public string Format { get; set; }

        public DateTime YearOfPublishing { get; set; }

        public int PagesCount { get; set; }

        public List<Author> Authors { get; set; }
    }
}