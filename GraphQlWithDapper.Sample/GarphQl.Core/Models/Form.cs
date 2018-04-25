using System;
using System.Collections.Generic;
using System.Text;

namespace GarphQl.Core.Models
{
    public class Form
    {
        public string Identification { get; set; }

        public string FormCreationDate { get; set; }

        public string FormCreationHour { get; set; }

        public string AttestationStatus { get; set; }

        public string TypeForm { get; set; }

        public string Form_Id { get; set; }

        public string DmfAConsultationAnswer_Id { get; set; }

        public string UpdatedBy { get; set; }

        public DateTime UpdatedTime { get; set; }

        public IList<EmployerDeclaration> EmployerDeclarations { get; set; }

        public Form()
        {
            EmployerDeclarations = new List<EmployerDeclaration>();
        }
    }
}
