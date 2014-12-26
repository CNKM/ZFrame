using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI.DataGrid
{
    /// <summary>
    /// 客户端EasyUI-DataGrid信息
    /// </summary>
    public class DataGridPostInfo
    {
        /// <summary>
        /// 
        /// </summary>
        public String sort { get; set; }

        public DataSortType order { get; set; }
        public Int32 CurrentPage { get; set; }

        public Int32 PageSize { get; set; }

        public List<DataGridFilterRule> FilterRules { get; set; }

        /// <summary>
        /// 根据当前会话获取传递信息
        /// </summary>
        /// <param name="CurrentContext"></param>
        public DataGridPostInfo(HttpContext CurrentContext)
        {
            CurrentPage = CurrentContext.Request["rows"] != null ? Convert.ToInt32(CurrentContext.Request["rows"].ToString()) : 0;
            PageSize = CurrentContext.Request["page"] != null ? Convert.ToInt32(CurrentContext.Request["page"].ToString()) : 0;
            FilterRules = CurrentContext.Request["filterRules"] != null ? Newtonsoft.Json.JsonConvert.DeserializeObject<List<DataGridFilterRule>>(CurrentContext.Request["filterRules"].ToString()) : null;
            sort = CurrentContext.Request["sort"] != null ? CurrentContext.Request["sort"].ToString() : "";
            if (CurrentContext.Request["order"] != null)
            {
                order =(DataSortType) Enum.Parse(typeof(DataSortType), CurrentContext.Request["order"].ToString());
            }
            else
            {
                order = DataSortType.none;
            }
        }

    }


}