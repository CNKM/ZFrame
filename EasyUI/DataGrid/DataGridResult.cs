using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUI.DataGrid
{
    /// <summary>
    /// EasyUI 结果
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataGridResult<T>
    {
        /// <summary>
        /// 记录总数
        /// </summary>
        public Int32 total { get; set; }
        /// <summary>
        /// 数据记录
        /// </summary>
        public List<T> rows { get; set; }
    }


}
