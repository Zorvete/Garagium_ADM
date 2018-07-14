using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GrgAdm.Update
{
    public class Update
    {
        public static string PathBackups { set; get; }
        public static void AtualizarBD()
        {
            if (!BackupBaseDados())
                throw new ApplicationException("Backup da base de dados nao foi feita!");
        }

        private static bool BackupBaseDados()
        {
            try
            {
                string path = PathBackups;

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string file = path + "\\" + string.Format("BackupGestCom_{0}_{1}_{2}-{3}_{4}_{5}_{6}.sql", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond);

                using (MySqlConnection conn = Utils.Connections.GestComBD)
                {
                    using (MySqlCommand cmd = new MySqlCommand())
                    {
                        using (MySqlBackup mb = new MySqlBackup(cmd))
                        {
                            cmd.Connection = conn;
                            conn.Open();

                            mb.ExportToFile(file);
                            conn.Close();
                        }
                    }
                }

                return true;
            }catch(Exception e)
            {
                return false;
            }
        }
    }
}
