using MySql.Data.MySqlClient;
using System.Data;

namespace GrgAdm.Utils
{
    public class Connections
    {
        public static MySqlConnection GestComBD {
            get { return new MySqlConnection(GetGestComConn()); }
            set { }
        }

        public static string BDName { get; set; }
        public static int ServerConfig { get; set; }

        private static string GetGestComConn()
        {
            DataTable dt = GetServers();
            BDName = (string)dt.Rows[ServerConfig]["BDName"];


            string conn = string.Format("Database={0};Data Source={1};User Id={2};Password={3};Port={4};SslMode=none;charset=utf8;convertzerodatetime=true;",
                                (string)dt.Rows[ServerConfig]["BDName"],
                                (string)dt.Rows[ServerConfig]["BDHost"],
                                (string)dt.Rows[ServerConfig]["BDUsername"],
                                (string)dt.Rows[ServerConfig]["BDPassword"],
                                (string)dt.Rows[ServerConfig]["BDPort"]);
            return conn;
        }
        
        private static DataTable GetServers()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("BDHost");
            dt.Columns.Add("BDUsername");
            dt.Columns.Add("BDPassword");
            dt.Columns.Add("BDPort");
            dt.Columns.Add("BDName");
            dt.Columns.Add("Obs");

            DataRow server = dt.NewRow();
            server[0] = "sql2.freemysqlhosting.net";
            server[1] = "sql2247566";
            server[2] = "qZ2*eC7!";
            server[3] = "3306";
            server[4] = "sql2247566";
            server[5] = "freemysqlhosting - 5mb";
            dt.Rows.Add(server);

            server = dt.NewRow();
            server[0] = "db4free.net";
            server[1] = "grgroot";
            server[2] = "grgroot@2018.";
            server[3] = "3306";
            server[4] = "gestcom";
            server[5] = "db4free - 200mb";
            dt.Rows.Add(server);

            server = dt.NewRow();
            server[0] = "remotemysql.com";
            server[1] = "CtJgpkhFAp";
            server[2] = "E9CljhAw2B";
            server[3] = "3306";
            server[4] = "CtJgpkhFAp";
            server[5] = "remotemysql.com - 100 mb";
            dt.Rows.Add(server);

            server = dt.NewRow();
            server[0] = "127.0.0.1";
            server[1] = "root";
            server[2] = "root";
            server[3] = "3306";
            server[4] = "gestcom";
            server[5] = "localhost";
            dt.Rows.Add(server);

            return dt;
        }
    }
}
