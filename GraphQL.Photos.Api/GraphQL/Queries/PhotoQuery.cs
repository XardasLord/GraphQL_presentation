using System.Linq;
using GraphQL.Photos.Api.Database;
using GraphQL.Photos.Api.Database.Entities;
using HotChocolate;
using HotChocolate.Types;
using HotChocolate.Types.Relay;

namespace GraphQL.Photos.Api.GraphQL.Queries
{
    public class PhotoQuery
    {
        [UsePaging]
        [UseFiltering]
        [UseSorting]
        [UseSelection]
        public IQueryable<Photo> GetPhotos([Service] PhotosDbContext context)
            => context.Photos;
    }
}