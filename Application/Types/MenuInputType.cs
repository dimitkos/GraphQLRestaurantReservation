using GraphQL.Types;

namespace Application.Types
{
    public class MenuInputType : InputObjectGraphType
    {
        public MenuInputType()
        {
            Field<IntGraphType>("id");
            Field<StringGraphType>("name");
            Field<StringGraphType>("description");
            Field<FloatGraphType>("price");
            Field<StringGraphType>("imageurl");
            Field<IntGraphType>("categoryId");
        }
    }
}
