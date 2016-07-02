using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_NoticeTo : TEntityBase
    {
          #region 数据库字段对应
          
          private Guid _F_SN;
        
          /// <summary>
           /// </summary>
          public Guid F_SN {get{return _F_SN;}set{ if(_F_SN!=value){_F_SN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SN");}}}
          
          private int? _F_Type;
        
          /// <summary>
           /// </summary>
          public int? F_Type{get{return _F_Type;}set{ if(_F_Type!=value){_F_Type=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Type");}}}
          
          private Guid _F_NoticeSN;
        
          /// <summary>
           /// </summary>
          public Guid F_NoticeSN {get{return _F_NoticeSN;}set{ if(_F_NoticeSN!=value){_F_NoticeSN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_NoticeSN");}}}
          
          private string _F_NoticeToObj;
        
          /// <summary>
           /// </summary>
          public string F_NoticeToObj{get{return _F_NoticeToObj;}set{ if(_F_NoticeToObj!=value){_F_NoticeToObj=value;if(SendNotifyProperty)this.SendPropertyChanged("F_NoticeToObj");}}}
          
          private bool? _F_IsDel;
        
          /// <summary>
           /// </summary>
          public bool? F_IsDel{get{return _F_IsDel;}set{ if(_F_IsDel!=value){_F_IsDel=value;if(SendNotifyProperty)this.SendPropertyChanged("F_IsDel");}}}
          
          private int? _F_State;
        
          /// <summary>
           /// </summary>
          public int? F_State{get{return _F_State;}set{ if(_F_State!=value){_F_State=value;if(SendNotifyProperty)this.SendPropertyChanged("F_State");}}}
          
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

