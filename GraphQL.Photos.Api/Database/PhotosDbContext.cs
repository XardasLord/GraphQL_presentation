using System.Collections.Generic;
using Bogus;
using GraphQL.Photos.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Photos.Api.Database
{
    public class PhotosDbContext : DbContext
    {
        public PhotosDbContext(DbContextOptions options) 
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EntityConfiguration(modelBuilder);
            SeedData(modelBuilder);
        }

        private void EntityConfiguration(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Photo>(entity =>
            {
                entity.ToTable(nameof(Photos));
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Name).HasColumnName(nameof(Photo.Name));
                entity.Property(x => x.Url).HasColumnName(nameof(Photo.Url));
                entity.Property(x => x.CreatedAt).HasColumnName(nameof(Photo.CreatedAt));
                entity.Property(x => x.UserId).HasColumnName(nameof(Photo.UserId));
            });
        }

        private static void SeedData(ModelBuilder modelBuilder)
        {
            FakeData.Init(30);

            modelBuilder.Entity<Photo>().HasData(FakeData.Photos);
        }

        public DbSet<Photo> Photos { get; set; }
    }

    public class FakeData
    {
        public static List<Photo> Photos = new List<Photo>();

        public static void Init(int count)
        {
            var photoId = 1;
            var photoFaker = new Faker<Photo>("pl")
                .RuleFor(x => x.Id, _ => photoId++)
                .RuleFor(x => x.Name, f => f.Company.CompanyName())
                .RuleFor(x => x.Url, f => f.Internet.Url())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past())
                .RuleFor(x => x.UserId, f => f.Random.Number(1, 10));

            var photos = photoFaker.Generate(count);

            FakeData.Photos.AddRange(photos);
        }
    }
}