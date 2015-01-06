using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_LoginLog : TEntityBase
    {
          #region 数据库字段对应
          
          private string _F_SN;
        
          /// <summary>
           /// </summary>
          public string F_SN{get{return _F_SN;}set{ if(_F_SN!=value){_F_SN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SN");}}}
          
          private string _F_UserSN;
        
          /// <summary>
           /// </summary>
          public string F_UserSN{get{return _F_UserSN;}set{ if(_F_UserSN!=value){_F_UserSN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_UserSN");}}}
          
          private DateTime? _F_LoginDateTime;
        
          /// <summary>
           /// </summary>
          public DateTime? F_LoginDateTime{get{return _F_LoginDateTime;}set{ if(_F_LoginDateTime!=value){_F_LoginDateTime=value;if(SendNotifyProperty)this.SendPropertyChanged("F_LoginDateTime");}}}
          
          private string _F_ClientBrowser;
        
          /// <summary>
           /// </summary>
          public string F_ClientBrowser{get{return _F_ClientBrowser;}set{ if(_F_ClientBrowser!=value){_F_ClientBrowser=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ClientBrowser");}}}
          
          private string _F_ClientVersion;
        
          /// <summary>
           /// </summary>
          public string F_ClientVersion{get{return _F_ClientVersion;}set{ if(_F_ClientVersion!=value){_F_ClientVersion=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ClientVersion");}}}
          
          private string _F_ClientPlatform;
        
          /// <summary>
           /// </summary>
          public string F_ClientPlatform{get{return _F_ClientPlatform;}set{ if(_F_ClientPlatform!=value){_F_ClientPlatform=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ClientPlatform");}}}
          
          private string _F_ClientIP;
        
          /// <summary>
           /// </summary>
          public string F_ClientIP{get{return _F_ClientIP;}set{ if(_F_ClientIP!=value){_F_ClientIP=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ClientIP");}}}
          
          private bool? _F_IsLogin;
        
          /// <summary>
           /// </summary>
          public bool? F_IsLogin{get{return _F_IsLogin;}set{ if(_F_IsLogin!=value){_F_IsLogin=value;if(SendNotifyProperty)this.SendPropertyChanged("F_IsLogin");}}}
          
          private string _F_LoginError;
        
          /// <summary>
           /// </summary>
          public string F_LoginError{get{return _F_LoginError;}set{ if(_F_LoginError!=value){_F_LoginError=value;if(SendNotifyProperty)this.SendPropertyChanged("F_LoginError");}}}
          
          private string _F_TempUserName;
        
          /// <summary>
           /// </summary>
          public string F_TempUserName{get{return _F_TempUserName;}set{ if(_F_TempUserName!=value){_F_TempUserName=value;if(SendNotifyProperty)this.SendPropertyChanged("F_TempUserName");}}}
          
          private string _F_TempUserPassword;
        
          /// <summary>
           /// </summary>
          public string F_TempUserPassword{get{return _F_TempUserPassword;}set{ if(_F_TempUserPassword!=value){_F_TempUserPassword=value;if(SendNotifyProperty)this.SendPropertyChanged("F_TempUserPassword");}}}
          
          private string _F_SDK;
        
          /// <summary>
           /// </summary>
          public string F_SDK{get{return _F_SDK;}set{ if(_F_SDK!=value){_F_SDK=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SDK");}}}
          
          private string _F_Remark;
        
          /// <summary>
           /// </summary>
          public string F_Remark{get{return _F_Remark;}set{ if(_F_Remark!=value){_F_Remark=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Remark");}}}
          
          
          #endregion
    }
}

