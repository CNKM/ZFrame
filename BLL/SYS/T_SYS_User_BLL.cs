using Entity;
using Entity.SYS;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFrameCore.BLL;

namespace BLL.SYS
{
    public class T_SYS_User_BLL : TBLLBase<T_SYS_User>
    {
        public T_SYS_User_BLL()
        {
            this.SQLString = "Select * From T_SYS_ORG_Person A";
            this.WhereStr = "A.F_IsDel=0";
            this.OrderStr = "A.F_Index,A.F_Name";
        }

        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="tUserName">用户名称</param>
        /// <param name="tUserPWD">用户密码</param>
        /// <returns>1 通过验证 -1 未通过验证</returns>
        public String CheckUserLogin(
            string tUserName,
            string tUserPWD,
            out T_SYS_Dept t_SYS_ORG_Dept,
            out T_SYS_Role t_SYS_ORG_Position,
            out T_SYS_UserInfo t_SYS_ORG_Person,
            out List<T_SYS_FunctionRight> UserFuncs,
            out List<T_SYS_Role> ChoosePositionSource,
            String ChooseDeptid = "")
        {
            Int32 ExecResult = 0;
            List<SqlParameter> Parms = new List<SqlParameter>();
            Parms.Add(new SqlParameter() { ParameterName = "@LoginName", Value = tUserName });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginPWD", Value = tUserPWD });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginPosition", Value = ChooseDeptid });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginResult", DbType = System.Data.DbType.String, Size = 60, Direction = ParameterDirection.Output });
            DataSet returnDs = this.ExecProceureRetrunList("USP_CheckUserLogin", Parms, out ExecResult, null, false);
            String ExecResultString = Parms[3].Value.ToString();


            t_SYS_ORG_Dept = null;
            t_SYS_ORG_Person = null;
            t_SYS_ORG_Position = null;
            UserFuncs = null;
            ChoosePositionSource = null;

            if (String.IsNullOrEmpty(ExecResultString))
            {
                if (returnDs.Tables.Count == 4)
                {
                    t_SYS_ORG_Person = this.ToList<T_SYS_UserInfo>(returnDs.Tables[0])[0];
                    t_SYS_ORG_Dept = this.ToList<T_SYS_Dept>(returnDs.Tables[1])[0];
                    t_SYS_ORG_Position = this.ToList<T_SYS_Role>(returnDs.Tables[2])[0];
                    UserFuncs = this.ToList<T_SYS_FunctionRight>(returnDs.Tables[3]);
                    ChoosePositionSource = null;
                }
                return "";
            }
            else
            {

                ChoosePositionSource = returnDs.Tables.Count == 2 ? this.ToList<T_SYS_Role>(returnDs.Tables[1]) : null;
                return ExecResultString;
            }
        }



    }
}
