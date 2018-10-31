using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;
using DataRepository;


namespace BusinessLogic
{
    public class Manager
    {
        
        private RepositoryMethods _repo;
        private NewRequestViewModel _vm;
        private NewRequestViewModelOnSubmit _output;
        //private List<TravellingEmp> _travellingEmployees;
        private List<TravelRequest> _travellingEmployees;

        public Manager(NewRequestViewModel vm)
        {
            _repo = new RepositoryMethods();
            _vm = vm;
        }

        public Manager(NewRequestViewModelOnSubmit output)
        {
            _repo = new RepositoryMethods();
            _output = output;
        }
        //public Manager(List<TravellingEmp> travellingEmployees)
        //{
        //    _repo = new RepositoryMethods();
        //    _travellingEmployees = travellingEmployees;
        //}
        public Manager(List<TravelRequest> travellingEmployees)
        {
            _repo = new RepositoryMethods();
            _travellingEmployees = travellingEmployees;
        }




        public void RaiseNewRequest(int empId)
       {

            _vm.Clients = _repo.PopulateClients();
            _vm.Employees = _repo.PopulateEmployeesUnderManager(empId);
            _vm.TravelTypes = _repo.PopulateTravelTypes();
            _vm.Projects = _repo.PopulateProjects(empId);
            _vm.Statuses = _repo.PopulateStatus();
            
       }

        public void SubmitRequest(NewRequestViewModelOnSubmit outputModel)
        {
            _repo.insertTravelDetails(outputModel);

        }

        //public List<TravellingEmp> ViewTravelRequests(int mgrId)
        //{
        //    _travellingEmployees = _repo.ViewTravelRequests(mgrId);

        //    return _travellingEmployees;
        //}

        public List<TravelRequest> ViewTravelRequests(int mgrId)
        {
            _travellingEmployees = _repo.ViewTravelRequests(mgrId);

            return _travellingEmployees;
        }

        public List<TravelRequest> DeleteTravelRequest(int mgrId,int travelId)
        {
            _travellingEmployees = _repo.DeleteTravelRecord(travelId, mgrId);
            return _travellingEmployees;
        }

        public List<TravelRequest> EditTravelRequest(int mgrId, int travelId,TravelRequest updatedModel)
        {
            _travellingEmployees = _repo.EditTravelRequest(mgrId,travelId,updatedModel);
            return _travellingEmployees;
        }
    }
}
