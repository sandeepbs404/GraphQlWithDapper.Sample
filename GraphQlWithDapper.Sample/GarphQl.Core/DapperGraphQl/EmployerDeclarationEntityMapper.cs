using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Dapper.GraphQL;
using GarphQl.Core.Models;
using GraphQL.Language.AST;

namespace GarphQl.Core.DapperGraphQl
{
    public class EmployerDeclarationEntityMapper : EntityMapper<EmployerDeclaration>
    {
        private IEntityMapperFactory _entityMapperFactory;

        public EmployerDeclarationEntityMapper(IEntityMapperFactory entityMapperFactory)
        {
            _entityMapperFactory = entityMapperFactory;
        }

        public override EmployerDeclaration Map(object[] objs, IHaveSelectionSet selectionSet = null, List<Type> splitOn = null)
        {
            EmployerDeclaration declaration = null;

            foreach (var obj in objs)
            {
                if (declaration == null &&
                    obj is EmployerDeclaration p)
                {
                    declaration = ResolveEntity(p);
                }

                //if (obj is NaturalPerson naturalPerson && declaration != null && declaration.NaturalPersons != null)
                //{
                //    var naturalPersonMapper = _entityMapperFactory.Build<NaturalPerson>(
                //        naaturalPerson => (naaturalPerson.NaturalPerson_Id),
                //        selectionSet,
                //        splitOn
                //    );

                //    var result = naturalPersonMapper(objs);
                //    if (!declaration.NaturalPersons.Any(_ => _.NaturalPerson_Id == naturalPerson.NaturalPerson_Id))
                //        declaration.NaturalPersons.Add(result);
                //    else
                //    {
                //        //var person = declaration.NaturalPersons.FirstOrDefault(x =>
                //        //    x.NaturalPerson_Id == result.NaturalPerson_Id);
                //        //if (person != null)
                //        //{
                //        //    ((List<WorkerRecord>)person.WorkerRecords).AddRange(result.WorkerRecords);
                //        //}
                //    }
                //}
            }
            return declaration;
        }
    }
}
