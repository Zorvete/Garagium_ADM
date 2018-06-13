using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace garagium_adm.Helpers
{
    public class BaseDados
    {
        private SqlConnection conn { get; set; }

        public BaseDados()
        {
            string connString = ConfigurationManager.ConnectionStrings["connectionStringName"].ConnectionString;

            this.conn = new SqlConnection(connString);
        }

        public BaseDados(string ConnectionString)
        {
            this.conn = new SqlConnection(ConnectionString);
        }   
    }
}