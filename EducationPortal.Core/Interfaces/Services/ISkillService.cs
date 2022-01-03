namespace EducationPortal.Core.Interfaces.Services
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;

    public interface ISkillService
    {
        Task CreateAsync(string skillName);

        Task<IEnumerable<Skill>> GetAllSkillsAsync();
    }
}