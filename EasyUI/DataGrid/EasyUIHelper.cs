using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace EasyUI.DataGrid
{
    /// <summary>
    /// EasyUI助理
    /// </summary>
    public static class EasyUIHelper
    {
        /// <summary>
        /// EasyUI-DataGrid 相关
        /// </summary>
        public static class DataGrid
        {
            /// <summary>
            /// 根据客户端生成服务端条件对象
            /// </summary>
            /// <param name="CurrentContext"></param>
            /// <returns></returns>
            public static DataGridPostInfo GetClientRequestInfo(HttpContext CurrentContext)
            {
                return new DataGridPostInfo(CurrentContext);
            }

            /// <summary>
            /// 返回结果
            /// </summary>
            /// <typeparam name="T"></typeparam>
            /// <param name="ListT"></param>
            /// <param name="RecordTotalNum"></param>
            /// <returns></returns>
            public static DataGridResult<T> GetReutrnList<T>(List<T> ListT, Int32 RecordTotalNum)
            {
                return new DataGridResult<T> { rows = ListT, total = RecordTotalNum };
            }
        }


    }
}
