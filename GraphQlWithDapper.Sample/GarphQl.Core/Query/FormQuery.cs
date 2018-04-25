using System;
using System.Data;
using Dapper.GraphQL;
using GarphQl.Core.Models;
using GraphQL.Types;
using Microsoft.Extensions.DependencyInjection;

namespace GarphQl.Core.Query
{
    public class FormQuery : ObjectGraphType
    {
        public FormQuery(IEntityMapperFactory entityMapperFactory,
            IQueryBuilder<Form> employeeQueryBuilder, IServiceProvider serviceProvider)
        {
            Name = "Query";
            Field<ListGraphType<FormType>>("Forms"
                , resolve: context =>
                {
                    var alias = "form";
                    var query = SqlBuilder
                        .From($"Form {alias}");

                    query = employeeQueryBuilder.Build(query, context.FieldAst, alias);

                    var formMapper = entityMapperFactory.Build<Form>(
                        form => (form.Form_Id),
                        context.FieldAst,
                        query.GetSplitOnTypes()
                    );

                    using (var connection = serviceProvider.GetRequiredService<IDbConnection>())
                    {
                        var results = query.Execute(connection, formMapper);
                        return results;
                    }
                });
        }
    }
}
