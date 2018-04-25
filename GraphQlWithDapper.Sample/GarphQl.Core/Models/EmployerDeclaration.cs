using System;
using System.Collections.Generic;
using System.Text;

namespace GarphQl.Core.Models
{
    public class EmployerDeclaration
    {
        public string Quarter { get; set; }

        public string NOSSRegistrationNbr { get; set; }

        public string Trusteeship { get; set; }

        public string NOSSLPARegistrationNbr { get; set; }

        public string CompanyID { get; set; }

        public string System5 { get; set; }

        public string EmployerDeclarationPID { get; set; }

        public string EmployerDeclarationVersionNbr { get; set; }

        public string ResultCodeResearch { get; set; }

        public string AnomalySubmission { get; set; }

        public string Form_Id { get; set; }

        public string EmployerDeclaration_Id { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public IList<NaturalPerson> NaturalPersons { get; set; }

        public EmployerDeclaration()
        {
            NaturalPersons = new List<NaturalPerson>();
        }

    }
}
