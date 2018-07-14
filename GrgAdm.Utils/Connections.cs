using MySql.Data.MySqlClient;

namespace GrgAdm.Utils
{
    public class Connections
    {
        public static MySqlConnection GestComBD {
            get { return new MySqlConnection(GetGestComConn()); }
            set { }
        }

        public static string BDName { get { return "sql2247566"; } }

        //private static string GestComConnectionString = "Database=gestcom;Data Source=127.0.0.1;User Id=root;Password=root;";

        private static string GetGestComConn()
        {   
            string BDHost = "sql2.freemysqlhosting.net";
            string BDUsername = "sql2247566";
            string BDPassword = "qZ2*eC7!";
            string BDPort = "3306";

            string conn = string.Format("Database={0};Data Source={1};User Id={2};Password={3};Port={4};SslMode=none;charset=utf8;convertzerodatetime=true;", BDName, BDHost, BDUsername, BDPassword, BDPort);
            return conn;
        }     
    }
}
