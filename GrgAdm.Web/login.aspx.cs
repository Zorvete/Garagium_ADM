using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using GrgAdm.Dados.Classes;
using System.Web.Security;
using GrgAdm.Web.Helpers;

namespace garagium_adm
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                
            }
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

                UserInfo userInfo = GrgAdm.Dados.Login.VerificarLogin(user, pw);

                if(userInfo == null)                
                    throw new Exception("Utilizador não tem informações!");

                SessionManager.userInfo = userInfo;
             
                HttpContext.Current.Session.Add("usId", SessionManager.userInfo.id + "");

                FormsAuthenticationTicket authTicket = new FormsAuthenticationTicket(1, SessionManager.userInfo.username, DateTime.Now, DateTime.Now.AddMinutes(120), false, SessionManager.userInfo.username);
                string encryptedTicket = FormsAuthentication.Encrypt(authTicket);
                HttpCookie authCookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
                Response.Cookies.Add(authCookie);

                Response.Redirect("Index.aspx", false);
            }
            catch (Exception ex)
            {
                this.errorMsg.Text = ex.Message;
                this.errorMsg.Visible = true;
            }
        }
    }
}