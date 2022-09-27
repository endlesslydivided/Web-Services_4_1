using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab8.Models
{
    public class ErrorJsonRPC
    {
        public string Jsonrpc { get; set; }
        public ErrorJSON Error { get; set; }
        public string Id { get; set; }
    }
}