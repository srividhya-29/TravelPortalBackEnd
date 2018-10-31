using db = DataAccess;

namespace Entities
{



    public class Employee
    {


        public int EmployeeId { get; set; }


        public string EmployeeName { get; set; }


        public string Team { get; set; }


        public string WorkLocation { get; set; }


        public string Address { get; set; }


        public string MobNo { get; set; }


        public string FatherName { get; set; }


        public string MotherName { get; set; }


        public string PortalPassword { get; set; }



        public int ReportingManagerId { get; set; }

        public byte DesignationId { get; set; }

        public Employee()
        {

        }

        public Employee(db.Employee dataAccess_emp)
        {

            EmployeeId = dataAccess_emp.EmployeeId;
            EmployeeName = dataAccess_emp.EmployeeName;
            FatherName = dataAccess_emp.FatherName;
            MobNo = dataAccess_emp.MobNo;
            MotherName = dataAccess_emp.MotherName;
            DesignationId = dataAccess_emp.DesignationId;
            ReportingManagerId = dataAccess_emp.ReportingManagerId;
            WorkLocation = dataAccess_emp.WorkLocation;
            Team = dataAccess_emp.Team;
            PortalPassword = dataAccess_emp.PortalPassword;
            Address = dataAccess_emp.Address;

        }



    }
}
