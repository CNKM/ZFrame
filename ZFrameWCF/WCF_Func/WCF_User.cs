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
using System.ServiceModel.Web;
using System.Web;
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
                CurrentLoginObject CurrengLoginInfo = HttpContext.Current.Session["CurrentLoginObject"] as CurrentLoginObject;
                return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS, null, CurrengLoginInfo);
            });
        }

        /// <summary>
        /// 获取当前用户的功能列表(EasyUI模式)
        /// </summary>
        /// <returns></returns>
        [WebGet]
        [OperationContract]
        public Stream GetCurrentLoginForEasyUI()
        {
            return CommFuncAction(delegate()
            {
                CurrentLoginObject CurrengLoginInfo = HttpContext.Current.Session["CurrentLoginObject"] as CurrentLoginObject;
                List<TreeData> listTD =new List<TreeData>();
                WebHelper.GetEasyUITreeData<T_SYS_Function>(CurrengLoginInfo.CurrentFuncs, ref listTD, "", null);
                CurrengLoginInfo.ExtendContend = listTD;
                return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS, null, CurrengLoginInfo);
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
        public Stream UserLoginCheck(String CheckCode = "", String UserName = "", String PassWord = "", String ChooseDept = "")
        {

            if (WebHelper.SessionAuth(HttpContext.Current.Session, CheckCode))
            {
                try
                {
                    T_SYS_User_BLL UserBLL = new T_SYS_User_BLL();
                    List<T_SYS_Role> ReturnRoles;
                    CurrentLoginObject CurrengLoginInfo;
                    String ExecReusltMsg = "";
                    Int32 ExecReusltCode = UserBLL.CheckUserLogin(UserName, PassWord, out CurrengLoginInfo, out ReturnRoles, out ExecReusltMsg, ChooseDept);
                    if (ExecReusltCode == 1)
                    {
                        HttpContext.Current.Session["CurrentLoginObject"] = CurrengLoginInfo;
                    }
                    return new CallBackReturnObject{ Code = ExecReusltCode, Msg = ExecReusltMsg, Contend = ReturnRoles }.ToStream();
                }
                catch(Exception e)
                {
                    return new CallBackReturnObject(CALLRETURNDEFINE.CALLEXCEPTION,e.Message).ToStream();
                }

            }
            else
            {
                return new CallBackReturnObject(CALLRETURNDEFINE.AUTHCODEERROR).ToStream();
            }
        }

        [WebGet]
        [OperationContract]
        public Stream UserLoginOut()
        {
            return CommFuncAction(delegate()
            {
                HttpContext.Current.Session["CurrentLoginObject"] = null;
                HttpContext.Current.Session.Remove("CurrentLoginObject");
                return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS);
            });
        }



    }
}