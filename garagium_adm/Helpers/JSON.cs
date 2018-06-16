using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace garagium_adm.Helpers
{
    public static class JSON
    {
        /// <summary>
        /// Devolver informação de erro
        /// </summary>
        public static void ReturnErro(HttpContext context, String info)
        {
            ReturnErro(context, info, "");
        }
        /// <summary>
        /// Devolver informação de erro
        /// </summary>
        public static void ReturnErro(HttpContext context, String info, String dados)
        {
            RespostaInfo resp = new RespostaInfo()
            {
                estado = "ERRO",
                info = info,
                dados = dados
            };

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(resp);

            context.Response.Write(jsonString);

            AllowCrossDomain(context);
        }

        /// <summary>
        /// Devolver informação de conclusão
        /// </summary>
        public static void ReturnInfo(HttpContext context)
        {
            ReturnInfo(context, "");
        }

        /// <summary>
        /// Devolver informação de conclusão
        /// </summary>
        public static void ReturnInfo(HttpContext context, String info)
        {
            RespostaInfo resp = new RespostaInfo()
            {
                estado = "OK",
                info = info
            };

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(resp);

            context.Response.Write(jsonString);

            AllowCrossDomain(context);
        }

        /// <summary>
        /// Devolver dados para uma lista de registos
        /// </summary>
        public static void ReturnTableData(HttpContext context, DataTable dt, int numrows, int pagenum, int requestId)
        {
            List<Dictionary<String, String>> rows = new List<Dictionary<String, String>>();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<String, String> cols = new Dictionary<String, String>();
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName == "_rownum")
                        continue;

                    String valor = row[col.ColumnName] != DBNull.Value ? row[col.ColumnName].ToString().Trim() : "";

                    cols.Add(col.ColumnName, valor);
                }
                rows.Add(cols);
            }

            ReturnTableData(context, rows, numrows, pagenum, requestId);
        }

        /// <summary>
        /// Devolver dados para uma lista de registos
        /// </summary>
        public static void ReturnTableData(HttpContext context, List<Dictionary<String, String>> rows, int numrows, int pagenum, int requestId)
        {
            RespostaGrid resp = new RespostaGrid()
            {
                draw = requestId,
                recordsTotal = numrows,
                recordsFiltered = numrows,
                data = rows,
                customActionMessage = null,
                customActionStatus = null
            };

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(resp);

            context.Response.Write(jsonString);

            AllowCrossDomain(context);
        }

        /// <summary>
        /// Devolver informação de erro para uma lista de registos
        /// </summary>
        public static void ReturnTableError(HttpContext context, String message, int requestId)
        {
            ReturnTableError(context, message, "ERROR", requestId);
        }

        /// <summary>
        /// Devolver informação de erro para uma lista de registos
        /// </summary>
        public static void ReturnTableError(HttpContext context, String message, String status, int requestId)
        {
            RespostaGrid resp = new RespostaGrid()
            {
                draw = requestId,
                recordsTotal = 0,
                recordsFiltered = 0,
                data = new List<Dictionary<string, string>>(),
                customActionMessage = message,
                customActionStatus = status
            };

            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(resp);

            context.Response.Write(jsonString);

            AllowCrossDomain(context);
        }

        /// <summary>
        /// Devolver dados para uma lista de registos
        /// </summary>
        public static void ReturnJSON(HttpContext context, DataTable dt)
        {
            List<Dictionary<String, String>> rows = new List<Dictionary<String, String>>();
            foreach (DataRow row in dt.Rows)
            {
                Dictionary<String, String> cols = new Dictionary<String, String>();
                foreach (DataColumn col in dt.Columns)
                {
                    if (col.ColumnName == "_rownum")
                        continue;

                    String valor = row[col.ColumnName] != DBNull.Value ? row[col.ColumnName].ToString().Trim() : "";

                    cols.Add(col.ColumnName, valor);
                }
                rows.Add(cols);
            }

            ReturnJSON(context, rows);
        }

        /// <summary>
        /// Devolver um objecto em JSON
        /// </summary>
        public static void ReturnJSON(HttpContext context, Object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(obj);

            ReturnJSON(context, jsonString);
        }

        /// <summary>
        /// Devolver uma string JSON
        /// </summary>
        public static void ReturnJSON(HttpContext context, String jsonString)
        {
            context.Response.Write(jsonString);
            context.Response.ContentType = "application/json";

            AllowCrossDomain(context);
        }

        /// <summary>
        /// Obter um objeto convertido para JSON
        /// </summary>
        public static String GetJSON(Object obj)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            string jsonString = jss.Serialize(obj);

            return jsonString;
        }

        /// <summary>
        /// Converter JSON para um objeto
        /// </summary>
        public static T FromJSON<T>(string json)
        {
            JavaScriptSerializer jss = new JavaScriptSerializer();
            T obj = jss.Deserialize<T>(json);

            return obj;
        }

        /// <summary>
        /// Permitir chamadas de serviços em Cross-Domain
        /// </summary>
        private static void AllowCrossDomain(HttpContext context)
        {
            if (!String.IsNullOrWhiteSpace(context.Request.Headers["Origin"]))
                context.Response.AddHeader("Access-Control-Allow-Origin", "*");
        }
    }

    /// <summary>
    /// Formato de resposta com informação d estado de execução
    /// </summary>
    public class RespostaInfo
    {
        public String estado;
        public String info;
        public String dados;
    }

    /// <summary>
    /// Formato de resposta com dados para uma grid
    /// </summary>
    public class RespostaGrid
    {
        public List<Dictionary<String, String>> data;
        public int draw;
        public int recordsTotal;
        public int recordsFiltered;
        public String customActionMessage;
        public String customActionStatus;
    }
}