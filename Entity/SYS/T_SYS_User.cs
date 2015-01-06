using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFrameCore.Common;
using ZFrameCore.Entity;

namespace Entity.SYS
{
    public class T_SYS_User : TEntityBase
    {
        public T_SYS_User()
        { }


        #region 数据库字段对应a

        private Guid _F_SN;

        /// <summary>用户编号
        /// </summary>
        [PropertyType(EntityPropertyType.DBFieldKey)]
        public Guid F_SN { get { return _F_SN; } set { if (_F_SN != value) { _F_SN = value; } } }

        private Guid _F_RoleSN;

        /// <summary>角色编号
        /// </summary>
        public Guid F_RoleSN { get { return _F_RoleSN; } set { if (_F_RoleSN != value) { _F_RoleSN = value; } } }

        private Guid _F_CompanySN;

        /// <summary>企业编号
        /// </summary>
        public Guid F_CompanySN { get { return _F_CompanySN; } set { if (_F_CompanySN != value) { _F_CompanySN = value; } } }

        private string _F_UserName;

        /// <summary>用户名
        /// </summary>
        public string F_UserName { get { return _F_UserName; } set { if (_F_UserName != value) { _F_UserName = value; } } }

        private string _F_Password;

        /// <summary>密码
        /// </summary>
        public string F_Password { get { return _F_Password; } set { if (_F_Password != value) { _F_Password = value; } } }

        private string _F_RealName;

        /// <summary>用户姓名
        /// </summary>
        public string F_RealName { get { return _F_RealName; } set { if (_F_RealName != value) { _F_RealName = value; } } }

        private bool? _F_IsActived;

        /// <summary>是否启用
        /// </summary>
        public bool? F_IsActived { get { return _F_IsActived; } set { if (_F_IsActived != value) { _F_IsActived = value; } } }

        private bool? _F_IsDel;

        /// <summary>是否删除
        /// </summary>
        public bool? F_IsDel { get { return _F_IsDel; } set { if (_F_IsDel != value) { _F_IsDel = value; } } }

        private string _F_Creator;

        /// <summary>创建人
        /// </summary>
        public string F_Creator { get { return _F_Creator; } set { if (_F_Creator != value) { _F_Creator = value; } } }

        private DateTime? _F_CreateDate;

        /// <summary>创建时间
        /// </summary>
        public DateTime? F_CreateDate { get { return _F_CreateDate; } set { if (_F_CreateDate != value) { _F_CreateDate = value; } } }

        private string _F_Updater;

        /// <summary>修改人
        /// </summary>
        public string F_Updater { get { return _F_Updater; } set { if (_F_Updater != value) { _F_Updater = value; } } }

        private DateTime? _F_UpdateDate;

        /// <summary>修改时间
        /// </summary>
        public DateTime? F_UpdateDate { get { return _F_UpdateDate; } set { if (_F_UpdateDate != value) { _F_UpdateDate = value; } } }


        /// <summary>
        /// 企业名称
        /// </summary>
        private string _CompanyName;

        /// <summary>企业名称
        /// </summary>
        [PropertyType(EntityPropertyType.DesignField)]
        public string CompanyName { get { return _CompanyName; } set { if (_CompanyName != value) { _CompanyName = value; } } }



        #endregion
    }
}


