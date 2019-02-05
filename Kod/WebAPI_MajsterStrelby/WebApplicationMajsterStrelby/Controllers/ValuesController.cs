using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace WebApplicationMajsterStrelby.Controllers
{
    //[Authorize]
    public class ValuesController : ApiController
    {
        static List<string> data = initList();

        private static List<string> initList()
        {
            var data = new List<string>();
            data.Add("Value1");
            data.Add("Value2");
            return data;
        }

        // GET api/values
        public IEnumerable<string> Get()
        {
            return data;
        }

        // GET api/values/5
        public HttpResponseMessage Get(int id)
        {
            if (data.Count > id)
                return Request.CreateResponse<string>(HttpStatusCode.OK, data[id]);
            else
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Item with this index is not in data");
        }

        // POST api/values
        public HttpResponseMessage Post([FromBody]string value)
        {
            data.Add(value);
            var msg = Request.CreateResponse(HttpStatusCode.Created);
            msg.Headers.Location = new Uri(Request.RequestUri + (data.Count-1).ToString());

            return msg;
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
            if (data.Count > id)
                data[id] = value;
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
