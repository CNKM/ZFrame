using BLL.Comm;
using Entity.SYS;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Web;
using ZFrameCore.Common;
namespace ZFrameWCF
{
    public partial class WCFServices
    {

        [WebGet]
        [OperationContract]
        public Stream SAVE_Single_SYS_Function(String PostEntity)
        {
            return CommFuncAction(delegate()
            {
                if (!String.IsNullOrEmpty(PostEntity))
                {
                    List<T_SYS_Function> Funcs = PostEntity.FromJsonString<List<T_SYS_Function>>();
                    BLL.SYS.T_SYS_Function_BLL CurrentBLL = new BLL.SYS.T_SYS_Function_BLL();
                    String ExecMSG = "";
                    Int32 ExecReSult = CurrentBLL.TransactionDo(
                    delegate(SqlTransaction X)
                    {
                        for (int i = 0; i < Funcs.Count; i++)
                        {
                            CurrentBLL.Save(Funcs[i], X);
                        }
                    }, out ExecMSG);
                    if (ExecReSult == 0)
                    {
                        return new CallBackReturnObject(CALLRETURNDEFINE.EXECSUCCESS);
                    }
                    else
                    {
                        return new CallBackReturnObject(CALLRETURNDEFINE.CALLEXCEPTION);
                    }

                }
                else
                {
                    return new CallBackReturnObject(CALLRETURNDEFINE.POSTERROR);
                }
            });

        }

    }
}