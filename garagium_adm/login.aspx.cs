using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using garagium_adm.Helpers;
using System.Data;
using GrgAdm.Dados.User;

namespace garagium_adm
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void dologinBtn_Click(object sender, EventArgs e)
        {
            try
            {
                string user = this.userTxt.Text;
                string pw = this.pwTxt.Text;

                if(String.IsNullOrEmpty(user) || String.IsNullOrWhiteSpace(user))
                {
                    return;
                }

                if (String.IsNullOrEmpty(pw) || String.IsNullOrWhiteSpace(pw))
                {
                    return;
                }

                UserInfo userInfo = Classes.Login.VerificarLogin(user, pw);

                if(userInfo == null)                
                    throw new Exception("Utilizador não tem informações!");

                SessionManager.userInfo = userInfo;

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {

            }
        }
    }
}