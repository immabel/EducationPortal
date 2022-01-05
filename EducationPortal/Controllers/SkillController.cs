namespace EducationPortal.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Interfaces;
    using EducationPortal.ViewModels;
    using global::AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class SkillController : Controller
    {
        private readonly ISkillService skillService;

        private readonly IMapper mapper;

        public SkillController(ISkillService skillService, IMapper mapper)
        {
            this.skillService = skillService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(SkillViewModel model)
        {
            try
            {
                await this.skillService.CreateAsync(model.Name);
            }
            catch
            {
                return this.BadRequest();
            }

            return this.Ok();
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IEnumerable<SkillViewModel>> GetAllAsync()
        {
            var skills = await this.skillService.GetAllSkillsAsync();
            return this.mapper.Map<IEnumerable<SkillViewModel>>(skills);
        }
    }
}