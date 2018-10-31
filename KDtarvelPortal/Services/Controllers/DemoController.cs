using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using BusinessLogic;

using BusinessModels;



namespace Services
{
    public class DemoController : ApiController
    {
        //// GET api/<controller>

        //public String Get()
        //{
        //    BusinessLogicLayer b = new BusinessLogicLayer();
        //    Employee e = b.display();



        //    return e.EmployeeName;
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
        [ResponseType(typeof(NewRequestViewModel))]
        [HttpGet]
        public IHttpActionResult GetNewRequest(int id)
        {
            NewRequestViewModel vm = new NewRequestViewModel();
            Manager manager = new Manager(vm);
            manager.RaiseNewRequest(id);
            return Json(vm);
        }

        [HttpPost]
        public IHttpActionResult Post(NewRequestViewModelOnSubmit output)
        {
            if (!ModelState.IsValid)
                return BadRequest("Invalid Data");
            Manager manager = new Manager(output);
            manager.SubmitRequest(output);
            return Ok("Success");

        }


    }
}