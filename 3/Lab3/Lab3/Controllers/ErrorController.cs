using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace Lab3.Controllers
{
    public class ErrorController : ApiController
    {
        [HttpGet]
        public object Error(int id)
        {
            switch(id)
            {
                default:
                case 404:
                    {
                        return Content(System.Net.HttpStatusCode.OK, "Ошибка 404. Ресурс не найден.");
                    }
            }

        }
    }
}