using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;

namespace garagium_adm.Helpers
{
    public class BaseDados
    {  
        public MySqlConnection conn { get; set; }

        public BaseDados()
        {
            string connString = ConfigurationManager.ConnectionStrings["gestcomBD"].ConnectionString;

            this.conn = new MySqlConnection(connString);
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
            return dt;
        }

        public DataTable ExecQuery(string sql, params object[] parametros )
        {
            conn.Open();

            MySqlCommand cmd = conn.CreateCommand();
            cmd.CommandText = sql;
            
            for(int i = 0; i < parametros.Length; i++)
                cmd.Parameters.AddWithValue("@" + i, parametros[i]);
            
            MySqlDataReader reader = cmd.ExecuteReader();
            
            DataTable dt = new DataTable();
            dt.Load(reader);     
            reader.Close();

            return dt;
        }


    }
}