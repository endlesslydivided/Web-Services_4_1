﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Lab3.Utils.Request
{
    public class RequestParams
    {
        public int Limit { get; set; } = 2;
        public int Offset { get; set; } = 0;
        public int MinId { get; set; } = 0;
        public int MaxId { get; set; } = 100;
        public string Sort { get; set; } = "ID";
        public string Columns { get; set; } = "id, name, phone";
        public string Like { get; set; } = null;
        public string GlobalLike { get; set; } = null;
        public string Type { get; set; } = "json";

    }
}