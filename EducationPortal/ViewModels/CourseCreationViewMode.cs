namespace EducationPortal.ViewModels
{
    using System.Collections.Generic;

    public class CourseCreationViewMode
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public int CreatorId { get; set; }

        public List<SkillViewModel> Skills { get; set; }

        public List<MaterialViewModel> Materials { get; set; }

        // may change
        /*public List<BookViewModel> BookMaterials { get; set; }

        public List<ArticleViewModel> ArticleMaterials { get; set; }

        public List<VideoViewModel> VideoMaterials { get; set; }*/
    }
}