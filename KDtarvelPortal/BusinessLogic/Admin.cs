using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BusinessModels;
using DataRepository;

namespace BusinessLogic
{
    public class Admin
    {
        // private List<TravellingEmp> _travellingEmployees;
        private List<TravelRequest> _travellingEmployees;
        private AdminRepo _repo;
        private LetterGeneration generateLetter;

        //public Admin(List<TravellingEmp> travellingEmployees)
        //{
        //    _repo = new AdminRepo();
        //    _travellingEmployees = travellingEmployees;
        //    generateLetter = new LetterGeneration();
        //}
        public Admin(List<TravelRequest> travellingEmployees)
        {
            _repo = new AdminRepo();
            _travellingEmployees = travellingEmployees;
            generateLetter = new LetterGeneration();
        }

        //public List<TravellingEmp> ViewAllTravels()
        //{
        //    _travellingEmployees = _repo.ViewAllTravels();

        //    return _travellingEmployees;
        //}
        public List<TravelRequest> ViewAllTravels()
        {
            _travellingEmployees = _repo.ViewAllTravels();

            return _travellingEmployees;
        }

        //public List<TravellingEmp> ApproveTravel(int travelId,TravellingEmp approvedTravel)
        //{
        //    _travellingEmployees = _repo.ApproveTravelRequest(travelId,approvedTravel);
        //    generateLetter.generateLetterOnDesig(travelId, TapprovedTravel);
        //    return _travellingEmployees;
        //}

        public List<TravelRequest> ApproveTravel(int travelId, TravelRequest approvedTravel)
        {
            _travellingEmployees = _repo.ApproveTravelRequest(travelId, approvedTravel);
            generateLetter.generateLetterOnDesig(travelId, approvedTravel);
            return _travellingEmployees;
        }
    }
}
