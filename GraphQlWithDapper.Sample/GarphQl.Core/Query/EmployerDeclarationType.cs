using GarphQl.Core.Models;
using GraphQL.Types;

namespace GarphQl.Core.Query
{
    public class EmployerDeclarationType: ObjectGraphType<EmployerDeclaration>
    {
        public EmployerDeclarationType()
        {
            Name = "EmployerDeclaration";
            Field(_ => _.Quarter).Description("Quarter of EmployerDeclaration");
            Field(_ => _.NOSSRegistrationNbr).Description("NOSSRegistrationNbr of EmployerDeclaration");
            Field(_ => _.Trusteeship).Description("Trusteeship of EmployerDeclaration");
            Field(_ => _.NOSSLPARegistrationNbr).Description("NOSSLPARegistrationNbr of EmployerDeclaration");
            Field(_ => _.CompanyID).Description("CompanyID of EmployerDeclaration");
            Field(_ => _.System5).Description("System5 of EmployerDeclaration");
            Field(_ => _.EmployerDeclarationPID).Description("EmployerDeclarationPID of EmployerDeclaration");
            Field(_ => _.EmployerDeclarationVersionNbr).Description("EmployerDeclarationVersionNbr of EmployerDeclaration");
            Field(_ => _.ResultCodeResearch).Description("ResultCodeResearch of EmployerDeclaration");
            Field(_ => _.AnomalySubmission).Description("AnomalySubmission of EmployerDeclaration");
            Field(_ => _.Form_Id).Description("Form_Id of EmployerDeclaration");
            Field(_ => _.EmployerDeclaration_Id).Description("EmployerDeclaration_Id of EmployerDeclaration");
            Field(_ => _.UpdatedBy).Description("UpdatedBy of EmployerDeclaration");
            Field(_ => _.UpdatedTime).Description("UpdatedTime of EmployerDeclaration");
        }
    }
}
