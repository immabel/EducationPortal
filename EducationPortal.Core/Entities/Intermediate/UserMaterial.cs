namespace EducationPortal.Core.Entities
{
    public class UserMaterial
    {
        public bool IsPassed { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public int MaterialId { get; set; }

        public Material Material { get; set; }
    }
}