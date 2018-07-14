using System;
using System.Configuration;

namespace GrgAdm.Web
{
    public class Global : System.Web.HttpApplication
    {

        void Application_Start(object sender, EventArgs e)
        {
            string raiz = ConfigurationManager.AppSettings["PathRaiz"].ToString();

            GrgAdm.Utils.UtilsEx.PastaLogs = raiz + ConfigurationManager.AppSettings["PathLogs"].ToString();

            GrgAdm.Update.Update.PathScripts = raiz + ConfigurationManager.AppSettings["PathScripts"].ToString();
            GrgAdm.Update.Update.PathBackups = raiz + ConfigurationManager.AppSettings["PathBackups"].ToString();

            GrgAdm.Update.Update.AtualizarBD();
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

                GrgAdm.Utils.UtilsEx.Log(ex, "Erro Não tratado!");

                Server.ClearError();             
            }
            catch(Exception ex)
            {
                GrgAdm.Utils.UtilsEx.Log(ex);
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
