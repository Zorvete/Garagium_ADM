using garagium_adm.Helpers;
using System;
using System.Data;
using GrgAdm.Dados.User;


namespace GrgAdm.Web.Classes
{
    public class Login
    {
    
        public static UserInfo VerificarLogin(string username, string password)
        {

            BaseDados bd = new BaseDados();
            UserInfo userInfo = new UserInfo();

            string sql = @"SELECT IFNULL(id, -1) FROM gestcom.login WHERE username = @1 AND password = @2;";

            int id;
            try { id = bd.ExecNumberQuery(sql, username, password); }
            catch { id = -1; }
            
            if (id < 1) throw new Exception("Dados de Login Incorretos!");

            sql = @"SELECT bloqueado FROM gestcom.login WHERE id = @1;";

            int bloqueado = bd.ExecNumberQuery(sql, id);

            if(bloqueado != 0)
            {
                sql = @"SELECT bloqueio_data as data, bloqueio_motivo as motivo FROM gestcom.login WHERE id = @1;";
                DataTable dt = bd.ExecQuery(sql, id);

                string exp = "<b>Utilizador bloqueado</b> em: " + (String.IsNullOrEmpty(dt.Rows[0]["data"] + "") ? "---" : dt.Rows[0]["data"].ToString()) + "<br />" +
                            "<b>Motivo: </b>" + (String.IsNullOrEmpty(dt.Rows[0]["motivo"] + "") ? "---" : dt.Rows[0]["motivo"].ToString());

                throw new Exception(exp);
            }
            else
            {
                IncrementNumAcessos(id);          
                userInfo = GetUserInfo(id);
            }
                    

            return userInfo;
        }

        private static UserInfo GetUserInfo(int id)
        {
            BaseDados bd = new BaseDados();

            string sql = @"SELECT id, username, codigo, perfil, Nome, n_acessos, criacao_data FROM gestcom.login WHERE id = @1;";

            DataTable dt = bd.ExecQuery(sql, id);

            UserInfo info = new UserInfo();

            info.id = (String.IsNullOrEmpty(dt.Rows[0]["id"] + "") ? -1 : Convert.ToInt32(dt.Rows[0]["id"] + ""));
            info.username = (String.IsNullOrEmpty(dt.Rows[0]["username"] + "") ? "" : dt.Rows[0]["username"] + "");
            info.codigo = (String.IsNullOrEmpty(dt.Rows[0]["codigo"] + "") ? "" : dt.Rows[0]["codigo"] + "");
            info.perfil = (String.IsNullOrEmpty(dt.Rows[0]["perfil"] + "") ? -1 : Convert.ToInt32(dt.Rows[0]["perfil"] + ""));
            info.Nome = (String.IsNullOrEmpty(dt.Rows[0]["Nome"] + "") ? "" : dt.Rows[0]["Nome"] + "");
            info.criacao_data= (String.IsNullOrEmpty(dt.Rows[0]["criacao_data"] + "") ? DateTime.Now : Convert.ToDateTime(dt.Rows[0]["criacao_data"] + ""));
            info.n_acessos = (String.IsNullOrEmpty(dt.Rows[0]["n_acessos"] + "") ? -1 : Convert.ToInt32(dt.Rows[0]["n_acessos"] + ""));

            return info;
        }

        public static void IncrementNumAcessos(int id)
        {
            BaseDados bd = new BaseDados();

            string sql = @"SELECT n_acessos FROM gestcom.login WHERE id = @1;";
            int n_acess = bd.ExecNumberQuery(sql, id) + 1;

            sql = @"UPDATE gestcom.login SET n_acessos = @2 WHERE id = @1;";
            bd.ExecNonQuery(sql, id, n_acess);
        }

    }
}