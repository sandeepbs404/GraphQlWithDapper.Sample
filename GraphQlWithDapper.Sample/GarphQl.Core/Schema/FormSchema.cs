using GarphQl.Core.Query;
using GraphQL;

namespace GarphQl.Core.Schema
{
    public class FormSchema : GraphQL.Types.Schema
    {
        public FormSchema(FormQuery query, IDependencyResolver dependencyResolver)
        {
            Query = query;
            DependencyResolver = dependencyResolver;
        }
    }
}
