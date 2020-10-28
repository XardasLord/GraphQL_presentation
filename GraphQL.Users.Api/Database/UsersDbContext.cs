using System.Collections.Generic;
using Bogus;
using Bogus.Extensions;
using GraphQL.Users.Api.Database.Entities;
using Microsoft.EntityFrameworkCore;

namespace GraphQL.Users.Api.Database
{
    public class UsersDbContext : DbContext
    {
        public UsersDbContext(DbContextOptions options) 
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
            modelBuilder.Entity<User>(entity =>
            {
                entity.ToTable(nameof(Users));
                entity.HasKey(x => x.Id);

                entity.Property(x => x.FirstName).HasColumnName(nameof(User.FirstName));
                entity.Property(x => x.Password).HasColumnName(nameof(User.Password));
                entity.Property(x => x.LastName).HasColumnName(nameof(User.LastName));
                entity.Property(x => x.Address).HasColumnName(nameof(User.Address));
                entity.Property(x => x.City).HasColumnName(nameof(User.City));
                entity.Property(x => x.Country).HasColumnName(nameof(User.Country));

                entity.HasMany(x => x.Posts)
                    .WithOne(x => x.User)
                    .HasForeignKey(x => x.UserId);
            });

            modelBuilder.Entity<Post>(entity =>
            {
                entity.ToTable(nameof(Posts));
                entity.HasKey(x => x.Id);

                entity.Property(x => x.Title).HasColumnName(nameof(Post.Title));
                entity.Property(x => x.Text).HasColumnName(nameof(Post.Text));
                entity.Property(x => x.CreatedAt).HasColumnName(nameof(Post.CreatedAt));
                entity.Property(x => x.UserId).HasColumnName(nameof(Post.UserId));

                entity.HasOne(x => x.User)
                    .WithMany(x => x.Posts)
                    .HasForeignKey(x => x.UserId);

                entity.HasMany(x => x.Comments)
                    .WithOne()
                    .HasForeignKey(x => x.CommentId);
            });
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            FakeData.Init(10);

            modelBuilder.Entity<User>().HasData(FakeData.Users);
            modelBuilder.Entity<Post>().HasData(FakeData.Posts);
            modelBuilder.Entity<Comment>().HasData(FakeData.Comments);
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<Comment> Comments { get; set; }
    }

    public class FakeData
    {
        public static List<User> Users = new List<User>();
        public static List<Post> Posts = new List<Post>();
        public static List<Comment> Comments = new List<Comment>();

        public static void Init(int count)
        {
            var commentId = 1;
            var commentFaker = new Faker<Comment>("pl")
                .RuleFor(x => x.Id, _ => commentId++)
                .RuleFor(x => x.Text, f => f.Company.CompanyName())
                .RuleFor(x => x.Nickname, f => f.Internet.UserName())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past());

            var postId = 1;
            var postFaker = new Faker<Post>("pl")
                .RuleFor(x => x.Id, _ => postId++)
                .RuleFor(x => x.Title, f => f.Commerce.ProductName())
                .RuleFor(x => x.Text, f => f.Commerce.ProductDescription())
                .RuleFor(x => x.CreatedAt, f => f.Date.Past())
                .RuleFor(x => x.Comments, (f, x) =>
                {
                    commentFaker.RuleFor(p => p.CommentId, _ => x.Id);

                    var comments = commentFaker.GenerateBetween(0, 20);

                    FakeData.Comments.AddRange(comments);

                    return null;
                });

            var userId = 1;
            var userFaker = new Faker<User>("pl")
                .RuleFor(x => x.Id, _ => userId++)
                .RuleFor(x => x.Password, f => f.Internet.Password())
                .RuleFor(x => x.FirstName, f => f.Name.FirstName())
                .RuleFor(x => x.LastName, f => f.Name.LastName())
                .RuleFor(x => x.Address, f => f.Address.StreetAddress())
                .RuleFor(x => x.City, f => f.Address.City())
                .RuleFor(x => x.Country, f => f.Address.Country())
                .RuleFor(x => x.Posts, (f, x) =>
                {
                    postFaker.RuleFor(p => p.UserId, _ => x.Id);

                    var posts = postFaker.GenerateBetween(1, 5);

                    FakeData.Posts.AddRange(posts);

                    return null;
                });

            var users = userFaker.Generate(count);

            FakeData.Users.AddRange(users);
        }
    }
}