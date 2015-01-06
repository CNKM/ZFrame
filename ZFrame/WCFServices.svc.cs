using BLL;
using EasyUI.DataGrid;
using Entity;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Text;
using System.Web;
using ZFrameCore.Common;


namespace ZFrameWeb
{


    [ServiceContract(Namespace = "")]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class WCFServices
    {

        public WCFServices()
        {

        }

        [WebGet]
        [OperationContract]
        public Stream GetListUsers(String LoginName = "", String LoginPWD = "")
        {

            var t = EasyUIHelper.DataGrid.GetClientRequestInfo(HttpContext.Current);
            T_SYS_User_BLL UB = new T_SYS_User_BLL();
            IsoDateTimeConverter timeConverter = new IsoDateTimeConverter();
            //这里使用自定义日期格式，如果不使用的话，默认是ISO8601格式
            timeConverter.DateTimeFormat = "yyyy-MM-dd HH:mm:ss";
            //jsonObject是准备转换的对象
            String JsonString = Newtonsoft.Json.JsonConvert.SerializeObject(EasyUIHelper.DataGrid.GetReutrnList<T_SYS_User>(UB.Select(), 100), Newtonsoft.Json.Formatting.None, timeConverter);
            return JsonString.ToStream();
        }


        [WebGet]
        [OperationContract]
        public Stream GetServerDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToStream();
        }

        [WebGet]
        [OperationContract]
        public Stream Login_UserCheck(String PostValue)
        {
            ZJsonObject ZJ = new ZJsonObject(PostValue);
            string ss = ZJ["U"].ToString();
            return null;
        }

    }
}
