using System.Linq;
using GraphQL.Users.Api.Database;
using GraphQL.Users.Api.Database.Entities;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace GraphQL.Users.Api.GraphQL.Queries
{
    public class UserQuery
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [UseSelection]
        public IQueryable<User> GetUsers([Service] UsersDbContext context)
            => context.Users;

        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [UseSelection]
        public IQueryable<Post> GetPosts([Service] UsersDbContext context)
            => context.Posts;
    }
}