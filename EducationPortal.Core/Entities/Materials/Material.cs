namespace EducationPortal.Core.Entities
{
    using System;
    using System.Collections.Generic;

    public abstract class Material : BaseEntity
    {
        public DateTimeOffset CreatedAt { get; set; }

        public DateTimeOffset ModifiedAt { get; set; }

        public List<Course> Courses { get; set; }

        public List<UserMaterial> UserMaterials { get; set; }
    }
}