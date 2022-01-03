namespace EducationPortal.Core.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public bool IsDeleted { get; set; }

        public string Name { get; set; }
    }
}