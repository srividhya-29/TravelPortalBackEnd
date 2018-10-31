using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using BusinessLogic;
using BusinessModels;

namespace Services.Controllers
{
    public class AdminController : ApiController
    {
        //[HttpGet]
        //public IHttpActionResult ViewAllTravels()
        //{
        //    List<TravellingEmp> te = new List<TravellingEmp>();
        //    Admin admin = new Admin(te);

        //    te = admin.ViewAllTravels();
        //    return Json(te);

        //}
        [HttpGet]
        public IHttpActionResult ViewAllTravels()
        {
            List<TravelRequest> te = new List<TravelRequest>();
            Admin admin = new Admin(te);

            te = admin.ViewAllTravels();
            return Json(te);

        }

        //[HttpPost]
        //public IHttpActionResult ApproveTravel(int travelId,TravellingEmp approvedTravel)
        //{
        //    List<TravellingEmp> te = new List<TravellingEmp>();
        //    Admin admin = new Admin(te);

        //    te = admin.ApproveTravel(travelId,approvedTravel);
        //    return Json(te);

        //}

        [HttpPost]
        public IHttpActionResult ApproveTravel(int travelId, TravelRequest approvedTravel)
        {
            List<TravelRequest> te = new List<TravelRequest>();
            Admin admin = new Admin(te);

            te = admin.ApproveTravel(travelId, approvedTravel);
            return Json(te);

        }


        //// GET api/<controller>
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET api/<controller>/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST api/<controller>
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT api/<controller>/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE api/<controller>/5
        //public void Delete(int id)
        //{
        //}
    }
}