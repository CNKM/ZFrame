using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_Parameter : TEntityBase
    {
          #region 数据库字段对应
          
          private Guid _F_SN;
        
          /// <summary>
           /// </summary>
          public Guid F_SN {get{return _F_SN;}set{ if(_F_SN!=value){_F_SN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SN");}}}
          
          private string _F_UID;
        
          /// <summary>
           /// </summary>
          public string F_UID{get{return _F_UID;}set{ if(_F_UID!=value){_F_UID=value;if(SendNotifyProperty)this.SendPropertyChanged("F_UID");}}}
          
          private Guid _F_PID;
        
          /// <summary>
           /// </summary>
          public Guid F_PID {get{return _F_PID;}set{ if(_F_PID!=value){_F_PID=value;if(SendNotifyProperty)this.SendPropertyChanged("F_PID");}}}
          
          private string _F_Name;
        
          /// <summary>
           /// </summary>
          public string F_Name{get{return _F_Name;}set{ if(_F_Name!=value){_F_Name=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Name");}}}
          
          private bool? _F_IsActive;
        
          /// <summary>
           /// </summary>
          public bool? F_IsActive{get{return _F_IsActive;}set{ if(_F_IsActive!=value){_F_IsActive=value;if(SendNotifyProperty)this.SendPropertyChanged("F_IsActive");}}}
          
          private string _F_Value;
        
          /// <summary>
           /// </summary>
          public string F_Value{get{return _F_Value;}set{ if(_F_Value!=value){_F_Value=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Value");}}}
          
          private string _F_ExtValue;
        
          /// <summary>
           /// </summary>
          public string F_ExtValue{get{return _F_ExtValue;}set{ if(_F_ExtValue!=value){_F_ExtValue=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ExtValue");}}}
          
          private string _F_Remark;
        
          /// <summary>
           /// </summary>
          public string F_Remark{get{return _F_Remark;}set{ if(_F_Remark!=value){_F_Remark=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Remark");}}}
          
          
          #endregion
    }
}

