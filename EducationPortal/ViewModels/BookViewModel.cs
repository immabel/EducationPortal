namespace EducationPortal.ViewModels
{
    using System;
    using System.Collections.Generic;

    public class BookViewModel : MaterialViewModel
    {
        public string Format { get; set; }

        public DateTime YearOfPublishing { get; set; }

        public int PagesCount { get; set; }

        public List<AuthorViewModel> Authors { get; set; }
    }
}