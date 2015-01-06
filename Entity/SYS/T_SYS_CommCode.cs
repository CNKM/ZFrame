using System;
using ZFrameCore.Entity;
namespace  Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_CommCode : TEntityBase
    {
          #region 数据库字段对应
          
          private string _F_SN;
        
          /// <summary>
           /// </summary>
          public string F_SN{get{return _F_SN;}set{ if(_F_SN!=value){_F_SN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SN");}}}
          
          private string _F_UID;
        
          /// <summary>
           /// </summary>
          public string F_UID{get{return _F_UID;}set{ if(_F_UID!=value){_F_UID=value;if(SendNotifyProperty)this.SendPropertyChanged("F_UID");}}}
          
          private string _F_Type;
        
          /// <summary>
           /// </summary>
          public string F_Type{get{return _F_Type;}set{ if(_F_Type!=value){_F_Type=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Type");}}}
          
          private string _F_Name;
        
          /// <summary>
           /// </summary>
          public string F_Name{get{return _F_Name;}set{ if(_F_Name!=value){_F_Name=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Name");}}}
          
          private int? _F_Code;
        
          /// <summary>
           /// </summary>
          public int? F_Code{get{return _F_Code;}set{ if(_F_Code!=value){_F_Code=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Code");}}}
          
          private string _F_ExtValue;
        
          /// <summary>
           /// </summary>
          public string F_ExtValue{get{return _F_ExtValue;}set{ if(_F_ExtValue!=value){_F_ExtValue=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ExtValue");}}}
          
          private string _F_Remark;
        
          /// <summary>
           /// </summary>
          public string F_Remark{get{return _F_Remark;}set{ if(_F_Remark!=value){_F_Remark=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Remark");}}}
          
          private int? _F_State;
        
          /// <summary>
           /// </summary>
          public int? F_State{get{return _F_State;}set{ if(_F_State!=value){_F_State=value;if(SendNotifyProperty)this.SendPropertyChanged("F_State");}}}
          
          private int? _F_Index;
        
          /// <summary>
           /// </summary>
          public int? F_Index{get{return _F_Index;}set{ if(_F_Index!=value){_F_Index=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Index");}}}
          
          private bool? _F_IsDel;
        
          /// <summary>
           /// </summary>
          public bool? F_IsDel{get{return _F_IsDel;}set{ if(_F_IsDel!=value){_F_IsDel=value;if(SendNotifyProperty)this.SendPropertyChanged("F_IsDel");}}}
          
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

