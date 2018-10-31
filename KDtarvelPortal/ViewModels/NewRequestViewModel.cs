using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;

namespace ViewModels
{

    public class NewRequestViewModel
    {
       
        public List<Client> _clients { get; set; }
        public List<TravelType> _travelTypes { get; set; }
        public List<Employee> _employees { get; set; }
    }
}
