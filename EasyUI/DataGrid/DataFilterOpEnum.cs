using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EasyUI.DataGrid
{
    public enum DataFilterOpEnum
    {

        equal,
        greater,
        less,
        GreaterThanOrEqual,
        LessThanOrEqual,
        contains,
        startswith,
        endswith

    }

    public enum DataSortType
    {
        /// <summary>
        /// 升序
        /// </summary>
        asc,
        /// <summary>
        /// 降序
        /// </summary>
        desc,
        /// <summary>
        /// 没有
        /// </summary>
        none

    }
}