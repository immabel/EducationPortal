using EducationPortal.Core.Enums;

namespace EducationPortal.Core.Entities
{
    public class UserCourse
    {
        public CourseStatus Status { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int CourseId { get; set; }

        public Course Course { get; set; }
    }
}