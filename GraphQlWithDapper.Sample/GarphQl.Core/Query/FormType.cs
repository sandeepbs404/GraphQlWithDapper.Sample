using GarphQl.Core.Models;
using GraphQL.Types;

namespace GarphQl.Core.Query
{
    public class FormType : ObjectGraphType<Form>
    {
        public FormType()
        {
            Name = "Form";
            Description = "Form";
            Field(_ => _.Form_Id).Description("Form Id of Form");
            Field(_ => _.Identification).Description("Identification of Form");
            Field(_ => _.TypeForm).Description("TypeForm Date of Form");
            Field(_ => _.AttestationStatus).Description("AttestationStatus Date of Form");
            Field<ListGraphType<EmployerDeclarationType>>(
                "employerDeclarations",
                description: "A list ",
                resolve: context => context.Source?.EmployerDeclarations
            );
        }
    }
}
