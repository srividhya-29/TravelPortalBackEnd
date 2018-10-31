
using System.Collections.Generic;
using System.Linq;
using da = DataAccess;
using BusinessModels;
using System.Data.SqlClient;

namespace DataRepository
{
    public class RepositoryMethods
    {
        private da.KDTravelPortalDbContext _context;
        private bool _isPresent = false;

        public  RepositoryMethods(){

            this._context = new da.KDTravelPortalDbContext();
           
        }
        public IEnumerable<Employee> PopulateEmployeesUnderManager(int managerId)
        {
            //to populate all the employee names who belong to that perticular manager
            var employees = (from ep in _context.EmployeesProjects
                             join p in _context.Projects on
                             ep.ProjectId equals p.ProjectId
                             where p.InchargeId == managerId

                             join e in _context.Employees on
                             ep.EmployeeId equals e.EmployeeId
                             
                             select new Employee{
                                 EmployeeId = e.EmployeeId,
                                 EmployeeName = e.EmployeeName,
                                 
                                 WorkLocation = e.WorkLocation

                             }).Distinct();


            

            return employees as IEnumerable<Employee>;
        }

        public List<TravelType> PopulateTravelTypes()
        {
            var travelTypes = (from t in _context.TravelTypes
                             select new TravelType {
                                 TravelTypeId = t.TravelTypeId,
                                 Type = t.Type
                             }).ToList();

            return travelTypes as List<TravelType>;
        }

        public List<Client> PopulateClients()
        {
            var clients = (from c in _context.Clients
                          select new Client {
                              ClientId = c.ClientId,
                              ClientName = c.ClientName
                          }).ToList();
            
            return clients as List<Client>;
        }

        public List<Project> PopulateProjects(int managerId)
        {
            var projects = (from p in _context.Projects
                            where p.InchargeId == managerId
                           select new Project
                           {
                               ProjectId = p.ProjectId,
                               ProjectName = p.ProjectName
                           }).ToList();

            return projects as List<Project>;
        }

        public List<Status> PopulateStatus()
        {
            var statuses = (from s in _context.Statuses
                            
                            select new Status
                            {
                                StatusId = s.StatusId,
                                Message = s.Message
                            }).ToList();

            return statuses as List<Status>;
        }


        public string getInvitationFormat(int travelId, TravelRequest approvedTravel)
        {
            //var employee = approvedTravel.EmployeeId; //employee who travel is approved
            var designation = (from e in _context.Employees
                              where e.EmployeeId == approvedTravel.EmployeeId
                               select  e.DesignationId).FirstOrDefault();
            string templatePath = (from template in _context.InvitationLetterFormats
                                  where template.DesignationId == designation
                                  select template.LetterContent).FirstOrDefault();
            return templatePath;

        }

        public InvitationLetterFeilds getFeildsForInvitationLetter(TravelRequest tr)
        {
            InvitationLetterFeilds feilds = new InvitationLetterFeilds();
            string empName;
            //get empprojId from EmployeesProjects table
            var EmpProjId = (from pe in _context.EmployeesProjects
                     where tr.EmployeeId == pe.EmployeeId &&
                     tr.ProjectId == pe.ProjectId
                     select pe.Id).FirstOrDefault();
            //check if that id exists in travel request table
            var isPresent = _context.TravelRequests.Any(i=> i.EmployeeProjectId == EmpProjId);
            if (isPresent)
            {
                

                //first get emp id for te corresponsing EmpPrjId from EmployeesProjects table

                var empId = (from pe in _context.EmployeesProjects
                             where pe.Id == EmpProjId
                             select pe.EmployeeId).FirstOrDefault();
                //get the emp name for the corresponding empId from emp table
                empName = (from e in _context.Employees
                           where e.EmployeeId == empId
                           select e.EmployeeName).FirstOrDefault();

            }
            else
            {
                throw new System.ArgumentException("employeee not connected to the project check EmployeesProjectsTable","");
            }

            var client = (from c in _context.Clients
                          where c.ClientId == tr.ClientId
                          select c.ClientName).FirstOrDefault();

            var project = (from p in _context.Projects
                           where p.ProjectId == tr.ProjectId
                           select p.ProjectName).FirstOrDefault();

            var managerId = (from p in _context.Projects
                            where p.ProjectId == tr.ProjectId
                            select p.InchargeId).FirstOrDefault();

            var managerName = (from e in _context.Employees
                               where e.EmployeeId == managerId
                               select e.EmployeeName).FirstOrDefault();

            feilds.EmployeeName = empName;
            feilds.StartDate = tr.StartDate;
            feilds.EndDate = tr.EndDate;
            feilds.Place = tr.Place;
            feilds.ProjectName = project;
            feilds.ClientName = client;
            feilds.empId = tr.EmployeeId;
            feilds.travelId = tr.TravelId;
            feilds.travelName = tr.TravelRequestName;
            feilds.managerName = managerName;

            return feilds;

             
        }

        public void insertFilePath(string filePath,int travelId)
        {
            var travelRequest = (from tr in _context.TravelRequests
                                 where tr.TravelId == travelId
                                 select tr).FirstOrDefault();
            travelRequest.InvitationLetterPath = filePath;
            _context.SaveChanges();

        }


        //manager
        public void insertTravelDetails(NewRequestViewModelOnSubmit outputModel)
        {
            using (var ctx = new da.KDTravelPortalDbContext())
            {
                
                foreach (var tr in outputModel.travelRequests)
                {
                    
                    bool isClientFound = false;
                    bool isTrvelTypeFound = false;
                    bool isEmpWorkingUnderTheProject = false;
                    bool isStatusfound = false;

                    if (ctx.TravelTypes.Any(tt => tt.TravelTypeId == tr.TravelTypeId))
                    {
                        isTrvelTypeFound = true;
                    }
                    else
                    {
                        throw new System.ArgumentException("This TravelType is not Found", "tr.TravelTypeId");
                    }
                    if (ctx.Clients.Any(c => c.ClientId == tr.ClientId))
                    {
                        isClientFound = true;
                    }
                    else
                    {
                        throw new System.ArgumentException("This Client is not Found", "tr.ClientId");
                    }
                    if (ctx.Statuses.Any(s => s.StatusId == tr.StatusId))
                    {
                        isStatusfound = true;
                    }
                    else
                    {
                        throw new System.ArgumentException("This status is not Found", "tr.StatusId");
                    }
                    if (ctx.EmployeesProjects.Any(ep => ep.Id == (from x in ctx.EmployeesProjects
                                                                  where x.ProjectId == tr.ProjectId &&
                                                                  x.EmployeeId == tr.EmployeeId
                                                                  select x.Id).FirstOrDefault()))
                                             
                    {
                        isEmpWorkingUnderTheProject = true;
                    }
                    else
                    {
                        throw new System.ArgumentException("tr.employeeId  doesnt work under tr.projectId so you cannot assign a travel request for him for this project,kindly check the table EmployeesProject to know the employees and their respective Projects", "");
                    }
                    if(isClientFound && isStatusfound && isTrvelTypeFound && isEmpWorkingUnderTheProject)
                    {
                        ctx.TravelRequests.Add(new da.TravelRequest()
                        {
                            TravelRequestName = tr.TravelRequestName,
                            StartDate = tr.StartDate,
                            EndDate = tr.EndDate,
                            Place = tr.Place,
                            TravelType = ctx.TravelTypes.FirstOrDefault(i => i.TravelTypeId == tr.TravelTypeId),

                            TravelTypeId = tr.TravelTypeId,


                            EmployeeProjectId = (from ep in ctx.EmployeesProjects
                                                 where ep.ProjectId == tr.ProjectId &&
                                                 ep.EmployeeId == tr.EmployeeId
                                                 select ep.Id).FirstOrDefault(),
                            Employee_Project = ctx.EmployeesProjects.FirstOrDefault(i => i.Id == (from ep in ctx.EmployeesProjects
                                                                                                  where ep.ProjectId == tr.ProjectId &&
                                                                                                  ep.EmployeeId == tr.EmployeeId
                                                                                                  select ep.Id).FirstOrDefault()),

                            Client = ctx.Clients.FirstOrDefault(i => i.ClientId == tr.ClientId),
                            ClientId = tr.ClientId,
                            Status = ctx.Statuses.FirstOrDefault(i => i.StatusId == tr.StatusId),
                            StatusId = tr.StatusId

                        });

                        //TravelType t = ctx.TravelTypes.FirstOrDefault(i => i.TravelTypeId == tr.TravelTypeId);

                        ctx.SaveChanges();
                    }
                    else
                    {
                        throw new System.ArgumentException("Null value is being assigned chk all constrains", "");
                    }

                }

            }

        }

        

        public List<TravelRequest> ViewTravelRequests(int managerId)
        {

            var travellingEmp = (from tr in _context.TravelRequests
                                 join ep in _context.EmployeesProjects on

                                 tr.EmployeeProjectId equals ep.Id
                                 join p in _context.Projects on
                                 ep.ProjectId equals p.ProjectId


                                 where p.InchargeId == managerId

                                 join s in _context.Statuses on
                                 tr.StatusId equals s.StatusId

                                 join c in _context.Clients on
                                 tr.ClientId equals c.ClientId

                                 join tt in _context.TravelTypes on
                                 tr.TravelTypeId equals tt.TravelTypeId

                                 select new TravelRequest {
                                     TravelId = tr.TravelId,
                                     TravelRequestName = tr.TravelRequestName,
                                     StartDate = tr.StartDate,
                                     EndDate = tr.EndDate,
                                     Place = tr.Place,
                                     EmployeeId = (from pe in _context.EmployeesProjects
                                                   where pe.Id == tr.EmployeeProjectId
                                                   select pe.EmployeeId).FirstOrDefault(),
                                     
                                     StatusId = s.StatusId,
                                     ClientId = c.ClientId,
                                     ProjectId = (from pe in _context.EmployeesProjects
                                                  where pe.Id == tr.EmployeeProjectId
                                                  select pe.ProjectId).FirstOrDefault(),
                                   TravelTypeId = tt.TravelTypeId
                                }).ToList();

            return travellingEmp as List<TravelRequest>;
        }

        public List<TravelRequest> DeleteTravelRecord(int travelId, int managerId)
        {
            List<TravelRequest> updatedList = new List<TravelRequest>(); 
           var record = _context.TravelRequests.SingleOrDefault(i => i.TravelId == travelId);

            if(record != null)
            {
                try
                {
                    
                    _context.TravelRequests.Remove(record);

                    _context.SaveChanges();
                    

                    updatedList = this.ViewTravelRequests(managerId);

                    return updatedList;

                }
                catch (SqlException err)
                {
                    throw new System.ArgumentException("something went wrong in context class", "_context");

                }

            }
            else
            {
                throw new System.ArgumentException("Parameter cannot be null", "TravellingEmp");
            }



        }

        public List<TravelRequest> EditTravelRequest(int mgrId,int travelId,TravelRequest updatedModel)
        {
            List<TravelRequest> updatedList = new List<TravelRequest>();
            var record = _context.TravelRequests.SingleOrDefault(i => i.TravelId == travelId);
            record.TravelRequestName = updatedModel.TravelRequestName;
            record.TravelTypeId = updatedModel.TravelTypeId;
            record.StartDate = updatedModel.StartDate;
            record.EndDate = updatedModel.EndDate;
            record.Place = updatedModel.Place;
            record.EmployeeProjectId = (from ep in _context.EmployeesProjects
                                        where ep.EmployeeId == updatedModel.EmployeeId
                                        && ep.ProjectId == updatedModel.ProjectId
                                        select ep.Id).FirstOrDefault();
                                       
            record.ClientId = updatedModel.ClientId;
            record.StatusId = updatedModel.StatusId;
            record.TravelType = _context.TravelTypes.FirstOrDefault(i => i.TravelTypeId == record.TravelTypeId);
            record.Employee_Project = _context.EmployeesProjects.FirstOrDefault(i => i.Id == record.EmployeeProjectId);
            record.Client = _context.Clients.FirstOrDefault(i => i.ClientId == record.ClientId);
            record.Status = _context.Statuses.FirstOrDefault(i => i.StatusId == record.StatusId);
            _context.SaveChanges();
            updatedList = this.ViewTravelRequests(mgrId);
            return updatedList;

        }

    }
}
