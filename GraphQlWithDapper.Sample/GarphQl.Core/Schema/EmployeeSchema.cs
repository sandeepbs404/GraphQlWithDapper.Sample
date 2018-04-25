using System;
using System.Collections.Generic;
using System.Text;
using GarphQl.Core.Query;
using GraphQL;

namespace GarphQl.Core.Schema
{
    public class EmployeeSchema : GraphQL.Types.Schema
    {
        public EmployeeSchema(EmployeeQuery query, IDependencyResolver dependencyResolver)
        {
            Query = query;
            DependencyResolver = dependencyResolver;
        }
    }
}
