namespace EducationPortal.Controllers
{
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;
    using EducationPortal.Core.Interfaces;
    using EducationPortal.ViewModels;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : Controller
    {
        private readonly IAuthService authService;

        public AuthController(IAuthService authService)
        {
            this.authService = authService;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> LoginAsync(LoginViewModel loginViewModel)
        {
            bool isAuthenticated = await this.authService.LoginAsync(loginViewModel.Email, loginViewModel.Password);
            if (isAuthenticated)
            {
                return this.Ok();
            }
            else
            {
                return this.NotFound();
            }
        }

        [AllowAnonymous]
        [HttpGet("example")]
        public IActionResult Example()
        {
            return Ok();
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> RegisterAsync(RegistrationViewModel registrationViewModel)
        {
            User user = new User
            {
                Email = registrationViewModel.Email,
                Name = registrationViewModel.Name,
                Surname = registrationViewModel.Surname,
                PasswordHash = registrationViewModel.Password,
                PhoneNumber = registrationViewModel.PhoneNumber,
                PlaceStudy = registrationViewModel.PlaceStudy,
                PlaceWork = registrationViewModel.PlaceWork
            };

            bool isAuthenticated = await this.authService.RegisterAsync(user);
            if (isAuthenticated)
            {
                return this.Ok();
            }
            else
            {
                return this.NotFound();
            }
        }
    }
}