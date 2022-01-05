namespace EducationPortal.Infrastructure
{
    using EducationPortal.Core.Entities;
    using EducationPortal.Core.Enums;
    using Microsoft.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore.Metadata.Builders;

    public class EducationPortalDbContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<Course> Courses { get; set; }

        public DbSet<Skill> Skills { get; set; }

        public DbSet<Material> Materials { get; set; }

        public DbSet<ArticleMaterial> ArticleMaterials { get; set; }

        public DbSet<BookMaterial> BookMaterials { get; set; }

        public DbSet<VideoMaterial> VideoMaterials { get; set; }

        public EducationPortalDbContext(DbContextOptions<EducationPortalDbContext> dbContextOptions)
            : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>(this.UserConfigure);
            modelBuilder.Entity<Course>(this.CourseConfigure);
            modelBuilder.Entity<Skill>(this.SkillConfigure);
            modelBuilder.Entity<Material>(this.MaterialConfigure);
            modelBuilder.Entity<Author>(this.AuthorConfigure);

            modelBuilder.Entity<VideoMaterial>(this.VideoMaterialConfigure);
            modelBuilder.Entity<BookMaterial>(this.BookMaterialConfigure);
            modelBuilder.Entity<ArticleMaterial>(this.ArticleMaterialConfigure);

            modelBuilder.Entity<UserCourse>(this.UserCourseConfigure);
            modelBuilder.Entity<UserMaterial>(this.UserMaterialConfigure);
            modelBuilder.Entity<UserSkill>(this.UserSkillConfigure);
        }

        protected void UserConfigure(EntityTypeBuilder<User> builder)
        {
            builder.Property(u => u.Name).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Surname).IsRequired().HasMaxLength(50);
            builder.Property(u => u.Email).IsRequired().HasMaxLength(100);
            builder.Property(u => u.PasswordHash).IsRequired().HasMaxLength(200);

            builder.Property(u => u.PhoneNumber).HasMaxLength(30);
            builder.Property(u => u.PlaceStudy).HasMaxLength(100);
            builder.Property(u => u.PlaceWork).HasMaxLength(100);
            builder.Property(u => u.CreatedAt);
            builder.Property(u => u.ModifiedAt);
            builder.Property(u => u.IsDeleted).HasDefaultValue(false);
        }

        protected void CourseConfigure(EntityTypeBuilder<Course> builder)
        {
            builder.Property(c => c.Name).HasMaxLength(100);
            builder.Property(c => c.Description);
            builder.Property(c => c.CreatedAt);
            builder.Property(c => c.ModifiedAt);
            builder.Property(c => c.IsDeleted).HasDefaultValue(false);

            builder
                .HasOne(c => c.Creator)
                .WithMany(u => u.CreatedCourses)
                .HasForeignKey(c => c.CreatorId);
        }

        protected void UserCourseConfigure(EntityTypeBuilder<UserCourse> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.CourseId });
            builder.Property(uc => uc.Status).IsRequired().HasDefaultValue(CourseStatus.None);
            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserCourses)
                .HasForeignKey(uc => uc.UserId);
            builder
                .HasOne(uc => uc.Course)
                .WithMany(c => c.UserCourses)
                .HasForeignKey(uc => uc.CourseId)
                .OnDelete(DeleteBehavior.Restrict);
        }

        protected void SkillConfigure(EntityTypeBuilder<Skill> builder)
        {
            builder.Property(s => s.Name).IsRequired().HasMaxLength(50);
            builder.Property(s => s.IsDeleted).HasDefaultValue(false);
        }

        protected void UserSkillConfigure(EntityTypeBuilder<UserSkill> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.SkillId });
            builder.Property(uc => uc.Level).IsRequired().HasDefaultValue(0);
            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserSkills)
                .HasForeignKey(uc => uc.UserId);
            builder
                .HasOne(uc => uc.Skill)
                .WithMany(s => s.UserSkills)
                .HasForeignKey(uc => uc.SkillId);
        }

        protected void MaterialConfigure(EntityTypeBuilder<Material> builder)
        {
            builder.Property(m => m.Name).IsRequired().HasMaxLength(50);

            builder.Property(m => m.IsDeleted).HasDefaultValue(false);
            builder.Property(m => m.CreatedAt);
            builder.Property(m => m.ModifiedAt);
        }

        protected void UserMaterialConfigure(EntityTypeBuilder<UserMaterial> builder)
        {
            builder.HasKey(uc => new { uc.UserId, uc.MaterialId });
            builder.Property(uc => uc.IsPassed).HasDefaultValue(false);
            builder
                .HasOne(uc => uc.User)
                .WithMany(u => u.UserMaterials)
                .HasForeignKey(uc => uc.UserId);
            builder
                .HasOne(uc => uc.Material)
                .WithMany(m => m.UserMaterials)
                .HasForeignKey(uc => uc.MaterialId);
        }

        protected void ArticleMaterialConfigure(EntityTypeBuilder<ArticleMaterial> builder)
        {
            builder.ToTable("ArticleMaterial");
            builder.Property(a => a.DateOfPublishing).IsRequired();
            builder.Property(a => a.ResourceLocation).IsRequired();
        }

        protected void VideoMaterialConfigure(EntityTypeBuilder<VideoMaterial> builder)
        {
            builder.ToTable("VideoMaterial");
            builder.Property(v => v.Quality).IsRequired();
            builder.Property(v => v.Duration).IsRequired();
        }

        protected void BookMaterialConfigure(EntityTypeBuilder<BookMaterial> builder)
        {
            builder.ToTable("BookMaterial");
            builder.Property(b => b.Format).IsRequired();
            builder.Property(b => b.PagesCount).IsRequired();
            builder.Property(b => b.YearOfPublishing).IsRequired();
        }

        protected void AuthorConfigure(EntityTypeBuilder<Author> builder)
        {
            builder.Property(a => a.Name).IsRequired().HasMaxLength(100);
            builder.Property(a => a.Surname).IsRequired().HasMaxLength(100);
        }
    }
}