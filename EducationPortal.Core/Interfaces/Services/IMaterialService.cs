namespace EducationPortal.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;

    public interface IMaterialService<T>
        where T : Material
    {
        Task CreateAsync(T material);

        Task<IEnumerable<T>> GetMaterialsForCourseAsync(int courseId);

        Task<IEnumerable<T>> GetAllMaterialsAsync(ExpressionSpecification<T> expression = default);
    }
}