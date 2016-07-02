using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFrameCore.Common;

namespace ZFrameCore.Entity
{
    public class TEntityBase : INotifyPropertyChanged
    {
        #region  对象属性感知事件
        Boolean _SendNotifyProperty;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public Boolean SendNotifyProperty
        {
            get { return _SendNotifyProperty; }
            set { _SendNotifyProperty = value; }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void SendPropertyChanged(String propertyName)
        {
            if ((this.PropertyChanged != null))
            {
                this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion

        #region 扩展属性
        /// <summary>
        /// 复选
        /// </summary>
        private Boolean? _F_Checked;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public Boolean? F_Checked
        {
            get { return _F_Checked; }
            set
            {
                _F_Checked = value;
                this.SendPropertyChanged("F_Checked");
            }
        }
        /// <summary>
        /// 是否可以选择
        /// </summary>
        private Boolean _IsCanSelected = true;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public Boolean IsCanSelected
        {
            get { return _IsCanSelected; }
            set
            {
                _IsCanSelected = value;
                this.SendPropertyChanged("_IsCanSelected");
            }
        }

        /// <summary>
        /// 是否选择
        /// </summary>
        private Boolean _IsSelected;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public Boolean IsSelected
        {
            get { return _IsSelected; }
            set
            {
                _IsSelected = value;
                this.SendPropertyChanged("IsSelected");
            }
        }

        /// <summary>
        /// 是否展开
        /// </summary>
        private Boolean _IsExpand;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public Boolean IsExpanded
        {
            get { return _IsExpand; }
            set
            {
                _IsExpand = value;
                this.SendPropertyChanged("IsExpanded");
            }
        }
        /// <summary>
        /// 是否显示
        /// </summary>
        private Boolean _IsVisualble;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public Boolean IsVisualble
        {
            get { return _IsVisualble; }
            set
            {
                _IsVisualble = value;
                this.SendPropertyChanged("IsVisualble");
            }
        }

        /// <summary>
        /// 查询名称
        /// </summary>
        private String _F_FilterKey;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public String F_FilterKey
        {
            get
            {
                return _F_FilterKey;
            }
            set
            {
                _F_FilterKey = value;
            }
        }

        private Boolean _IsVilidation;
        [PropertyType(EntityPropertyType.DesignField)]
        public Boolean IsVilidation
        {
            get
            {
                return _IsVilidation;
            }
            set
            {
                _IsVilidation = value;
                this.SendPropertyChanged("IsVilidation");
            }
        }

        private String _TableName;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public String TableName
        {
            get { return _TableName; }
            set
            {
                _TableName = value;
                this.SendPropertyChanged("TableName");
            }
        }


        #endregion

        #region 错误校验
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        [System.Xml.Serialization.XmlIgnore]
        public Dictionary<string, List<string>> errors = new Dictionary<string, List<string>>();

        public void SetErrors(string propertyName, List<string> propertyErrors)
        {
            errors.Remove(propertyName);
            errors.Add(propertyName, propertyErrors);
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }

        public void ClearErrors(string propertyName)
        {
            errors.Remove(propertyName);
            if (ErrorsChanged != null)
            {
                ErrorsChanged(this, new DataErrorsChangedEventArgs(propertyName));
            }
        }
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName))
            {
                return null;
            }
            else
            {
                if (errors.ContainsKey(propertyName))
                {
                    return errors[propertyName];
                }
            }
            return null;
        }

        private bool _HasErrors;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public bool HasErrors
        {
            get { return (errors.Count > 0); }
            set { _HasErrors = value; }
        }
        #endregion

        public TEntityBase()
        {
            this._TableName = this.GetType().Name;
            _SendNotifyProperty = false;
            _F_Checked = false;
            _IsSelected = false;
            _IsExpand = false;
            _IsVisualble = true;
            _IsVilidation = false;
        }

    }
}
