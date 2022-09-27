using Lab4.ASMX;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;

namespace Lab4_ASMX
{
    /// <summary>
    /// Сводное описание для Simplex
    /// </summary>
    [WebService(Description = "Simplex - веб-служба", Namespace = "http://KAA/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    [ScriptService]
    // Чтобы разрешить вызывать веб-службу из скрипта с помощью ASP.NET AJAX, раскомментируйте следующую строку.
    // [System.Web.Script.Services.ScriptService]
    public class Simplex : WebService
    {
        [WebMethod(Description = "Сложение чисел x+y", EnableSession = true, MessageName = "AddMessage")]
        public int Add(int x, int y)
        {
            return x + y;
        }

        [WebMethod(Description = "Конкатенация строки s и числа d", EnableSession = true, MessageName = "ConcatMessage")]
        public string Concat(string s, double d)
        {
            return s + d.ToString();
        }

        [WebMethod(Description = "Возвращает объект А", EnableSession = true, MessageName = "SumMessage")]
        public A Sum(A a1, A a2)
        {
            return new A(string.Concat(a1.s, a2.s), a1.k + a2.k, a1.f + a2.f);
        }

        [ScriptMethod(ResponseFormat=ResponseFormat.Json)]
        [WebMethod(Description = "Сложение чисел x+y. JSON", EnableSession = true, MessageName = "AddMessageJSON")]
        public string AddS(int x, int y)
        {
            string result = JsonConvert.SerializeObject(x + y);
            return result;
        }
    }
}
