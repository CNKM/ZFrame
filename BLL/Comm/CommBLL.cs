﻿using Entity.SYS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Comm
{
    /// <summary>
    /// 当前账户相关信息
    /// </summary>
    public class CurrentLoginObject
    {
        T_SYS_Dept _CurrentDept;

        /// <summary>
        /// 当登陆部门
        /// </summary>
        public T_SYS_Dept CurrentDept
        {
            get { return _CurrentDept; }
            set { _CurrentDept = value; }
        }
        T_SYS_Role _CurrentRole;

        /// <summary>
        /// 当前角色
        /// </summary>
        public T_SYS_Role CurrentRole
        {
            get { return _CurrentRole; }
            set { _CurrentRole = value; }
        }
        T_SYS_UserInfo _CurrentUser;

        /// <summary>
        /// 当前用户
        /// </summary>
        public T_SYS_UserInfo CurrentUser
        {
            get { return _CurrentUser; }
            set { _CurrentUser = value; }
        }

        List<T_SYS_FunctionRight> _CurrentFuncs;

        //当前功能列表
        public List<T_SYS_FunctionRight> CurrentFuncs
        {
            get { return _CurrentFuncs; }
            set { _CurrentFuncs = value; }
        }
    }

    public enum LoginReulst
    {
        //用户名或密码错误!
        UserNotFind=-1,
        //当前登录人员未分配岗位
        UserNotRole=-2,
        //当前岗位没有分配功能
        UserNoFuncs =-3,
        //存在多岗位
        UserHasMuiltRole =-4,
        //冲突用户帐号
        HasMuiltUser =-5,
        //执行错误，请联系管理员;
        ExecError=-6

    }
}