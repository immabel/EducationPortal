namespace EducationPortal.ViewModels
{
    using System.Collections.Generic;

    public class BookViewModel : MaterialViewModel
    {
        public string Format { get; set; }

        public string YearOfPublishing { get; set; }

        public int PagesCount { get; set; }

        public List<string> AuthorsNames { get; set; }
    }
}