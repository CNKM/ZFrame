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
        /// 重新加载当前登陆者功能及权限
        /// </summary>
        /// <param name="PlatformType"></param>
        /// <param name="_CurrentLoingObject"></param>
        /// <returns></returns>
        public Int32 ReloaduserFuncs(Int32 PlatformType, CurrentLoginObject _CurrentLoingObject, String FuncState = null)
        {
            Int32 ExecResult = 0;
            List<SqlParameter> Parms = new List<SqlParameter>();
            Parms.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = PlatformType, DbType = System.Data.DbType.Int32 });
            Parms.Add(new SqlParameter() { ParameterName = "@UserSN", Value = _CurrentLoingObject.CurrentUser.F_SN });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginPosition", Value = _CurrentLoingObject.CurrentRole.F_SN });
            DataSet returnDs = this.ExecProceureRetrunList("USP_ReloadFunc", Parms, out ExecResult, null, true);
            _CurrentLoingObject.CurrentFuncs.Clear();
            _CurrentLoingObject.CurrentFuncs = null;
            if (!String.IsNullOrEmpty(FuncState))
            {
                _CurrentLoingObject.CurrentFuncs = this.ToList<T_SYS_Function>(returnDs.Tables[0]).Where(x => x.F_State == Convert.ToInt32(FuncState)).ToList();
            }
            else
            {
                _CurrentLoingObject.CurrentFuncs = this.ToList<T_SYS_Function>(returnDs.Tables[0]);
            }
            _CurrentLoingObject.CurrentFuncsRight.Clear();
            _CurrentLoingObject.CurrentFuncsRight = null;
            _CurrentLoingObject.CurrentFuncsRight = this.ToList<T_SYS_FunctionRight>(returnDs.Tables[1]);
            return Convert.ToInt32(Parms[0].Value);
        }


        /// <summary>
        /// 验证用户登录
        /// </summary>
        /// <param name="PlatformType">平台类别</param>
        /// <param name="tUserName">用户名称</param>
        /// <param name="tUserPWD">用户密码</param>
        /// <returns>1 通过验证 -1 未通过验证</returns>
        public Int32 CheckUserLogin(
            Int32 PlatformType,
            string tUserName,
            string tUserPWD,
            out CurrentLoginObject currentloginobj,
            out List<T_SYS_Role> ChoosePositionSource,
            out String ReutnrString,
            String ChooseDeptid = "")
        {
            Int32 ExecResult = 0;
            List<SqlParameter> Parms = new List<SqlParameter>();
            Parms.Add(new SqlParameter() { ParameterName = "@PlatformType", Value = PlatformType, DbType = System.Data.DbType.Int32 });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginName", Value = tUserName });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginPWD", Value = tUserPWD });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginPosition", Value = ChooseDeptid });
            Parms.Add(new SqlParameter() { ParameterName = "@LoginResult", DbType = System.Data.DbType.Int32, Direction = ParameterDirection.Output });
            DataSet returnDs = this.ExecProceureRetrunList("USP_CheckUserLogin", Parms, out ExecResult, null, false);
            LoginReulst CheckResult = (LoginReulst)Convert.ToInt32(Parms[4].Value);
            currentloginobj = new CurrentLoginObject();
            ChoosePositionSource = null;
            switch (CheckResult)
            {
                case LoginReulst.UserNotFind:
                    ReutnrString = "用户名或者密码错误,请重试!";
                    return (Int32)LoginReulst.UserNotFind;
                case LoginReulst.UserNotRole:
                    ReutnrString = "请联系管理员:用户未分配岗位角色!";
                    return (Int32)LoginReulst.UserNotRole;
                case LoginReulst.UserNoFuncs:
                    ReutnrString = "请联系管理员:用户岗位角色未分配功能!";
                    return (Int32)LoginReulst.UserNoFuncs;
                case LoginReulst.UserHasMuiltRole:
                    ReutnrString = "存在多岗位角色，请选择本次登陆岗位角色";
                    currentloginobj = null;
                    ChoosePositionSource = returnDs.Tables.Count == 2 ? this.ToList<T_SYS_Role>(returnDs.Tables[1]) : null;
                    return (Int32)LoginReulst.UserHasMuiltRole;
                case LoginReulst.HasMuiltUser:
                    ReutnrString = "请联系管理员:用户表基础错误!";
                    return (Int32)LoginReulst.HasMuiltUser;
                case LoginReulst.UserCheckPass:
                    currentloginobj.CurrentUser = this.ToList<T_SYS_UserInfo>(returnDs.Tables[0])[0];
                    currentloginobj.CurrentDept = this.ToList<T_SYS_Dept>(returnDs.Tables[1])[0];
                    currentloginobj.CurrentRole = this.ToList<T_SYS_Role>(returnDs.Tables[2])[0];
                    currentloginobj.CurrentFuncs = this.ToList<T_SYS_Function>(returnDs.Tables[3]);
                    currentloginobj.CurrentFuncsRight = this.ToList<T_SYS_FunctionRight>(returnDs.Tables[4]);
                    ChoosePositionSource = null;
                    ReutnrString = "通过检测";
                    return (Int32)LoginReulst.UserCheckPass;
                default:
                    ReutnrString = "请联系管理员:用户表检测错误!";
                    return (Int32)LoginReulst.ExecError;
            }
        }



    }
}
