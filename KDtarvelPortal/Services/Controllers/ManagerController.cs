using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessModels;
using BusinessLogic;
using System.Web.Http.Description;

namespace Services
{
    public class ManagerController : ApiController
    {

        
        // GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        // GET api/<controller>/5
        [ResponseType(typeof(List<TravelRequest>))]
        [HttpGet]
        public IHttpActionResult GetViewTravel(int id)
        {
            List<TravelRequest> te = new List<TravelRequest>();
            Manager manager = new Manager(te);

            te = manager.ViewTravelRequests(id);
            return Json(te);

        }

        //[ResponseType(typeof(List<TravellingEmp>))]
        



        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        // PUT api/<controller>/5
        [ResponseType(typeof(List<TravelRequest>))]
        [HttpPost]
        //public IHttpActionResult EditTravelRequest(int managerId, int travelId, TravellingEmp updatedModel)
        //{
        //    List<TravellingEmp> te = new List<TravellingEmp>();
        //    Manager manager = new Manager(te);

        //    te = manager.EditTravelRequest(managerId, travelId,updatedModel);
        //    return Json(te);

        //}
        public IHttpActionResult EditTravelRequest(int managerId, int travelId, TravelRequest updatedModel)
        {
            List<TravelRequest> te = new List<TravelRequest>();
            Manager manager = new Manager(te);

            te = manager.EditTravelRequest(managerId, travelId, updatedModel);
            return Json(te);

        }

        //DELETE api/<controller>/5
        [ResponseType(typeof(List<TravelRequest>))]
        [HttpGet]
        //public IHttpActionResult DeleteTravel(int managerId,int travelId)
        //{
        //    List<TravellingEmp> te = new List<TravellingEmp>();
        //    Manager manager = new Manager(te);

        //    te = manager.DeleteTravelRequest(managerId,travelId);
        //    return Json(te);

        //}

        public IHttpActionResult DeleteTravel(int managerId, int travelId)
        {
            List<TravelRequest> te = new List<TravelRequest>();
            Manager manager = new Manager(te);

            te = manager.DeleteTravelRequest(managerId, travelId);
            return Json(te);

        }
    }
}