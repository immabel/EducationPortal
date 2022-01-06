﻿namespace EducationPortal.Core.Interfaces
{
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;

    public interface ICourseService
    {
        Task CreateAsync(Course course);

        Task<Course> GetCourseInformationAsync(int courseId);

        Task<IEnumerable<Course>> GetAllCoursesAsync();

        Task UpdateInformationAsync(Course course);

        Task<IEnumerable<Skill>> GetSkillsAsync(int courseId);
    }
}