using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyUI.Tree
{
    public class TreeData
    {

        public string id { get; set; }
        public string text { get; set; }
        public string state { get; set; }
        public Boolean @checked { get; set; }
        public List<KeyValuePair<String,Object>> attributes { get; set; }
        public List<TreeData> children { get; set; }
        public TreeData()
        {
            attributes = new List<KeyValuePair<string, object>>();
            children = new List<TreeData>();
        }

    }
}
