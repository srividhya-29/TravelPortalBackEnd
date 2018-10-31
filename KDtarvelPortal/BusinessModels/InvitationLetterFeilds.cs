using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class InvitationLetterFeilds
    {
       
        public int travelId { get; set; }
        public int empId { get; set; }
        public string travelName { get; set; }
        public string EmployeeName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Place { get; set; }
        public string ClientName { get; set; }
        public string ProjectName { get; set; }
        public string managerName { get; set; }



    }
}
