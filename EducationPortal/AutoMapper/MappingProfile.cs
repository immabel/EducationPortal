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
        }
    }
}