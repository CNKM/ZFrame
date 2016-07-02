using ZFrameCore.Entity;
using System;
using ZFrameCore.Common;
namespace Entity.SYS
{

    /// <summary> 实体名称
    /// </summary>
    public class T_SYS_FunctionRight : TEntityBase
    {
        #region 数据库字段对应

        private Guid _F_SN;

        /// <summary>
        /// </summary>
        public Guid F_SN { get { return _F_SN; } set { if (_F_SN != value) { _F_SN = value; if (SendNotifyProperty)this.SendPropertyChanged("F_SN"); } } }

        private Guid _F_FunctionSN;

        /// <summary>
        /// </summary>
        public Guid F_FunctionSN { get { return _F_FunctionSN; } set { if (_F_FunctionSN != value) { _F_FunctionSN = value; if (SendNotifyProperty)this.SendPropertyChanged("F_FunctionSN"); } } }

        private string _F_Code;

        /// <summary>
        /// </summary>
        public string F_Code { get { return _F_Code; } set { if (_F_Code != value) { _F_Code = value; if (SendNotifyProperty)this.SendPropertyChanged("F_Code"); } } }

        private string _F_Name;

        /// <summary>
        /// </summary>
        public string F_Name { get { return _F_Name; } set { if (_F_Name != value) { _F_Name = value; if (SendNotifyProperty)this.SendPropertyChanged("F_Name"); } } }

        private string _F_Remark;

        /// <summary>
        /// </summary>
        public string F_Remark { get { return _F_Remark; } set { if (_F_Remark != value) { _F_Remark = value; if (SendNotifyProperty)this.SendPropertyChanged("F_Remark"); } } }

        private int? _F_Index;

        /// <summary>
        /// </summary>
        public int? F_Index { get { return _F_Index; } set { if (_F_Index != value) { _F_Index = value; if (SendNotifyProperty)this.SendPropertyChanged("F_Index"); } } }

        private Guid _F_Creator;

        /// <summary>
        /// </summary>
        public Guid F_Creator { get { return _F_Creator; } set { if (_F_Creator != value) { _F_Creator = value; if (SendNotifyProperty)this.SendPropertyChanged("F_Creator"); } } }

        private DateTime? _F_CreateDate;

        /// <summary>
        /// </summary>
        public DateTime? F_CreateDate { get { return _F_CreateDate; } set { if (_F_CreateDate != value) { _F_CreateDate = value; if (SendNotifyProperty)this.SendPropertyChanged("F_CreateDate"); } } }

        private Guid _F_Updater;

        /// <summary>
        /// </summary>
        public Guid F_Updater { get { return _F_Updater; } set { if (_F_Updater != value) { _F_Updater = value; if (SendNotifyProperty)this.SendPropertyChanged("F_Updater"); } } }

        private DateTime? _F_UpdateDate;

        /// <summary>
        /// </summary>
        public DateTime? F_UpdateDate { get { return _F_UpdateDate; } set { if (_F_UpdateDate != value) { _F_UpdateDate = value; if (SendNotifyProperty)this.SendPropertyChanged("F_UpdateDate"); } } }


        #endregion
    }
}

