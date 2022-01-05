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
    public class VideoController : Controller
    {
        private readonly IMaterialService<VideoMaterial> videoService;

        private readonly IMapper mapper;

        public VideoController(IMaterialService<VideoMaterial> videoService, IMapper mapper)
        {
            this.videoService = videoService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(VideoViewModel model)
        {
            var video = this.mapper.Map<VideoMaterial>(model);
            await this.videoService.CreateAsync(video);

            return this.Ok();
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IEnumerable<VideoViewModel>> GetAllAsync()
        {
            var videos = await this.videoService.GetAllMaterialsAsync();
            return this.mapper.Map<IEnumerable<VideoViewModel>>(videos);
        }
    }
}