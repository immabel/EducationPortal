namespace EducationPortal.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class Course : BaseEntity
    {
        public string Description { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        public int CreatorId { get; set; }

        public User Creator { get; set; }

        public List<Skill> Skills { get; set; }

        public List<Material> Materials { get; set; }

        public List<UserCourse> UserCourses { get; set; }
    }
}