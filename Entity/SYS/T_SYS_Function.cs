using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_Function : TEntityBase
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
          
          private string _F_FuncRightGroup;
        
          /// <summary>
           /// </summary>
          public string F_FuncRightGroup{get{return _F_FuncRightGroup;}set{ if(_F_FuncRightGroup!=value){_F_FuncRightGroup=value;if(SendNotifyProperty)this.SendPropertyChanged("F_FuncRightGroup");}}}
          
          private string _F_Name;
        
          /// <summary>
           /// </summary>
          public string F_Name{get{return _F_Name;}set{ if(_F_Name!=value){_F_Name=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Name");}}}
          
          private string _F_FuncURL;
        
          /// <summary>
           /// </summary>
          public string F_FuncURL{get{return _F_FuncURL;}set{ if(_F_FuncURL!=value){_F_FuncURL=value;if(SendNotifyProperty)this.SendPropertyChanged("F_FuncURL");}}}
          
          private string _F_FuncICON;
        
          /// <summary>
           /// </summary>
          public string F_FuncICON{get{return _F_FuncICON;}set{ if(_F_FuncICON!=value){_F_FuncICON=value;if(SendNotifyProperty)this.SendPropertyChanged("F_FuncICON");}}}
          
          private string _F_Tips;
        
          /// <summary>
           /// </summary>
          public string F_Tips{get{return _F_Tips;}set{ if(_F_Tips!=value){_F_Tips=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Tips");}}}
          
          private int? _F_Index;
        
          /// <summary>
           /// </summary>
          public int? F_Index{get{return _F_Index;}set{ if(_F_Index!=value){_F_Index=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Index");}}}
          
          private bool? _F_ShowInMenu;
        
          /// <summary>
           /// </summary>
          public bool? F_ShowInMenu{get{return _F_ShowInMenu;}set{ if(_F_ShowInMenu!=value){_F_ShowInMenu=value;if(SendNotifyProperty)this.SendPropertyChanged("F_ShowInMenu");}}}
          
          private bool? _F_IsDel;
        
          /// <summary>
           /// </summary>
          public bool? F_IsDel{get{return _F_IsDel;}set{ if(_F_IsDel!=value){_F_IsDel=value;if(SendNotifyProperty)this.SendPropertyChanged("F_IsDel");}}}
          
          private int? _F_OpenType;
        
          /// <summary>
           /// </summary>
          public int? F_OpenType{get{return _F_OpenType;}set{ if(_F_OpenType!=value){_F_OpenType=value;if(SendNotifyProperty)this.SendPropertyChanged("F_OpenType");}}}
          
          private string _F_OpenSpace;
        
          /// <summary>
           /// </summary>
          public string F_OpenSpace{get{return _F_OpenSpace;}set{ if(_F_OpenSpace!=value){_F_OpenSpace=value;if(SendNotifyProperty)this.SendPropertyChanged("F_OpenSpace");}}}
          
          private string _F_Remark;
        
          /// <summary>
           /// </summary>
          public string F_Remark{get{return _F_Remark;}set{ if(_F_Remark!=value){_F_Remark=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Remark");}}}
          
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

