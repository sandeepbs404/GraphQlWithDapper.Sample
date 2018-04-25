using System;
using System.Collections.Generic;
using System.Text;
using GarphQl.Core.Models;
using GraphQL.Introspection;
using GraphQL.Types;

namespace GarphQl.Core.Types
{
    //How the Model is exposed to UI with additional description of each field in Type
    public class EmployeeType : ObjectGraphType<Employee>
    {
        public EmployeeType()
        {
            Name = "Employee";
            Description = "employee";
            Field(_ => _.Id).Description("Id of employee");
            Field(_ => _.Name).Description("Name of employee");
            Field(_ => _.Designation).Description("Designation Date of employee");
        }
    }
}
