namespace EducationPortal.AutoMapper
{
    using EducationPortal.Core.Entities;
    using EducationPortal.ViewModels;
    using global::AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Skill, SkillViewModel>().ReverseMap();
            this.CreateMap<ArticleMaterial, ArticleViewModel>().ReverseMap();
            this.CreateMap<VideoMaterial, VideoViewModel>().ReverseMap();
            this.CreateMap<Author, AuthorViewModel>().ReverseMap();
            this.CreateMap<BookMaterial, BookViewModel>().ReverseMap();
            this.CreateMap<Material, MaterialViewModel>().ReverseMap();
            this.CreateMap<Course, CourseViewModel>().ReverseMap();
            this.CreateMap<Course, CourseCreationViewMode>().ReverseMap();
        }
    }
}