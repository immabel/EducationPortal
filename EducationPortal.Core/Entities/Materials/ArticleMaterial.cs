namespace EducationPortal.Core.Entities
{
    using System;

    public class ArticleMaterial : Material
    {
        public DateTimeOffset DateOfPublishing { get; set; }

        public string ResourseLocation { get; set; }
    }
}