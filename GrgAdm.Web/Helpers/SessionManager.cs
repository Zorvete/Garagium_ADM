using GrgAdm.Dados.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.SessionState;
using System.Web.UI;

namespace garagium_adm.Helpers
{
    public class SessionManager
    {
        public static UserInfo userInfo { get; set; }

        public static String Idioma
        {
            get { return (string)Session["Idioma"] ?? "pt-PT"; }
            set { Session["Idioma"] = value; }
        }

        /// <summary>
        /// Verificar se existe um utilizador autenticado e com sessão ativa
        /// </summary>
        public static Boolean IsAuthenticated
        {
            get
            {
                bool isAuthenticated = false;

                if (HttpContext.Current.Request.IsAuthenticated)
                    if (Session != null && userInfo != null)
                        isAuthenticated = true;

                if (!isAuthenticated)
                    ASPUtils.SetNotAuthenticated();

                return isAuthenticated;
            }
        }

        /// <summary>
        /// Obter dados da página ativa
        /// </summary>
        private static HttpSessionState Session
        {
            get
            {
                Page page = HttpContext.Current.CurrentHandler as Page;
                if (page != null)
                    return page.Session;

                if (HttpContext.Current.Session != null)
                    return HttpContext.Current.Session;

                throw new ApplicationException("Não existe sessão ativa. Falta EnableSession no WebMethod?");
            }
        }
    }
}