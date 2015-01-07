using BLL.Comm;
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
            out CurrentLoginObject currentloginobj,
            out List<T_SYS_Role> ChoosePositionSource,
            String ChooseDeptid = "")
        {
            Int32 ExecResult = 0;
            List<SqlParameter> Parms = new List<SqlParameter>();
            Parms.Add(new SqlParameter() { ParameterName = "@LoginName", Value = tUserName });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginPWD", Value = tUserPWD });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginPosition", Value = ChooseDeptid });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginResult", DbType = System.Data.DbType.Int32, Direction = ParameterDirection.Output });
            DataSet returnDs = this.ExecProceureRetrunList("USP_CheckUserLogin", Parms, out ExecResult, null, false);
            LoginReulst CheckResult = (LoginReulst)Convert.ToInt32(Parms[3].Value);
            currentloginobj = new CurrentLoginObject();
            ChoosePositionSource = null;
            String ReutnrString = "";
            switch (CheckResult)
            {
                case LoginReulst.UserNotFind:
                    ReutnrString = "用户名或者密码错误,请重试!";
                    break;
                case LoginReulst.UserNotRole:
                    ReutnrString = "请联系管理员:用户未分配岗位角色!";
                    break;
                case LoginReulst.UserNoFuncs:
                    ReutnrString = "请联系管理员:用户岗位角色未分配功能!";
                    break;
                case LoginReulst.UserHasMuiltRole:
                    ReutnrString = "2";
                    currentloginobj = null;
                    ChoosePositionSource = returnDs.Tables.Count == 2 ? this.ToList<T_SYS_Role>(returnDs.Tables[1]) : null;
                    break;
                case LoginReulst.HasMuiltUser:
                    ReutnrString = "请联系管理员:用户表基础错误!";
                    break;
                case LoginReulst.ExecError:
                    ReutnrString = "请联系管理员:用户表检测错误!";
                    break;
                default:
                    currentloginobj.CurrentUser = this.ToList<T_SYS_UserInfo>(returnDs.Tables[0])[0];
                    currentloginobj.CurrentDept = this.ToList<T_SYS_Dept>(returnDs.Tables[1])[0];
                    currentloginobj.CurrentRole = this.ToList<T_SYS_Role>(returnDs.Tables[2])[0];
                    currentloginobj.CurrentFuncs = this.ToList<T_SYS_FunctionRight>(returnDs.Tables[3]);
                    ChoosePositionSource = null;
                    ReutnrString = "1";
                    break;
            }
            return ReutnrString;
        }



    }
}
