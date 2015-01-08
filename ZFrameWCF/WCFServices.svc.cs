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
    [ServiceContract(Namespace = "", SessionMode = SessionMode.Allowed)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class WCFServices
    {

        #region 调用模板
        /// <summary>
        /// 定义匿名委托作为统一服务调用模板
        /// </summary>
        /// <param name="WCFFunc"></param>
        /// <returns></returns>
        public Stream WCFFuncAction(Func<WCFCallBackObj> WCFFunc)
        {
            if (WCFWebConfig.NeedAuth)
            {
                if (HttpContext.Current.Session.IsSessionAuthed())
                {
                    try
                    {
                        return WCFFunc.ToString().ToStream();
                    }
                    catch
                    {
                        return new WCFCallBackObj { Msg = CALLSTRINGDEFINE.CALLEXCEPTION, Contend = null }.ToJsonString().ToStream();
                    }
                }
                else
                {
                    return new WCFCallBackObj { Msg = CALLSTRINGDEFINE.CALLWITHOUTAUTH, Contend = null }.ToJsonString().ToStream();
                }
            }
            else
            {
                return WCFFunc.ToString().ToStream();
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
            return HttpContext.Current.Session.MakeCheckCode(VCode).ToStream();
        }

        /// <summary>
        /// 服务器时间
        /// </summary>
        /// <returns></returns>
        [WebGet]
        [OperationContract]
        public Stream GetServerDateTime()
        {
            return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss").ToStream();
        }




    }
}
