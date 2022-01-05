namespace EducationPortal.Controllers
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;
    using EducationPortal.Core.Interfaces;
    using EducationPortal.ViewModels;
    using global::AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class ArticleController : Controller
    {
        private readonly IMaterialService<ArticleMaterial> articleService;

        private readonly IMapper mapper;

        public ArticleController(IMaterialService<ArticleMaterial> articleService, IMapper mapper)
        {
            this.articleService = articleService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(ArticleViewModel model)
        {
            var articleMaterial = this.mapper.Map<ArticleMaterial>(model);
            await this.articleService.CreateAsync(articleMaterial);

            return this.Ok();
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IEnumerable<ArticleViewModel>> GetAllAsync()
        {
            var articles = await this.articleService.GetAllMaterialsAsync();
            return this.mapper.Map<IEnumerable<ArticleViewModel>>(articles);
        }
    }
}