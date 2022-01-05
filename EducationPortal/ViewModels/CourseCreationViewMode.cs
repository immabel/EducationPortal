namespace EducationPortal.ViewModels
{
    using System.Collections.Generic;

    public class CourseCreationViewMode
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }

        public List<int> Skills { get; set; }

        public List<int> BookMaterials { get; set; }

        public List<int> ArticleMaterials { get; set; }

        public List<int> VideoMaterials { get; set; }
    }
}