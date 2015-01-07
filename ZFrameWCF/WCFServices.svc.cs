using BLL.SYS;
using EasyUI.DataGrid;
using Entity.SYS;
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


namespace ZFrameWCF
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
        public Stream Login_UserCheck(String UserName, String PassWord, String CheckCode)
        {
            T_SYS_User_BLL UserBLL = new T_SYS_User_BLL();
            T_SYS_Dept t_SYS_ORG_Dept;
            T_SYS_Role t_SYS_ORG_Position;
            T_SYS_UserInfo t_SYS_ORG_Person;
            List<T_SYS_FunctionRight> UserFuncs;
            List<T_SYS_Role> ChoosePositionSource;
            UserBLL.CheckUserLogin(UserName, PassWord, out t_SYS_ORG_Dept, out t_SYS_ORG_Position, out t_SYS_ORG_Person, out UserFuncs, out ChoosePositionSource);
            return UserName.ToStream();
        }

    }
}
