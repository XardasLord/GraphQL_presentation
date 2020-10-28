using GraphQL.Photos.Api.Database.Entities;
using HotChocolate.Types;

namespace GraphQL.Photos.Api.GraphQL.Types
{
    public class PhotoType : ObjectType<Photo>
    {
        protected override void Configure(IObjectTypeDescriptor<Photo> descriptor)
        {
            descriptor.Description("Pobranie informacji o zdjęciach.");
            descriptor.Field(x => x.Id).Description("Identyfikator zdjęcia");
            descriptor.Field(x => x.Name).Description("Nazwa");
            descriptor.Field(x => x.Url).Description("Adres URL");
            descriptor.Field(x => x.CreatedAt).Description("Data dodania");
            descriptor.Field(x => x.UserId).Description("Identyfikator użytkownika, do którego należy zdjęcie");
        }
    }
}