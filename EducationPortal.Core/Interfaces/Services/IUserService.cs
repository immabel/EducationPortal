namespace EducationPortal.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;

    public interface IUserService
    {
        Task<User> GetProfileInformationAsync(int userId);

        Task<IEnumerable<Course>> GetCoursesAsync(int userId);

        Task UpdateInformationAsync(User user);

        Task PassMaterialAsync(int userId, int materialId);

        Task PassCourseAsync(int userId, int courseId);

        Task StartCourseAsync(int userId, int courseId);
    }
}