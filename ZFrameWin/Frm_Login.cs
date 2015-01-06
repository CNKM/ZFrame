using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ZFrameWin
{
    public partial class Frm_Login : Form
    {


        private String ReadStream(Stream sr)
        {
            
            StreamReader sw = new StreamReader(sr);
            String Reuslt = sw.ReadToEnd();
            return Reuslt;
        }
        ServiceReference1.WCFServicesClient WCFC = new ServiceReference1.WCFServicesClient();
        public Frm_Login()
        {
            InitializeComponent();
            Stream AS = WCFC.GetServerDateTime();
            String ReusltS = ReadStream(AS);
        }
    }
}
