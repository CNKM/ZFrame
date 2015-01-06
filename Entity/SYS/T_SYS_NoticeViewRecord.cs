using ZFrameCore.Entity;
using System;
namespace Entity.SYS
{
  
    /// <summary> 实体名称
    /// </summary>
    public class  T_SYS_NoticeViewRecord : TEntityBase
    {
          #region 数据库字段对应
          
          private string _F_SN;
        
          /// <summary>
           /// </summary>
          public string F_SN{get{return _F_SN;}set{ if(_F_SN!=value){_F_SN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_SN");}}}
          
          private string _F_NoticeSN;
        
          /// <summary>
           /// </summary>
          public string F_NoticeSN{get{return _F_NoticeSN;}set{ if(_F_NoticeSN!=value){_F_NoticeSN=value;if(SendNotifyProperty)this.SendPropertyChanged("F_NoticeSN");}}}
          
          private string _F_Viewer;
        
          /// <summary>
           /// </summary>
          public string F_Viewer{get{return _F_Viewer;}set{ if(_F_Viewer!=value){_F_Viewer=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Viewer");}}}
          
          private DateTime? _F_StartView;
        
          /// <summary>
           /// </summary>
          public DateTime? F_StartView{get{return _F_StartView;}set{ if(_F_StartView!=value){_F_StartView=value;if(SendNotifyProperty)this.SendPropertyChanged("F_StartView");}}}
          
          private DateTime? _F_EndView;
        
          /// <summary>
           /// </summary>
          public DateTime? F_EndView{get{return _F_EndView;}set{ if(_F_EndView!=value){_F_EndView=value;if(SendNotifyProperty)this.SendPropertyChanged("F_EndView");}}}
          
          private string _F_Reback;
        
          /// <summary>
           /// </summary>
          public string F_Reback{get{return _F_Reback;}set{ if(_F_Reback!=value){_F_Reback=value;if(SendNotifyProperty)this.SendPropertyChanged("F_Reback");}}}
          
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

