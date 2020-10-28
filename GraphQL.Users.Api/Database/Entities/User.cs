using System;
using System.Collections.Generic;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace GraphQL.Users.Api.Database.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string Country { get; set; }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [UseSelection]
        public ICollection<Post> Posts { get; set; }
    }

    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; } 
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [UseSelection]
        public ICollection<Comment> Comments { get; set; }
    }

    public class Comment
    {
        public int Id { get; set; }
        public string Nickname { get; set; }
        public string Text { get; set; }
        public DateTime CreatedAt { get; set; }

        public int CommentId { get; set; }
    }

    // Another microservice
    //public class Photo
    //{
    //    public int Id { get; set; }
    //    public string Name { get; set; }
    //    public string Url { get; set; }
    //    public DateTime CreatedAt { get; set; }

    //    public int UserId { get; set; }
    //    public User User { get; set; }
    //}
}