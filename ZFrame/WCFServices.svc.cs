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
            return EasyUIHelper.DataGrid.GetReutrnList<T_SYS_User>(UB.Select(), 100).ToJsonString().ToStream();
        }

        [WebGet]
        [OperationContract]
        public Stream GetServerDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToStream();
        }

        [WebGet]
        [OperationContract]
        public Stream Login_UserCheck(String UserName,String PassWord,String CheckCode)
        {
            return null;
        }

    }
}
