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
        private String _TableName;
        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public String TableName
        {
            get
            {
                if (String.IsNullOrEmpty(_TableName))
                {
                    _TableName = this.GetType().Name;
                }
                return _TableName;
            }
            set
            {
                _TableName = value;
            }
        }

        Boolean _SendNotifyProperty = true;
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
        private EntityModelType _entitymodeltype;

        [PropertyType(EntityPropertyType.DesignField)]
        [System.Xml.Serialization.XmlIgnore]
        public EntityModelType EntityType
        {
            get { return _entitymodeltype; }
            set { _entitymodeltype = value; }
        }


        public TEntityBase()
        {
            this._TableName = this.GetType().Name;
            this._entitymodeltype = EntityModelType.DBModel;
            _SendNotifyProperty = false;
        }

    }
}
