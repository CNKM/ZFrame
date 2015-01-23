using BLL.Comm;
using BLL.SYS;
using EasyUI.DataGrid;
using EasyUI.Tree;
using Entity.SYS;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using System.Web.Services;
using ZFrameCore.Common;
using ZFrameWCF.Comm;
namespace ZFrameWCF
{

    public partial class WCFServices
    {
        /// <summary>
        /// 获取当前用户的功能列表(原始列表)
        /// </summary>
        /// <returns></returns>
        [WebGet]
        [OperationContract]
        public Stream GetCurrentLoginUser()
        {
            return CommFuncAction(delegate()
            {
                CurrentLoginObject CurrengLoginInfo = HttpContext.Current.Session.Get<CurrentLoginObject>(USEDSESSION.CURRENTLOGINOBJECT);
                return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS, CurrengLoginInfo);
            });
        }

        /// <summary>
        /// 获取当前用户的功能列表(EasyUI模式)
        /// </summary>
        /// <returns></returns>
        [WebGet]
        [OperationContract]
        public Stream GetCurrentLoginForEasyUI(Int32 PType = 0, String FuncState = null, Boolean IsReloadFunc = false)
        {
            return CommFuncAction(delegate()
            {
                CurrentLoginObject CurrengLoginInfo = HttpContext.Current.Session.Get<CurrentLoginObject>(USEDSESSION.CURRENTLOGINOBJECT);
                if (IsReloadFunc)
                {
                    T_SYS_User_BLL BLL = new T_SYS_User_BLL();
                    BLL.ReloaduserFuncs(PType, CurrengLoginInfo,FuncState);
                    HttpContext.Current.Session.Set(USEDSESSION.CURRENTLOGINOBJECT, CurrengLoginInfo);
                }

                if (CurrengLoginInfo != null)
                {
                    WebHelper.InitFuncTreeForEasyUI(CurrengLoginInfo,FuncState);
                    return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS, CurrengLoginInfo);
                }
                else
                {
                    return new CallBackReturnObject(CALLRETURNDEFINE.CALLWITHOUTAUTH, null, "用户未登录");
                }
            });
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
        public Stream UserLoginCheck(Int32 PType = 0, String CheckCode = "", String UserName = "", String PassWord = "", String ChooseDept = "")
        {

            if (WebHelper.SessionAuth(HttpContext.Current.Session, CheckCode))
            {
                try
                {
                    T_SYS_User_BLL UserBLL = new T_SYS_User_BLL();
                    List<T_SYS_Role> ReturnRoles;
                    CurrentLoginObject CurrengLoginInfo;
                    String ExecReusltMsg = "";
                    Int32 ExecReusltCode = UserBLL.CheckUserLogin(PType, UserName, PassWord, out CurrengLoginInfo, out ReturnRoles, out ExecReusltMsg, ChooseDept);
                    if (ExecReusltCode == 1)
                    {
                        HttpContext.Current.Session.Set(USEDSESSION.CURRENTLOGINOBJECT, CurrengLoginInfo);
                    }
                    return new CallBackReturnObject { Code = ExecReusltCode, Msg = ExecReusltMsg, Contend = ReturnRoles }.ToStream();
                }
                catch (Exception e)
                {
                    return new CallBackReturnObject(CALLRETURNDEFINE.CALLEXCEPTION, e.Message).ToStream();
                }

            }
            else
            {
                return new CallBackReturnObject(CALLRETURNDEFINE.AUTHCODEERROR).ToStream();
            }
        }
        [WebGet]
        [OperationContract]
        public Stream GetSessionAuthState()
        {
            Boolean ISOK = HttpContext.Current.Session.GetSessionAuthState();
            return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS, ISOK).ToStream();
        }
        [WebGet]
        [OperationContract]
        public Stream UserLoginOut()
        {
            return CommFuncAction(delegate()
            {
                HttpContext.Current.Session.Remove(USEDSESSION.CURRENTLOGINOBJECT);
                return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS);
            });

        }



    }
}