using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFrameCore.Common;

namespace ZFrameCore.Entity
{
    public class TEntityTree<T>:TEntityBase where T:TEntityBase
    {
        T Parent;
        List<T> _Children;
        [PropertyType(EntityPropertyType.DesignField)]
        public List<T> Children
        {
            get { return _Children; }
            set { _Children = value; }

        }
        public TEntityTree()
        {
            Parent = null;
            this._Children = new List<T>();
        }


    
    }
}
