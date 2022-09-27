using Lab3.Models;
using Lab3.Utils.Request;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Dynamic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using System.Xml.Linq;

namespace Lab3.Controllers
{
    public class StudentController : ApiController
    {
        private WebServicesEntities _context = new WebServicesEntities();


        [HttpGet]
        [ResponseType(typeof(Students))]
        public object GetStudent(int id, string columns = "id, name, phone", string type="json")
        {
            Students student = _context.Students.Find(id);           

            if (type == "json")
            {
                if (student == null)
                {
                    return Content(HttpStatusCode.NotFound, new HATEOAS("/api/error/404", "error.404"));
                }
                return Content(HttpStatusCode.OK, new { student, Links = new HATEOAS("/api/student/" + id, "self") });
            }
            else
            {
                if (student == null)
                {
                    var xElementsE = new List<XElement>();
                    var xHrefE = new XElement("href", $"/api/error/404");
                    var linksXmlE = new List<XElement>();
                    linksXmlE.Add(xHrefE);
                    return Content(HttpStatusCode.NotFound, linksXmlE, Configuration.Formatters.XmlFormatter);
                }

                var xElements = new List<XElement>();
                var xHref = new XElement("href", $"/api/student/{id}");

                var linksXml = new List<XElement>();
                linksXml.Add(xHref);

                var xId = new XAttribute("id", id);
                var xName = new XAttribute("name", student.Name);
                var xPhone = new XAttribute("phone", student.Phone);
                var xUser = new XElement("student", linksXml);

                if (columns.Contains("id"))
                {
                    xUser.Add(xId);
                }
                if (columns.Contains("name"))
                {
                    xUser.Add(xName);
                }
                if (columns.Contains("phone"))
                {
                    xUser.Add(xPhone);
                }
                xElements.Add(xUser);

                return Content(HttpStatusCode.OK, xElements, Configuration.Formatters.XmlFormatter);

            }


        }

        [HttpGet]
        public IHttpActionResult Get(int limit = 2,
                int offset = 0,
                int minId = 0,
                int maxId = 100,
                string sort = "ID",
                string columns = "id, name, phone",
                string like = null,
                string globalLike = null,
                String type = "json")
        {
            var students = _context.Students.Where(x => x.Id > 0).AsNoTracking();

            if (sort.ToLower() == "name")
            {
                students = students.OrderBy(prop => prop.Name);
            }
            else if (sort.ToLower() == "id")
            {
                students = students.OrderBy(prop => prop.Id);
            }
            else if (sort.ToLower() == "phone")
            {
                students = students.OrderBy(prop => prop.Phone);
            }

            students = students
               .Where(prop => prop.Id >= minId && prop.Id <= maxId)
               .Skip(offset)
               .Take(limit);

            if (like != null)
            {
                students = students.Where(prop => prop.Name.ToLower().Contains(like.ToLower()));
            }

            if (globalLike != null)
            {
                students = students.Where(prop => (prop.Name + prop.Id.ToString() + prop.Phone).ToLower().Contains(globalLike.ToLower()));
            }

            var res = new List<dynamic>();
            var xElements = new List<XElement>();
            foreach (var item in students)
            {
                if (type.ToLower() == "xml")
                {
                    var xHref = new XElement("href", $"/api/student/{item.Id}");

                    var linksXml = new List<XElement>();
                    linksXml.Add(xHref);

                    var xId = new XAttribute("id", item.Id);
                    var xName = new XAttribute("name", item.Name);
                    var xPhone = new XAttribute("phone", item.Phone);
                    var xUser = new XElement("student", linksXml);

                    if (columns.Contains("id"))
                    {
                        xUser.Add(xId);
                    }
                    if (columns.Contains("name"))
                    {
                        xUser.Add(xName);
                    }
                    if (columns.Contains("phone"))
                    {
                        xUser.Add(xPhone);
                    }
                    xElements.Add(xUser);
                }
                else
                {
                    dynamic temp = new ExpandoObject();
                    if (columns.Contains("id"))
                    {
                        temp.Id = item.Id;
                    }
                    if (columns.Contains("name"))
                    {
                        temp.Name = item.Name;
                    }
                    if (columns.Contains("phone"))
                    {
                        temp.Phone = item.Phone;
                    }
                    temp.Links = new
                    {
                        href = $"/api/student/{item.Id}",
                        rel = "User",
                    };
                    res.Add(temp);
                }
            }

            switch (type)
            {
                case "xml":
                    {
                        return Content(HttpStatusCode.OK, xElements, Configuration.Formatters.XmlFormatter);
                    }
                case "json":
                default:
                    return Content(HttpStatusCode.OK, res, Configuration.Formatters.JsonFormatter);
            }
        }

        [HttpPost]
        [ResponseType(typeof(Students))]
        public object PostStudent(Students student)
        {
            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, links = new HATEOAS("/api/error/400", "error.400") });
            }

            _context.Students.Add(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.Created, new { student, links = new HATEOAS("/api/student/" + student.Id, "self") });
        }

        [HttpPut]
        [ResponseType(typeof(Students))]
        public object PutStudent(int id,Students student)
        {
             student.Id = id;

            if (!ModelState.IsValid)
            {
                return Content(HttpStatusCode.BadRequest, new { ModelState, links = new HATEOAS("/api/error/400", "error.400") });
            }
            try
            {
                _context.Entry(student).State = EntityState.Modified;
                _context.SaveChanges();
                return Content(HttpStatusCode.OK, new { student, links = new HATEOAS("/api/Students/" + student.Id, "self") });
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StudentExists(id))
                {
                    return Content(HttpStatusCode.NotFound, new HATEOAS("/api/Error/404", "error.404"));
                }
                else
                {
                    throw;
                }
            }
        }

        [HttpDelete]
        [ResponseType(typeof(Students))]
        public IHttpActionResult DeleteStudent(int id)
        {
            Students student = _context.Students.Find(id);
            if (student == null)
            {
                return Content(HttpStatusCode.NotFound, new { links = new HATEOAS("/api/error/404", "error.404") });
            }

            _context.Students.Remove(student);
            _context.SaveChanges();

            return Content(HttpStatusCode.NoContent, new { links = new HATEOAS("/api/student/" + id, "self") });
        }

        private bool StudentExists(int id)
        {
            return _context.Students.Count(x => x.Id == id) > 0;
        }
    }
}
