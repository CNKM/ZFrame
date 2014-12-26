using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFrameCore.Common;

namespace ZFrameCore.Entity
{
    public class TEntityBase
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




    }
}
