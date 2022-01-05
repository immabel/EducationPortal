namespace EducationPortal.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;
    using EducationPortal.Core.Interfaces;

    public class SkillService : ISkillService
    {
        private readonly IRepository<Skill> skillRepository;

        public SkillService(IRepository<Skill> skillRepository)
        {
            this.skillRepository = skillRepository;
        }

        public async Task CreateAsync(string skillName)
        {
            Skill skill = new Skill
            {
                Name = skillName
            };

            await this.skillRepository.AddAsync(skill);
        }

        public async Task<IEnumerable<Skill>> GetAllSkillsAsync()
        {
            return await this.skillRepository.GetAllAsync();
        }
    }
}