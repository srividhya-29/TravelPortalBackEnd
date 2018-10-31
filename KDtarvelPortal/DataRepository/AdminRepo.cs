using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using da = DataAccess;
using BusinessModels;

namespace DataRepository
{
    public class AdminRepo
    {
        private da.KDTravelPortalDbContext _context;


        public AdminRepo()
        {

            this._context = new da.KDTravelPortalDbContext();

        }
        //public List<TravellingEmp> ViewAllTravels()
        //{
        //    var travellingEmp = (from tr in _context.TravelRequests
        //                         join e in _context.Employees on

        //                         tr.EmployeeId equals e.EmployeeId


        //                         join s in _context.Statuses on
        //                         tr.StatusId equals s.StatusId


        //                         join c in _context.Clients on
        //                         tr.ClientId equals c.ClientId

        //                         join tt in _context.TravelTypes on
        //                         tr.TravelTypeId equals tt.TravelTypeId

        //                         select new TravellingEmp
        //                         {
        //                             TravelId = tr.TravelId,
        //                             TravelRequestName = tr.TravelRequestName,
        //                             StartDate = tr.StartDate,
        //                             EndDate = tr.EndDate,
        //                             Place = tr.Place,
        //                             EmployeeName = e.EmployeeName,
        //                             Message = s.Message,
        //                             ClientName = c.ClientName,
        //                             Type = tt.Type
        //                         }).ToList();

        //    return travellingEmp as List<TravellingEmp>;
        //}

        public List<TravelRequest> ViewAllTravels()
        {
            var travellingEmp = (from tr in _context.TravelRequests
                                 join ep in _context.EmployeesProjects on

                                 tr.EmployeeProjectId equals ep.Id
                                 join p in _context.Projects on
                                 ep.ProjectId equals p.ProjectId


                                 join s in _context.Statuses on
                                 tr.StatusId equals s.StatusId

                                 join c in _context.Clients on
                                 tr.ClientId equals c.ClientId

                                 join tt in _context.TravelTypes on
                                 tr.TravelTypeId equals tt.TravelTypeId

                                 select new TravelRequest
                                 {
                                     TravelId = tr.TravelId,
                                     TravelRequestName = tr.TravelRequestName,
                                     StartDate = tr.StartDate,
                                     EndDate = tr.EndDate,
                                     Place = tr.Place,
                                     EmployeeId = (from e in _context.Employees
                                                   join ep in _context.EmployeesProjects on
                                                    e.EmployeeId equals ep.EmployeeId
                                                   where ep.Id == tr.EmployeeProjectId
                                                   select e.EmployeeId).FirstOrDefault(),
                                     StatusId = s.StatusId,
                                     ClientId = c.ClientId,
                                     ProjectId = (from p in _context.Projects
                                                  join ep in _context.EmployeesProjects on
                                                  p.ProjectId equals ep.ProjectId
                                                  where ep.Id == tr.EmployeeProjectId
                                                  select p.ProjectId).FirstOrDefault(),
                                     TravelTypeId = tt.TravelTypeId
                                 }).ToList();

            return travellingEmp as List<TravelRequest>;
        }
        //re-initializing all attributes because in future can give access to admin also to change sometravel details
        //public List<TravellingEmp> ApproveTravelRequest(int travelId, TravellingEmp approvedModel)
        //{
        //    List<TravellingEmp> updatedList = new List<TravellingEmp>();
        //    var record = _context.TravelRequests.SingleOrDefault(i => i.TravelId == travelId);
        //    record.TravelRequestName = approvedModel.TravelRequestName;
        //    record.TravelTypeId = (from tt in _context.TravelTypes
        //                           where tt.Type == approvedModel.Type
        //                           select tt.TravelTypeId).SingleOrDefault();
        //    record.StartDate = approvedModel.StartDate;
        //    record.EndDate = approvedModel.EndDate;
        //    record.Place = approvedModel.Place;
        //    record.EmployeeId = (from e in _context.Employees
        //                         where e.EmployeeName == approvedModel.EmployeeName
        //                         select e.EmployeeId).SingleOrDefault();
        //    record.ClientId = (from c in _context.Clients
        //                       where c.ClientName == approvedModel.ClientName
        //                       select c.ClientId).SingleOrDefault();
        //    record.StatusId = (from s in _context.Statuses
        //                       where s.Message == approvedModel.Message
        //                       select s.StatusId).SingleOrDefault();
        //    record.TravelType = _context.TravelTypes.FirstOrDefault(i => i.TravelTypeId == record.TravelTypeId);
        //    record.Employee = _context.Employees.FirstOrDefault(i => i.EmployeeId == record.EmployeeId);
        //    record.Client = _context.Clients.FirstOrDefault(i => i.ClientId == record.ClientId);
        //    record.Status = _context.Statuses.FirstOrDefault(i => i.StatusId == record.StatusId);
        //    _context.SaveChanges();
        //    updatedList = this.ViewAllTravels();
        //    return updatedList;

        //}

        public List<TravelRequest> ApproveTravelRequest(int travelId, TravelRequest approvedModel)
        {
            List<TravelRequest> updatedList = new List<TravelRequest>();
            var record = _context.TravelRequests.SingleOrDefault(i => i.TravelId == travelId);
            record.TravelRequestName = approvedModel.TravelRequestName;
            record.TravelTypeId = approvedModel.TravelTypeId;
            record.StartDate = approvedModel.StartDate;
            record.EndDate = approvedModel.EndDate;
            record.Place = approvedModel.Place;
            record.EmployeeProjectId = (from ep in _context.EmployeesProjects
                                        where ep.EmployeeId == approvedModel.EmployeeId
                                        && ep.ProjectId == approvedModel.ProjectId
                                        select ep.Id).FirstOrDefault();

            record.ClientId = approvedModel.ClientId;
            record.StatusId = approvedModel.StatusId;
            record.TravelType = _context.TravelTypes.FirstOrDefault(i => i.TravelTypeId == record.TravelTypeId);
            record.Employee_Project = _context.EmployeesProjects.FirstOrDefault(i => i.Id == record.EmployeeProjectId);
            record.Client = _context.Clients.FirstOrDefault(i => i.ClientId == record.ClientId);
            record.Status = _context.Statuses.FirstOrDefault(i => i.StatusId == record.StatusId);
            _context.SaveChanges();
            updatedList = this.ViewAllTravels();
            return updatedList;

        }
    }
}
