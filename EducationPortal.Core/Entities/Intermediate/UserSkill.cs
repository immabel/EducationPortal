namespace EducationPortal.Core.Entities
{
    public class UserSkill
    {
        public int Level { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int SkillId { get; set; }

        public Skill Skill { get; set; }
    }
}