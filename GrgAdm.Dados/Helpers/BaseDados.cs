using System;
using MySql.Data.MySqlClient;
using System.Data;

namespace GrgAdm.Dados.Helpers
{
    public class BaseDados
    {

        public MySqlConnection conn { get; set; }

        public BaseDados()
        {
            this.conn = Connections.GestComBD;
        }

        public BaseDados(string ConnectionString)
        {
            this.conn = new MySqlConnection(ConnectionString);
        }

        public DataTable ExecQuery(string sql)
        {
            conn.Open();

            MySqlCommand command = conn.CreateCommand();
            command.CommandText = sql;
            MySqlDataReader reader = command.ExecuteReader();

            DataTable dt = new DataTable();
            dt.Load(reader);

            reader.Close();
            conn.Close();
            return dt;
        }

        public DataTable ExecQuery(string sql, params object[] parametros )
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            for (int i = 0; i < parametros.Length; i++)
                cmd.Parameters.AddWithValue("@" + (i + 1), parametros[i]);

            MySqlDataReader reader = cmd.ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Load(reader);     
            reader.Close();
            conn.Close();

            return dt;
        }

        public void ExecNonQuery(string sql)
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            cmd.ExecuteNonQuery();

            conn.Close();
        }

        public void ExecNonQuery(string sql, params object[] parametros)
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            for (int i = 0; i < parametros.Length; i++)
                cmd.Parameters.AddWithValue("@" + (i + 1), parametros[i]);

            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public int ExecNumberQuery(string sql)
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            int val = Convert.ToInt32(cmd.ExecuteScalar() + "");

            conn.Close();
            return val;
        }

        public int ExecNumberQuery(string sql, params object[] parametros)
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            for (int i = 0; i < parametros.Length; i++)
                cmd.Parameters.AddWithValue("@" +( i + 1), parametros[i]);

            int val = Convert.ToInt32(cmd.ExecuteScalar() + "");

            conn.Close();
            return val;
                
        }

        public string ExecStringQuery(string sql)
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            string val = cmd.ExecuteScalar().ToString();

            conn.Close();

            return val;
        }

        public string ExecStringQuery(string sql, params object[] parametros)
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;

            for (int i = 0; i < parametros.Length; i++)
                cmd.Parameters.AddWithValue("@" + (i + 1), parametros[i]);

            string val = cmd.ExecuteScalar().ToString();

            conn.Close();

            return val;
        }


    }
}