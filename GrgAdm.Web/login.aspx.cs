using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using garagium_adm.Helpers;
using System.Data;
using GrgAdm.Dados.User;
using System.Web.Security;

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
             
                HttpContext.Current.Session.Add("usId", SessionManager.userInfo.id + "");

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, SessionManager.userInfo.username, DateTime.Now, DateTime.Now.AddMinutes(120), false, SessionManager.userInfo.username);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);

                Response.Redirect("Default.aspx", false);
            }
            catch (Exception ex)
            {
               //TODO: Mostrar modal com as mensagens das exceptions
            }
        }
    }
}