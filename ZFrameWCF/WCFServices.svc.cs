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
