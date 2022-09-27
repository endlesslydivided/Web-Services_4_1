using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Lab1
{
    public class PutHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            response.ContentType = "application/json";


            int number;
            var strAdd = request.Params["add"];

            if (int.TryParse(request.Params["add"], out number))
            {
                try
                {
                    if (context.Session["SessionData"] == null)
                    {
                        context.Session["SessionData"] = serializer.Serialize(new
                        {
                            result = 0,stack = new Stack<int>(new int[] { })
                        });
                    }

                    var SessionData = (string)context.Session["SessionData"];

                    dynamic data = JObject.Parse(SessionData);
                    int result = Convert.ToInt32(data.result);
                    
                    var array = data.stack;
                    int[] newArray = ((Newtonsoft.Json.Linq.JArray)array).Select(item => (int)item).ToArray();
                    Stack<int> stack = new Stack<int>(new int[] { });
                    foreach (int i in newArray.Reverse())
                    {
                        stack.Push(Convert.ToInt32(i));
                    }
                    stack.Push(Convert.ToInt32(number));

                    context.Session["SessionData"] = serializer.Serialize(new
                    {
                        result = result,stack = stack
                    });

                    var resp = serializer.Serialize(new
                    {
                        status = "Success",result = result, stack = stack
                    });
                    response.Write(resp);
                }
                catch (InvalidOperationException)
                {
                    response.StatusCode = 500;
                    response.Write(serializer.Serialize(new { status = "Failed"}));
                }
            }
            else
            {
                response.StatusCode = 500;
                response.Write(serializer.Serialize(new { error = new { message = "Type of add is not int", result = request.Params["add"] } }));
            }

        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}