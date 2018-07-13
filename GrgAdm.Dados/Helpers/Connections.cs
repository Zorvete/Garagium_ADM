using MySql.Data.MySqlClient;

namespace GrgAdm.Dados.Helpers
{
    public class Connections
    {
        public static MySqlConnection GestComBD {
            get { return new MySqlConnection(GestComConnectionString); }
            set { }
        }

        private static string GestComConnectionString = "Database=gestcom;Data Source=127.0.0.1;User Id=root;Password=root;";

    }
}
