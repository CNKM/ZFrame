using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_UserInfo : TEntityBase
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
          
          private string _F_Code;
        
          /// <summary>
           /// </summary>
          public string F_Code{get{return _F_Code;}set{ if(_F_Code!=value){_F_Code=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Code");}}}
          
          private string _F_HeadPic;
        
          /// <summary>
           /// </summary>
          public string F_HeadPic{get{return _F_HeadPic;}set{ if(_F_HeadPic!=value){_F_HeadPic=value;if(SendNotifyProperty)this.SendPropertyChanged("F_HeadPic");}}}
          
          private string _F_Name;
        
          /// <summary>
           /// </summary>
          public string F_Name{get{return _F_Name;}set{ if(_F_Name!=value){_F_Name=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Name");}}}
          
          private string _F_Nickname;
        
          /// <summary>
           /// </summary>
          public string F_Nickname{get{return _F_Nickname;}set{ if(_F_Nickname!=value){_F_Nickname=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Nickname");}}}
          
          private int? _F_Sex;
        
          /// <summary>
           /// </summary>
          public int? F_Sex{get{return _F_Sex;}set{ if(_F_Sex!=value){_F_Sex=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Sex");}}}
          
          private DateTime? _F_BirthDay;
        
          /// <summary>
           /// </summary>
          public DateTime? F_BirthDay{get{return _F_BirthDay;}set{ if(_F_BirthDay!=value){_F_BirthDay=value;if(SendNotifyProperty)this.SendPropertyChanged("F_BirthDay");}}}
          
          private string _F_NativePlace;
        
          /// <summary>
           /// </summary>
          public string F_NativePlace{get{return _F_NativePlace;}set{ if(_F_NativePlace!=value){_F_NativePlace=value;if(SendNotifyProperty)this.SendPropertyChanged("F_NativePlace");}}}
          
          private int? _F_Nation;
        
          /// <summary>
           /// </summary>
          public int? F_Nation{get{return _F_Nation;}set{ if(_F_Nation!=value){_F_Nation=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Nation");}}}
          
          private string _F_PhotoURL;
        
          /// <summary>
           /// </summary>
          public string F_PhotoURL{get{return _F_PhotoURL;}set{ if(_F_PhotoURL!=value){_F_PhotoURL=value;if(SendNotifyProperty)this.SendPropertyChanged("F_PhotoURL");}}}
          
          private string _F_LoginName;
        
          /// <summary>
           /// </summary>
          public string F_LoginName{get{return _F_LoginName;}set{ if(_F_LoginName!=value){_F_LoginName=value;if(SendNotifyProperty)this.SendPropertyChanged("F_LoginName");}}}
          
          private string _F_PSW;
        
          /// <summary>
           /// </summary>
          public string F_PSW{get{return _F_PSW;}set{ if(_F_PSW!=value){_F_PSW=value;if(SendNotifyProperty)this.SendPropertyChanged("F_PSW");}}}
          
          private int? _F_CulturalDegree;
        
          /// <summary>
           /// </summary>
          public int? F_CulturalDegree{get{return _F_CulturalDegree;}set{ if(_F_CulturalDegree!=value){_F_CulturalDegree=value;if(SendNotifyProperty)this.SendPropertyChanged("F_CulturalDegree");}}}
          
          private int? _F_Type;
        
          /// <summary>
           /// </summary>
          public int? F_Type{get{return _F_Type;}set{ if(_F_Type!=value){_F_Type=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Type");}}}
          
          private string _F_Tel;
        
          /// <summary>
           /// </summary>
          public string F_Tel{get{return _F_Tel;}set{ if(_F_Tel!=value){_F_Tel=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Tel");}}}
          
          private string _F_Address;
        
          /// <summary>
           /// </summary>
          public string F_Address{get{return _F_Address;}set{ if(_F_Address!=value){_F_Address=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Address");}}}
          
          private string _F_MSN;
        
          /// <summary>
           /// </summary>
          public string F_MSN{get{return _F_MSN;}set{ if(_F_MSN!=value){_F_MSN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_MSN");}}}
          
          private string _F_Email;
        
          /// <summary>
           /// </summary>
          public string F_Email{get{return _F_Email;}set{ if(_F_Email!=value){_F_Email=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Email");}}}
          
          private int? _F_Question;
        
          /// <summary>
           /// </summary>
          public int? F_Question{get{return _F_Question;}set{ if(_F_Question!=value){_F_Question=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Question");}}}
          
          private string _F_Answe;
        
          /// <summary>
           /// </summary>
          public string F_Answe{get{return _F_Answe;}set{ if(_F_Answe!=value){_F_Answe=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Answe");}}}
          
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
          
          private Guid _F_Creator;
        
          /// <summary>
           /// </summary>
          public Guid F_Creator {get{return _F_Creator;}set{ if(_F_Creator!=value){_F_Creator=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Creator");}}}
          
          private DateTime? _F_CreateDate;
        
          /// <summary>
           /// </summary>
          public DateTime? F_CreateDate{get{return _F_CreateDate;}set{ if(_F_CreateDate!=value){_F_CreateDate=value;if(SendNotifyProperty)this.SendPropertyChanged("F_CreateDate");}}}
          
          private Guid _F_Updater;
        
          /// <summary>
           /// </summary>
          public Guid F_Updater {get{return _F_Updater;}set{ if(_F_Updater!=value){_F_Updater=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Updater");}}}
          
          private DateTime? _F_UpdateDate;
        
          /// <summary>
           /// </summary>
          public DateTime? F_UpdateDate{get{return _F_UpdateDate;}set{ if(_F_UpdateDate!=value){_F_UpdateDate=value;if(SendNotifyProperty)this.SendPropertyChanged("F_UpdateDate");}}}
          
          
          #endregion
    }
}

