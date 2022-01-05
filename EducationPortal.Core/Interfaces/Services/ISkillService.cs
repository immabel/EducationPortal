namespace EducationPortal.Core.Interfaces
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