using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_Organization : TEntityBase
    {
          #region 数据库字段对应
          
          private string _F_SN;
        
          /// <summary>
           /// </summary>
          public string F_SN{get{return _F_SN;}set{ if(_F_SN!=value){_F_SN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SN");}}}
          
          private string _F_ParentSN;
        
          /// <summary>
           /// </summary>
          public string F_ParentSN{get{return _F_ParentSN;}set{ if(_F_ParentSN!=value){_F_ParentSN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ParentSN");}}}
          
          private string _F_UID;
        
          /// <summary>
           /// </summary>
          public string F_UID{get{return _F_UID;}set{ if(_F_UID!=value){_F_UID=value;if(SendNotifyProperty)this.SendPropertyChanged("F_UID");}}}
          
          private string _F_Name;
        
          /// <summary>
           /// </summary>
          public string F_Name{get{return _F_Name;}set{ if(_F_Name!=value){_F_Name=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Name");}}}
          
          private string _F_AppName;
        
          /// <summary>
           /// </summary>
          public string F_AppName{get{return _F_AppName;}set{ if(_F_AppName!=value){_F_AppName=value;if(SendNotifyProperty)this.SendPropertyChanged("F_AppName");}}}
          
          private string _F_LogoPic;
        
          /// <summary>
           /// </summary>
          public string F_LogoPic{get{return _F_LogoPic;}set{ if(_F_LogoPic!=value){_F_LogoPic=value;if(SendNotifyProperty)this.SendPropertyChanged("F_LogoPic");}}}
          
          private string _F_LogoURL;
        
          /// <summary>
           /// </summary>
          public string F_LogoURL{get{return _F_LogoURL;}set{ if(_F_LogoURL!=value){_F_LogoURL=value;if(SendNotifyProperty)this.SendPropertyChanged("F_LogoURL");}}}
          
          private double _F_LogoWidth;
        
          /// <summary>
           /// </summary>
          public double F_LogoWidth{get{return _F_LogoWidth;}set{ if(_F_LogoWidth!=value){_F_LogoWidth=value;if(SendNotifyProperty)this.SendPropertyChanged("F_LogoWidth");}}}
          
          private double _F_LogoHeight;
        
          /// <summary>
           /// </summary>
          public double F_LogoHeight{get{return _F_LogoHeight;}set{ if(_F_LogoHeight!=value){_F_LogoHeight=value;if(SendNotifyProperty)this.SendPropertyChanged("F_LogoHeight");}}}
          
          private bool? _F_IsOnlyDisplayLogo;
        
          /// <summary>
           /// </summary>
          public bool? F_IsOnlyDisplayLogo{get{return _F_IsOnlyDisplayLogo;}set{ if(_F_IsOnlyDisplayLogo!=value){_F_IsOnlyDisplayLogo=value;if(SendNotifyProperty)this.SendPropertyChanged("F_IsOnlyDisplayLogo");}}}
          
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

