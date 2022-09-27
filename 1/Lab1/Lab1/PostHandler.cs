using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Lab1
{
    public class PostHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            HttpRequest request = context.Request;
            HttpResponse response = context.Response;

            response.ContentType = "application/json";

            int number;

            if (int.TryParse(request.Params["result"], out number))
            {
                try
                {
                    if (context.Session["SessionData"] == null)
                    {
                        context.Session["SessionData"] = serializer.Serialize(new
                        {
                            result = number,stack = new Stack<int>(new int[] { })
                        });
                    }

                    var SessionData = (string)context.Session["SessionData"];

                    dynamic data = JObject.Parse(SessionData);

                    var array = data.stack;
                    int[] newArray = ((JArray)array).Select(item => (int)item).ToArray();

                    context.Session["SessionData"] = serializer.Serialize(new
                    {
                        result = number,stack = newArray
                    });

                    var resp = serializer.Serialize(new
                    {
                        status = "Success",stack = newArray,result = number 
                    });
                    response.Write(resp);
                }
                catch (InvalidOperationException)
                {
                    response.Write(serializer.Serialize(new { status = "Failed" }));
                }
            }
            else
            {
                response.StatusCode = 500;
                response.Write(serializer.Serialize(new { error = new { message = "Type of result is not int", result = request.Params["result"] } }));
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}