using System;
using System.IO;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Web;
using ZFrameCore.Common;
using ZFrameWCF.Comm;


namespace ZFrameWCF
{
    [ServiceContract(Namespace = "ZFrame", SessionMode = SessionMode.Allowed)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class WCFServices
    {

        #region 业务函数调用模板
        /// <summary>
        /// 定义匿名委托作为统一服务调用模板
        /// </summary>
        /// <param name="DelegateMethod">委托方法</param>
        /// <returns></returns>
        public Stream CommFuncAction(Func<CallBackReturnObject> DelegateMethod)
        {
            //配置中是否需要验证
            if (WCFWebConfig.NeedAuth)
            {
                //是否已经登录验证通过
                if (HttpContext.Current.Session.IsSessionAuthed())
                {
                    //功能菜单权限
                    String FuncCallURL = HttpContext.Current.Request.PathInfo.TrimStart('/');
                    try
                    {
                        return DelegateMethod.ToJsonString().ToStream();
                    }
                    catch(Exception e)
                    {
                        return new CallBackReturnObject(CALLRETURNDEFINE.CALLEXCEPTION,e.Message).ToStream();
                    }
                }
                else
                {
                    return new CallBackReturnObject(CALLRETURNDEFINE.CALLWITHOUTAUTH).ToStream();
                }
            }
            else
            {
                return DelegateMethod.ToJsonString().ToStream();
            }
        }
        #endregion

        public WCFServices()
        {

        }

        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="VCode"></param>
        /// <returns></returns>
        [WebGet]
        [OperationContract]
        public Stream GetCheckCodeImage(String VCode = "")
        {
            try
            {
                return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS,null, HttpContext.Current.Session.MakeCheckCode(VCode)).ToStream();
            }
            catch
            {
                return new CallBackReturnObject(CALLRETURNDEFINE.CALLEXCEPTION).ToStream();
            }

        }

        /// <summary>
        /// 服务器时间
        /// </summary>
        /// <returns></returns>
        [WebGet]
        [OperationContract]
        public Stream GetServerDateTime()
        {
            try
            {
                return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS, DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss")).ToStream();
            }
            catch
            {
                return new CallBackReturnObject(CALLRETURNDEFINE.CALLEXCEPTION).ToStream();
            }
        }




    }
}
