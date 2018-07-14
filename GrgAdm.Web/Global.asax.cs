using GrgAdm.Utils;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace garagium_adm
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            GrgAdm.Utils.UtilsEx.PastaLogs = ConfigurationManager.AppSettings["PathLogs"].ToString();
    
        }

        void Application_End(object sender, EventArgs e)
        {
            //  Code that runs on application shutdown

        }

        void Application_Error(object sender, EventArgs e)
        {
            try
            {
                Exception ex = Server.GetLastError();

                UtilsEx.Log(ex, "Erro Não tratado!");

                Server.ClearError();             
            }
            catch(Exception ex)
            {
                UtilsEx.Log(ex);
            }
            finally
            {
                Response.Redirect("~/Error404.html");
            }          
        }

        void Session_Start(object sender, EventArgs e)
        {
            // Code that runs when a new session is started

        }

        void Session_End(object sender, EventArgs e)
        {
            // Code that runs when a session ends. 
            // Note: The Session_End event is raised only when the sessionstate mode
            // is set to InProc in the Web.config file. If session mode is set to StateServer 
            // or SQLServer, the event is not raised.

        }

    }
}
