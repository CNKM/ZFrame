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
using ZFrameCore.Common;


namespace ZFrameWin
{
    public partial class Frm_Login : Form
    {

        WCFS.WCFServicesClient WCFSC = new WCFS.WCFServicesClient();
        public Frm_Login()
        {
            InitializeComponent();
            MessageBox.Show(WCFSC.GetServerDateTime().ToStream());
        }
    }
}
