namespace EducationPortal.Core.Entities
{
    using System.Collections.Generic;

    public class Skill : BaseEntity
    {
        public List<Course> Courses { get; set; }

        public List<UserSkill> UserSkills { get; set; }
    }
}