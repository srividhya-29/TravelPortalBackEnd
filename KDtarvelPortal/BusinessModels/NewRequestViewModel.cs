
using System.Collections.Generic;



namespace BusinessModels
{

    public class NewRequestViewModel
    {
       
       
       //made is ienumerable and not list because we want only distict employees to be seeen no distict() in list
        public IEnumerable<Employee> Employees { get; set; }

        
        public List<Client> Clients{ get; set; }


        public List<TravelType> TravelTypes { get; set; }


        public List<Project> Projects { get; set; }

        public List<Status> Statuses { get; set; }


    }
}
