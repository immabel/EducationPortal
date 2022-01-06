﻿namespace EducationPortal.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq.Expressions;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;
    using EducationPortal.Core.Interfaces;
    using EducationPortal.ViewModels;
    using global::AutoMapper;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Mvc;

    [ApiController]
    [Route("api/[controller]")]
    public class BookController : Controller
    {
        private readonly IMaterialService<BookMaterial> bookService;

        private readonly IMapper mapper;

        public BookController(IMaterialService<BookMaterial> bookService, IMapper mapper)
        {
            this.bookService = bookService;
            this.mapper = mapper;
        }

        [AllowAnonymous]
        [HttpPost("create")]
        public async Task<IActionResult> CreateAsync(BookViewModel model)
        {
            var book = this.mapper.Map<BookMaterial>(model);
            await this.bookService.CreateAsync(book);

            return this.Ok();
        }

        [AllowAnonymous]
        [HttpGet("getAll")]
        public async Task<IEnumerable<BookViewModel>> GetAllAsync()
        {
            var includes = new List<Expression<Func<BookMaterial, object>>>
            {
                b => b.Authors
            };
            var expression = new ExpressionSpecification<BookMaterial>(null, includes);

            var books = await this.bookService.GetAllMaterialsAsync(expression);
            return this.mapper.Map<IEnumerable<BookViewModel>>(books);
        }
    }
}