namespace EducationPortal.Core.Interfaces
{
    public interface IPasswordHasher
    {
        string HashPassword(string password);

        bool VerifyHashedPassword(string hashedPassword, string providedPassword);
    }
}