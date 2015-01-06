using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_RoleRight : TEntityBase
    {
          #region 数据库字段对应
          
          private Guid _F_SN;
        
          /// <summary>
           /// </summary>
          public Guid F_SN{get{return _F_SN;}set{ if(_F_SN!=value){_F_SN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SN");}}}
          
          private string _F_RoleSN;
        
          /// <summary>
           /// </summary>
          public string F_RoleSN{get{return _F_RoleSN;}set{ if(_F_RoleSN!=value){_F_RoleSN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_RoleSN");}}}
          
          private string _F_RightSN;
        
          /// <summary>
           /// </summary>
          public string F_RightSN{get{return _F_RightSN;}set{ if(_F_RightSN!=value){_F_RightSN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_RightSN");}}}
          
          private string _F_Creator;
        
          /// <summary>
           /// </summary>
          public string F_Creator{get{return _F_Creator;}set{ if(_F_Creator!=value){_F_Creator=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Creator");}}}
          
          private DateTime? _F_CreateDate;
        
          /// <summary>
           /// </summary>
          public DateTime? F_CreateDate{get{return _F_CreateDate;}set{ if(_F_CreateDate!=value){_F_CreateDate=value;if(SendNotifyProperty)this.SendPropertyChanged("F_CreateDate");}}}
          
          private string _F_Updater;
        
          /// <summary>
           /// </summary>
          public string F_Updater{get{return _F_Updater;}set{ if(_F_Updater!=value){_F_Updater=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Updater");}}}
          
          private DateTime? _F_UpdateDate;
        
          /// <summary>
           /// </summary>
          public DateTime? F_UpdateDate{get{return _F_UpdateDate;}set{ if(_F_UpdateDate!=value){_F_UpdateDate=value;if(SendNotifyProperty)this.SendPropertyChanged("F_UpdateDate");}}}
          
          
          #endregion
    }
}

