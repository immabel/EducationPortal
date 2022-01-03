namespace EducationPortal.Infrastructure.Services
{
    using System;
    using System.Threading.Tasks;
    using System.Web.Helpers;
    using EducationPortal.Core.Entities;
    using EducationPortal.Core.Interfaces;

    public class AuthService : IAuthService
    {
        private readonly IRepository<User> userRepository;

        public AuthService(IRepository<User> userRepository)
        {
            this.userRepository = userRepository;
        }

        public async Task<bool> LoginAsync(string email, string password)
        {
            var expression = new ExpressionSpecification<User>(u => u.Email.Equals(email));
            User user = await this.userRepository.GetAsync(expression);
            if (user == null)
            {
                return false;
            }

            return Crypto.VerifyHashedPassword(user.PasswordHash, password);
        }

        public async Task<bool> RegisterAsync(User user)
        {
            string password = user.PasswordHash;
            user.PasswordHash = Crypto.HashPassword(user.PasswordHash);
            user.CreatedAt = user.ModifiedAt = DateTimeOffset.Now;
            await this.userRepository.AddAsync(user);

            return await this.LoginAsync(user.Email, password);
        }
    }
}