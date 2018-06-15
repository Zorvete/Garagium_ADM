using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using garagium_adm.Helpers;
using System.Data;


namespace garagium_adm
{
    public partial class login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
           
        }

        protected void dologinBtn_Click(object sender, EventArgs e)
        {
            int result = 0;

            Classes.Login.VerificarLogin(this.userTxt.Text, this.pwTxt.Text);
        }
    }
}