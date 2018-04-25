using System;
using System.Collections.Generic;
using System.Text;
using GarphQl.Core.Models;
using Dapper.GraphQL;
using GraphQL.Language.AST;

namespace GarphQl.Core.DapperGraphQl
{
    public class FormQueryBuilder : IQueryBuilder<Form>
    {
        private readonly IQueryBuilder<EmployerDeclaration> _employerDeclarationBuilder;

        public FormQueryBuilder(IQueryBuilder<EmployerDeclaration> employerDeclarationBuilder)
        {
            _employerDeclarationBuilder = employerDeclarationBuilder;
        }

        public SqlQueryContext Build(SqlQueryContext query, IHaveSelectionSet context, string alias)
        {
            query.Select($"{alias}.Form_Id");
            query.SplitOn<Form>("Form_Id");

            var fields = context.GetSelectedFields();
            foreach (var kvp in fields)
            {
                switch (kvp.Key)
                {
                    case "identification": query.Select($"{alias}.Identification"); break;
                    case "formCreationDate": query.Select($"{alias}.FormCreationDate"); break;
                    case "formCreationHour": query.Select($"{alias}.FormCreationHour"); break;
                    case "attestationStatus": query.Select($"{alias}.AttestationStatus"); break;
                    case "typeForm": query.Select($"{alias}.TypeForm"); break;

                    case "employerDeclarations":
                    {
                        var employerDeclarationAlias = $"{alias}EmployerDeclaration";
                        query.LeftJoin($"EmployerDeclaration {employerDeclarationAlias} ON {alias}.Form_Id = {employerDeclarationAlias}.Form_Id");
                        query = _employerDeclarationBuilder.Build(query, kvp.Value, employerDeclarationAlias);
                    }
                        break;
                }
            }

            return query;
        }
    }
}
