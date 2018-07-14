using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.IO;
using GrgAdm.Utils;
using System.Data;
using System.Reflection;

namespace GrgAdm.Update
{
    public class Update
    {
        public static string PathBackups { set; get; }
        public static string PathScripts { set; get; }

        private static int VersaoUpdate = 2;
        private static int ConfigAtualizacaoUsing = 1;

        private const string ScriptName = "scr{0}.sql";

        public static void AtualizarBD()
        {
            try
            {
                if(String.IsNullOrEmpty(PathBackups))
                    throw new ApplicationException("Caminho da pasta de backups em falta!");

                if (String.IsNullOrEmpty(PathBackups))
                    throw new ApplicationException("Caminho da pasta dos scripts em falta!");

                if (!BackupBaseDados())
                    throw new ApplicationException("Backup da base de dados nao foi feita!");

                if (!HasAtualizacaoInDB())
                    throw new ApplicationException("Não existe ou nao esta configurada a tabela de atualizacoes!");

                

                BaseDados bd = new BaseDados();

                int VersaoRelease = -1;
                if (HasUpdates(out VersaoRelease))
                {
                    for (int i = VersaoRelease; i < (VersaoUpdate - VersaoRelease); i++)
                    {
                        UtilsEx.Log("Entrou no ciclo for. script n " + i);

                        string script = "\\" + string.Format(ScriptName, i);
                        string path = PathScripts + script;

                        if (!File.Exists(path))
                            throw new ApplicationException("Script" + i + " não existe!");

                        try
                        {
                            string content = File.ReadAllText(path);
                            bd.ExecNonQuery(path);

                            UtilsEx.Log("Executou script n " + i);
                        }catch(Exception e)
                        {
                            UtilsEx.Log(e, "Erro ao executar: script" + i);
                            break;
                        }
                    }
                }
            }catch(Exception e)
            {
                UtilsEx.Log(e, "Erro ao fazer update da base de dados!");
            }
        }

        private static bool BackupBaseDados()
        {
            try
            {
                string path = PathBackups;

                if (!Directory.Exists(path))
                    Directory.CreateDirectory(path);

                string file = path + "\\" + string.Format("{7}_BackupGestCom_{0}_{1}_{2}-{3}_{4}_{5}_{6}.sql", DateTime.Now.Year, DateTime.Now.Month, DateTime.Now.Day, DateTime.Now.Hour, DateTime.Now.Minute, DateTime.Now.Second, DateTime.Now.Millisecond, Environment.UserName);

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
                Utils.UtilsEx.Log(e);
                return false;
            }
        }

        private static bool HasAtualizacaoInDB()
        {
            BaseDados bd = new BaseDados();

            string sql = @"SELECT VersaoRelease, VersaoUpdate FROM atualizacao WHERE id = @1;";

            DataTable dt = bd.ExecQuery(sql, ConfigAtualizacaoUsing);

            if (dt == null || dt.Rows.Count == 0)
                return false;

            if (((int)dt.Rows[0]["VersaoRelease"] <= 0) || ((int)dt.Rows[0]["VersaoUpdate"] <= 0))
                return false;

            return true;
        }

        private static bool HasUpdates(out int VersaoRelease)
        {
            BaseDados bd = new BaseDados();
            string sql = @"SELECT VersaoRelease FROM atualizacao WHERE id = @1;";

            VersaoRelease = bd.ExecNumberQuery(sql, ConfigAtualizacaoUsing);
            return VersaoUpdate > VersaoRelease && VersaoRelease > 0;
        }
    }
}
