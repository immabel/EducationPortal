namespace EducationPortal.Core.Entities
{
    using System.Collections.Generic;

    public class Author
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public List<BookMaterial> BookMaterials { get; set; }
    }
}