using EducationPortal.Core.Entities;
using EducationPortal.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace EducationPortal.Infrastructure.Services
{
    public class CourseService : ICourseService
    {
        private readonly IRepository<Course> courseRepository;

        public CourseService(IRepository<Course> courseRepository)
        {
            this.courseRepository = courseRepository;
        }

        //not finished
        public async Task CreateAsync(Course course)
        {
            course.CreatedAt = course.ModifiedAt = DateTimeOffset.Now;

            await this.courseRepository.AddAsync(course);
        }

        public async Task<IEnumerable<Course>> GetAllCoursesAsync() => await this.courseRepository.GetAllAsync();

        public async Task<Course> GetCourseInformationAsync(int courseId) => await this.courseRepository.GetByIdAsync(courseId);

        public async Task<IEnumerable<Skill>> GetSkillsAsync(int courseId)
        {
            var includes = new List<Expression<Func<Course, object>>>
                {
                    c => c.Skills
                };
            var expression = new ExpressionSpecification<Course>(c => c.Id == courseId, includes);
            var course = await this.courseRepository.GetAsync(expression);

            return course.Skills;
        }

        public async Task UpdateInformationAsync(Course course) => await this.courseRepository.UpdateAsync(course);
    }
}