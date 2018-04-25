using System;
using System.Collections.Generic;
using System.Text;

namespace GarphQl.Core.Models
{
    public class NaturalPerson
    {
        public string NaturalPersonSequenceNbr { get; set; }

        public string INSS { get; set; }

        public string WorkerName { get; set; }

        public string WorkerFirstName { get; set; }

        public string NaturalPersonUserReference { get; set; }

        public string NaturalPersonPID { get; set; }

        public string DeclNaturalPersonPID { get; set; }

        public string DeclNaturalPersonVersionNbr { get; set; }

        public string ResultCodeResearch { get; set; }

        public string EmployerDeclaration_Id { get; set; }

        public string NaturalPerson_Id { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }
    }
}
