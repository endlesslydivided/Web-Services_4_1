using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;
using System.Web.SessionState;

namespace Lab1
{
    public class GetHandler : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            HttpResponse response = context.Response;

            response.ContentType = "application/json";


            try
            {
                if (context.Session["SessionData"] == null)
                {
                    context.Session["SessionData"] = serializer.Serialize(new
                    {
                        result = 0,
                        stack = new Stack<int>(new int[] { })
                    });
                }
                var SessionData = (string)context.Session["SessionData"];

                dynamic data = JObject.Parse(SessionData);
                int result = Convert.ToInt32(data.result);
                var array = data.stack;

                int[] newArray = ((JArray)array).Select(item => (int)item).ToArray();
                Stack<int> stack = new Stack<int>(new int[] { });

                foreach (int i in newArray.Reverse())
                {
                    stack.Push(Convert.ToInt32(i));
                }

                int lastElement = 0;

                if (stack.Count > 0)
                {
                    lastElement = stack.Peek();
                }

                var resp = serializer.Serialize(new
                {
                    status = "Success",result = result + lastElement,stack = stack
                });
                response.Write(resp);
            }
            catch (InvalidOperationException)
            {   
                response.StatusCode = 500;
                response.Write(serializer.Serialize(new { status = "Failed" }));
            }
        }

        public bool IsReusable
        {
            get { return false; }
        }
    }
}