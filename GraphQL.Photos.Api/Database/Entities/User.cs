using System;

namespace GraphQL.Photos.Api.Database.Entities
{
    public class Photo
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public DateTime CreatedAt { get; set; }

        public int UserId { get; set; }
    }
}