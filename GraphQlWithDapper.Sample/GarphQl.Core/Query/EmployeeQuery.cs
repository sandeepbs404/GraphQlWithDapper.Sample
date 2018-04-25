using GarphQl.Core.Models;
using GarphQl.Core.Types;
using GraphQL.Types;

namespace GarphQl.Core.Query
{
    public class EmployeeQuery : ObjectGraphType<object>
    {
        public EmployeeQuery()
        {
            Name = "EmployeeQuery";
            Field<EmployeeType>("Employee"
                , resolve: context => new Employee{
                    Id = 1,
                    Name = "Ram",
                    Designation = "Engineer"
                });
        }
    }
}
