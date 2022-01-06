using AutoMapper;
using EducationPortal.Core.Entities;
using EducationPortal.Core.Interfaces;
using EducationPortal.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EducationPortal.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CourseController : Controller
    {
        private readonly ICourseService courseService;

        private readonly IMaterialService<Material> materialService;

        private readonly IMapper mapper;

        public CourseController(ICourseService courseService, IMaterialService<Material> materialService, IMapper mapper)
        {
            this.courseService = courseService;
            this.materialService = materialService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(CourseCreationViewMode model)
        {
            var course = this.mapper.Map<Course>(model);

            await this.courseService.CreateAsync(course);

            return this.Ok();
        }
    }
}