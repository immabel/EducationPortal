namespace EducationPortal.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public class User : BaseEntity
    {
        public string Email { get; set; }

        public string PasswordHash { get; set; }

        public string Surname { get; set; }

        public string PhoneNumber { get; set; }

        public string PlaceStudy { get; set; }

        public string PlaceWork { get; set; }

        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        public List<UserCourse> UserCourses { get; set; }

        public List<Course> CreatedCourses { get; set; }

        public List<UserSkill> UserSkills { get; set; }

        public List<UserMaterial> UserMaterials { get; set; }
    }
}