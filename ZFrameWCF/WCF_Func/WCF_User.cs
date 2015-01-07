using BLL.Comm;
using BLL.SYS;
using EasyUI.DataGrid;
using Entity.SYS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using ZFrameCore.Common;
using ZFrameWCF.Comm;
namespace ZFrameWCF
{
    public partial class WCFServices
    {
        [WebGet]
        [OperationContract]
        public Stream GetListUsers(String LoginName = "", String LoginPWD = "")
        {
            var t = EasyUIHelper.DataGrid.GetClientRequestInfo(HttpContext.Current);
            T_SYS_User_BLL UB = new T_SYS_User_BLL();
            return EasyUIHelper.DataGrid.GetReutrnList<T_SYS_User>(UB.Select(), 100).ToJsonString().ToStream();
        }

        /// <summary>
        /// 用户登录验证
        /// </summary>
        /// <param name="CheckCode"></param>
        /// <param name="UserName"></param>
        /// <param name="PassWord"></param>
        /// <param name="ChooseDept"></param>
        /// <returns></returns>
        [WebGet]
        [OperationContract]
        public Stream UserLoginCheck(String CheckCode = "", String UserName = "", String PassWord = "", String ChooseDept = "")
        {
            if (WebHelper.SessionAuth(HttpContext.Current.Session, CheckCode))
            {
                try
                {
                    T_SYS_User_BLL UserBLL = new T_SYS_User_BLL();
                    List<T_SYS_Role> ReturnRoles;
                    CurrentLoginObject CLO;
                    String RS = UserBLL.CheckUserLogin(UserName, PassWord, out CLO, out ReturnRoles, ChooseDept);
                    return new WCFCallBackObj { Msg = RS, Contend = ReturnRoles }.ToJsonString().ToStream();
                }
                catch
                {
                    return new WCFCallBackObj { Msg = CALLSTRINGDEFINE.CALLEXCEPTION, Contend = null }.ToJsonString().ToStream();
                }
            }
            else
            {
                return new WCFCallBackObj { Msg = CALLSTRINGDEFINE.AUTHCODEERROR, Contend = null }.ToJsonString().ToStream();
            }
        }
    }
}