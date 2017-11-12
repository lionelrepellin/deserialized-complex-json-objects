using DeserializedComplexJsonObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace DeserializedComplexJsonObjects.Controllers
{
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        public IHttpActionResult Post([FromBody]IForm form)
        {
            if (!form.IsValid())
                return InternalServerError(new Exception("Object is invalid."));

            return Ok($"{form.Type} area : {form.CalculateArea()}");
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
