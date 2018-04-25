using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.GraphQL;
using GarphQl.Core.Models;
using GraphQL.Language.AST;

namespace GarphQl.Core.DapperGraphQl
{
    public class FormEntityMapper : EntityMapper<Form>
    {
        private IEntityMapperFactory _entityMapperFactory;

        public FormEntityMapper(IEntityMapperFactory entityMapperFactory)
        {
            _entityMapperFactory = entityMapperFactory;
        }

        public override Form Map(object[] objs, IHaveSelectionSet selectionSet = null, List<Type> splitOn = null)
        {
            Form employee = null;
            foreach (var obj in objs)
            {
                if (employee == null &&
                    obj is Form p)
                {
                    employee = ResolveEntity(p);
                    continue;
                }

                if (obj is EmployerDeclaration employerDeclaration && employee.EmployerDeclarations != null)
                {
                    var employerDeclarationMapper = _entityMapperFactory.Build<EmployerDeclaration>(
                        employerDeclarations => (employerDeclarations.EmployerDeclaration_Id),
                        selectionSet,
                        splitOn
                    );
                    var result = employerDeclarationMapper(objs);
                    if (!employee.EmployerDeclarations.Any(declaration => declaration.EmployerDeclaration_Id == employerDeclaration.EmployerDeclaration_Id))
                        employee.EmployerDeclarations.Add(result);
                    else
                    {
                        var declaration = employee.EmployerDeclarations.FirstOrDefault(x =>
                            x.EmployerDeclaration_Id == result.EmployerDeclaration_Id);
                        if (declaration != null)
                        {
                            ((List<NaturalPerson>)declaration.NaturalPersons).AddRange(result.NaturalPersons);
                        }
                    }
                }

            }
            return employee;
        }
    }
}
