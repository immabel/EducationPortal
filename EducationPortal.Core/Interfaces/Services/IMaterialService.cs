namespace EducationPortal.Core.Interfaces.Services
{
    using EducationPortal.Core.Entities;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public interface IMaterialService<T>
        where T : Material
    {
        Task CreateAsync(int courseId, T material);

        Task<IEnumerable<T>> GetMaterialsAsync(int courseId);

        Task<IEnumerable<T>> GetAllMaterialsAsync();
    }
}