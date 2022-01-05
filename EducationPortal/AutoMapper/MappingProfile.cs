namespace EducationPortal.AutoMapper
{
    using EducationPortal.Core.Entities;
    using EducationPortal.ViewModels;
    using global::AutoMapper;

    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            this.CreateMap<Skill, UserSkillViewModel>().ReverseMap();
        }
    }
}