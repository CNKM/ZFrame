using EasyUI.Tree;
using Entity.SYS;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.IO;
using System.Web.SessionState;

namespace ZFrameWCF.Comm
{
   

    public static class WCFWebConfig
    {

        /// <summary>
        /// 是否需要验证
        /// </summary>
        public static Boolean NeedAuth
        {
            get
            {
                
                
                return Convert.ToBoolean(ConfigurationManager.AppSettings["NeedAuth"]);
            }
            set
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationManager.AppSettings["NeedAuth"] = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");
            }
        }

        /// <summary>
        /// 验证码长度
        /// </summary>
        public static Int32 AuthCodeLength
        {
            get
            {
                return Convert.ToInt32(ConfigurationManager.AppSettings["AuthCodeLength"]);

            }
            set
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                ConfigurationManager.AppSettings["AuthCodeLength"] = value.ToString();
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("appSettings");

            }
        }
    }

    public static class WebHelper
    {
        #region Session Auth
        /// <summary>
        /// 验证码验证
        /// </summary>
        /// <param name="httpSessionState"></param>
        /// <param name="CheckCode"></param>
        /// <returns></returns>
        internal static bool SessionAuth(this HttpSessionState httpSessionState, string CheckCode)
        {
            if (WCFWebConfig.NeedAuth)
            {
                CheckCode = String.IsNullOrEmpty(CheckCode) ? Guid.NewGuid().ToString() : CheckCode;
                string ServerSideCode = httpSessionState["LoginCheckCode"] == null ? "" : httpSessionState["LoginCheckCode"].ToString();
                if (CheckCode.ToUpper() == ServerSideCode)
                {
                    return true;
                }
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// 是否已经验证通过
        /// </summary>
        /// <param name="httpSessionState"></param>
        /// <returns></returns>
        internal static Boolean IsSessionAuthed(this HttpSessionState httpSessionState)
        {
            return httpSessionState["CurrentLoginObject"] == null ? false : true;
        }
        #endregion

        /// <summary>
        /// 生成验证码图片字符串
        /// </summary>
        /// <param name="httpSessionState"></param>
        /// <param name="VCode"></param>
        /// <returns></returns>
        internal static String MakeCheckCode(this HttpSessionState httpSessionState, String VCode = "")
        {
            string RS = ZFrameCore.Common.StringHelper.CreateRandomCode(Convert.ToInt32(WCFWebConfig.AuthCodeLength));
            if (!String.IsNullOrEmpty(VCode))
            {
                httpSessionState[VCode] = RS;
            }
            else
            {
                httpSessionState["LoginCheckCode"] = RS;
            }
            MemoryStream MMS = GetCheckCodeImage(RS);
            return System.Convert.ToBase64String(MMS.ToArray());
        }

        #region 生成验证图片
        /// <summary>
        /// 生成验证码
        /// </summary>
        /// <param name="checkCode"></param>
        /// <returns></returns>
        internal static MemoryStream GetCheckCodeImage(String checkCode)
        {
            System.Drawing.Bitmap image = new System.Drawing.Bitmap((int)Math.Ceiling((checkCode.Length * 13.0) - 1), 18);
            System.Drawing.Graphics g = Graphics.FromImage(image);
            try
            {
                //生成随机生成器
                Random random = new Random();

                //清空图片背景色
                g.Clear(Color.White);

                //画图片的背景噪音线
                for (int i = 0; i < 25; i++)
                {
                    int x1 = random.Next(image.Width);
                    int x2 = random.Next(image.Width);
                    int y1 = random.Next(image.Height);
                    int y2 = random.Next(image.Height);

                    g.DrawLine(new Pen(Color.Silver), x1, y1, x2, y2);
                }

                Font font = new System.Drawing.Font("Arial", 12, (System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic));
                System.Drawing.Drawing2D.LinearGradientBrush brush = new System.Drawing.Drawing2D.LinearGradientBrush(new Rectangle(0, 0, image.Width, image.Height), Color.Blue, Color.DarkRed, 1.2f, true);
                g.DrawString(checkCode, font, brush, 1, 1);

                //画图片的前景噪音点
                for (int i = 0; i < 100; i++)
                {
                    int x = random.Next(image.Width);
                    int y = random.Next(image.Height);

                    image.SetPixel(x, y, Color.FromArgb(random.Next()));
                }

                //画图片的边框线
                g.DrawRectangle(new Pen(Color.Silver), 0, 0, image.Width - 1, image.Height - 1);

                System.IO.MemoryStream ms = new System.IO.MemoryStream();
                image.Save(ms, System.Drawing.Imaging.ImageFormat.Gif);
                return ms;
            }
            finally
            {
                g.Dispose();
                image.Dispose();
            }
        }
        #endregion
    }
}