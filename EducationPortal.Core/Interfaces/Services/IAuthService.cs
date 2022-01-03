namespace EducationPortal.Core.Interfaces
{
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;

    public interface IAuthService
    {
        Task<bool> LoginAsync(string email, string password);

        Task<bool> RegisterAsync(User user);
    }
}