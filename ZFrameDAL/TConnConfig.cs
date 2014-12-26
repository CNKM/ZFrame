using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Text.RegularExpressions;


namespace ZFrameDAL
{
    public static class TConnConfig
    {


       public static string SQLConnStr
        {
            get
            {
                return ConfigurationManager.ConnectionStrings["DBC"].ToString();
            }
            set
            {
                Configuration config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
                config.ConnectionStrings.ConnectionStrings["DBC"].ConnectionString = value;
                config.Save(ConfigurationSaveMode.Modified);
                ConfigurationManager.RefreshSection("connectionStrings");
            }
        }

        public static void GetDBConnInfo()
        {
            Regex r = new Regex("server=([^;]+);database=([^;]+);uid=([^;]+);pwd=([^;]+);Connection Timeout=([^;]+)");
            Match m = r.Match(SQLConnStr); // 在字符串中匹配
            DBCONNINFO.Server = m.Groups[1].Value;
            DBCONNINFO.Database = m.Groups[2].Value;
            DBCONNINFO.Uid = m.Groups[3].Value;
            DBCONNINFO.Pwd = m.Groups[4].Value;
            DBCONNINFO.Timeout = m.Groups[5].Value;
        }

    }

    public static class DBCONNINFO
    {
        static String _Server;

        public static String Server
        {
            get { return _Server; }
            set { _Server = value; }
        }
        static String _Database;

        public static String Database
        {
            get { return _Database; }
            set { _Database = value; }
        }
        static String _uid;

        public static String Uid
        {
            get { return _uid; }
            set { _uid = value; }
        }
        static String _pwd;

        public static String Pwd
        {
            get { return _pwd; }
            set { _pwd = value; }
        }
        static String _Timeout;

        public static String Timeout
        {
            get { return _Timeout; }
            set { _Timeout = value; }
        }
    }
}
