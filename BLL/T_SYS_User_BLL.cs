using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZFrameCore.BLL;

namespace BLL
{
    public class T_SYS_User_BLL : TBLLBase<T_SYS_User>
    {
        public T_SYS_User_BLL()
        {
            this.SQLString = "Select * From T_SYS_User";
        }
    }
}
