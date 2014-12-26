using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI.DataGrid
{
    public class DataGridFilterRule
    {
        public String field { get; set; }
        public DataFilterOpEnum op { get; set; }
        public object value { get; set; }
    }
}