namespace EducationPortal.ViewModels
{
    using System;

    public class ArticleViewModel : MaterialViewModel
    {
        public DateTimeOffset DateOfPublishing { get; set; }

        public string ResourceLocation { get; set; }
    }
}