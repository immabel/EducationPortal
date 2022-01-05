namespace EducationPortal.Infrastructure.Services
{
    using System;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using EducationPortal.Core.Entities;
    using EducationPortal.Core.Interfaces;

    public class MaterialService<T> : IMaterialService<T>
        where T : Material
    {
        private readonly IRepository<T> materialRepository;

        public MaterialService(IRepository<T> materialRepository)
        {
            this.materialRepository = materialRepository;
        }

        public async Task CreateAsync(T material)
        {
            material.CreatedAt = material.ModifiedAt = DateTimeOffset.Now;
            await this.materialRepository.AddAsync(material);
        }

        public async Task<IEnumerable<T>> GetAllMaterialsAsync() => await this.materialRepository.GetAllAsync();
    }
}