namespace EducationPortal.Core.Entities
{
    using System;
    using System.Collections.Generic;
    using EducationPortal.Core.Enums;

    public class CourseViewModel
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        public string CreatorName { get; set; }

        public List<string> Skills { get; set; }

        public CourseStatus Status { get; set; }
    }
}