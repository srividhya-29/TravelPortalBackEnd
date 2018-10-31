using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessModels
{
    public class TravellingEmp
    {
        
        public int TravelId { get; set; }


       
        public string TravelRequestName { get; set; }


        
        public DateTime StartDate { get; set; }


        
        public DateTime EndDate { get; set; }


     
        public string Place { get; set; }
        public string EmployeeName { get; set; }

        public string Message { get; set; }
        public string Type { get; set; }
        public string ClientName { get; set; }
    }
}
