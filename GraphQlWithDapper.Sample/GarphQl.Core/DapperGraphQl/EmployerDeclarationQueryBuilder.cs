using Dapper.GraphQL;
using GarphQl.Core.Models;
using GraphQL.Language.AST;

namespace GarphQl.Core.DapperGraphQl
{
    public class EmployerDeclarationQueryBuilder : IQueryBuilder<EmployerDeclaration>
    {
        public SqlQueryContext Build(SqlQueryContext query, IHaveSelectionSet context, string alias)
        {
            query.Select($"{alias}.EmployerDeclaration_Id");
            query.SplitOn<EmployerDeclaration>("EmployerDeclaration_Id");

            var fields = context.GetSelectedFields();
            foreach (var kvp in fields)
            {
                switch (kvp.Key)
                {
                    case "quarter": query.Select($"{alias}.Quarter"); break;
                    case "CompanyID": query.Select($"{alias}.CompanyID"); break;
                    case "EmployerDeclaration_Id": query.Select($"{alias}.EmployerDeclaration_Id"); break;
                }
            }
            return query;
        }
    }
}
