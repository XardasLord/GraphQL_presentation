using GraphQL.Users.Api.Database.Entities;
using HotChocolate.Types;

namespace GraphQL.Users.Api.GraphQL.Types
{
    public class UserType : ObjectType<User>
    {
        protected override void Configure(IObjectTypeDescriptor<User> descriptor)
        {
            descriptor.Description("Pobranie użytkowników oraz stworzonych przez nich postów.");
            descriptor.Field(x => x.Password).Ignore();
            descriptor.Field(x => x.Id).Description("Identyfikator użytkownika");
            descriptor.Field(x => x.FirstName).Description("Imię");
            descriptor.Field(x => x.LastName).Description("Nazwisko");
            descriptor.Field(x => x.Address).Description("Adres");
            descriptor.Field(x => x.City).Description("Miasto");
            descriptor.Field(x => x.Country).Description("Kraj");
            descriptor.Field(x => x.Posts).Description("Posty stworzone przez użytkownika");
        }
    }
    public class PostType : ObjectType<Post>
    {
        protected override void Configure(IObjectTypeDescriptor<Post> descriptor)
        {
            descriptor.Description("Pobranie postów oraz użytkownika, który jest ich właścicielem.");
        }
    }
}