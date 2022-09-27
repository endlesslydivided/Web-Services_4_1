using Lab2.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Lab2.Controllers
{
    public class ValuesController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Get()
        {
            int top;
            if (Result.stack.TryPeek(out top))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result + top, stack = Result.stack });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result, stack = "Stack is empty" });
            }
        }

        [HttpPost]
        public HttpResponseMessage Post([FromBody] ResultDTO result)
        {
            if (result.Result != null)
            {
                Result.result = (int)result.Result;
                int top;
                if (Result.stack.TryPeek(out top))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result + top, stack = Result.stack });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result, stack = "Stack is empty" });
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = new { message = "Type of Params is not int", result = result } });
            }
        }

        [HttpPut]
        public object Put([FromBody] ResultDTO result)
        {
            if (result.Add != null)
            {
                Result.stack.Push((int)result.Add);
                int top;
                if (Result.stack.TryPeek(out top))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result + top, stack = Result.stack });
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result, stack = "Stack is empty" });
                }
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest, new { error = new { message = "Type of Add is not int"} });
            }
        }

        [HttpDelete]
        public object Delete()
        {
            int top;
            if (Result.stack.TryPop(out top) && Result.stack.TryPeek(out top))
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result + top, stack = Result.stack });
            }
            else
            {
                return Request.CreateResponse(HttpStatusCode.OK, new { result = Result.result, stack = "Stack is empty" });
            }
        }
    }
}