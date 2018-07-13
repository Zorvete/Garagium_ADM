using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace GrgAdm.Web.Helpers
{
    
    public static class ASPUtils
    {
        /// <summary>
        /// Obter valor de um parametro String
        /// </summary>
        /// 
        const string MISSING_PARAM = "Parametro em falta";
        const string INVALID_PARAM = "Parametro invalido";
        public static bool ASMX_GetStringParam(HttpContext context, string name, out string value)
        {
            return ASMX_GetStringParam(context, name, false, out value);
        }
        public static bool ASMX_GetStringParam(HttpContext context, string name, bool required, out string value)
        {
            value = "";

            if (!context.Request.Params.AllKeys.Contains(name))
            {
                if (required)
                {
                    String info = context.Request.Path + "\r\n" +
                                    "Falta um parametro: " + name;
                 

                    JSON.ReturnErro(context, MISSING_PARAM, name);
                    return false;
                }
                return true;
            }

            String param = context.Request[name];
            if (required && String.IsNullOrEmpty(param))
            {
                String info = context.Request.Path + "\r\n" +
                                "Falta o valor de um parametro: " + name;
                   

                JSON.ReturnErro(context, MISSING_PARAM, name);
                return false;
            }

            value = param;
            return true;
        }

        /// <summary>
        /// Obter valor de um parametro Data
        /// </summary>
        public static bool ASMX_GetDateParam(HttpContext context, string name, out DateTime value)
        {
            return ASMX_GetDateParam(context, name, false, out value);
        }
        public static bool ASMX_GetDateParam(HttpContext context, string name, bool required, out DateTime value)
        {
            value = DateTime.MinValue;

            String param = context.Request[name];
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            if (!DateTime.TryParse(param, out value))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            return true;
        }
        public static bool ASMX_GetDateParam(HttpContext context, string name, out DateTime? value)
        {
            return ASMX_GetDateParam(context, name, false, out value);
        }
        public static bool ASMX_GetDateParam(HttpContext context, string name, bool required, out DateTime? value)
        {
            value = null;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            DateTime valor;
            if (!DateTime.TryParse(param, out valor))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            value = valor;
            return true;
        }

        /// <summary>
        /// Obter valor de um parametro Hora
        /// </summary>
        public static bool ASMX_GetTimeParam(HttpContext context, string name, out DateTime value)
        {
            return ASMX_GetTimeParam(context, name, false, out value);
        }
        public static bool ASMX_GetTimeParam(HttpContext context, string name, bool required, out DateTime value)
        {
            value = DateTime.MinValue;

            String param = context.Request[name];
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            if (!DateTime.TryParse(param, out value))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            value = DateTime.MinValue.Add(value.TimeOfDay);
            return true;
        }
        public static bool ASMX_GetTimeParam(HttpContext context, string name, out DateTime? value)
        {
            return ASMX_GetTimeParam(context, name, false, out value);
        }
        public static bool ASMX_GetTimeParam(HttpContext context, string name, bool required, out DateTime? value)
        {
            value = null;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            DateTime valor;
            if (!DateTime.TryParse(param, out valor))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            value = DateTime.MinValue.Add(valor.TimeOfDay);
            return true;
        }

        /// <summary>
        /// Obter valor de um parametro Inteiro
        /// </summary>
        public static bool ASMX_GetIntParam(HttpContext context, string name, out int value)
        {
            return ASMX_GetIntParam(context, name, false, out value);
        }
        public static bool ASMX_GetIntParam(HttpContext context, string name, bool required, out int value)
        {
            value = 0;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            if (!int.TryParse(param, out value))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            return true;
        }
        public static bool ASMX_GetIntParam(HttpContext context, string name, out int? value)
        {
            return ASMX_GetIntParam(context, name, false, out value);
        }
        public static bool ASMX_GetIntParam(HttpContext context, string name, bool required, out int? value)
        {
            value = null;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            int valor;
            if (!int.TryParse(param, out valor))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            value = valor;
            return true;
        }

        /// <summary>
        /// Obter valor de um parametro Inteiro Longo
        /// </summary>
        public static bool ASMX_GetLongParam(HttpContext context, string name, out long value)
        {
            return ASMX_GetLongParam(context, name, false, out value);
        }
        public static bool ASMX_GetLongParam(HttpContext context, string name, bool required, out long value)
        {
            value = 0;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            if (!long.TryParse(param, out value))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            return true;
        }
        public static bool ASMX_GetLongParam(HttpContext context, string name, out long? value)
        {
            return ASMX_GetLongParam(context, name, false, out value);
        }
        public static bool ASMX_GetLongParam(HttpContext context, string name, bool required, out long? value)
        {
            value = null;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            long valor;
            if (!long.TryParse(param, out valor))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            value = valor;
            return true;
        }

        /// <summary>
        /// Obter valor de um parametro Decimal
        /// </summary>
        public static bool ASMX_GetDecimalParam(HttpContext context, string name, out double value)
        {
            return ASMX_GetDecimalParam(context, name, false, out value);
        }
        public static bool ASMX_GetDecimalParam(HttpContext context, string name, bool required, out double value)
        {
            value = 0;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            if (!double.TryParse(param, NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-US"), out value))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            return true;
        }
        public static bool ASMX_GetDecimalParam(HttpContext context, string name, out double? value)
        {
            return ASMX_GetDecimalParam(context, name, false, out value);
        }
        public static bool ASMX_GetDecimalParam(HttpContext context, string name, bool required, out double? value)
        {
            value = null;

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            double valor;
            if (!double.TryParse(param, NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-US"), out valor))
            {
                String info = context.Request.Path + "\r\n" +
                                "O valor do parametro é inválido: " + name;
                    

                JSON.ReturnErro(context, INVALID_PARAM, name);
                return false;
            }

            value = valor;
            return true;
        }

        /// <summary>
        /// Obter dicionário com parametros como um objeto composto
        /// </summary>
        public static Dictionary<String, Object> ASMX_GetParamDict(HttpContext context)
        {
            Dictionary<String, Object> result = new Dictionary<string, object>();

            // Desdobrar os parametros num dicionario
            foreach (String param in context.Request.Params.AllKeys)
            {
                String[] split = param.Split(new char[] { '[', ']' }, StringSplitOptions.RemoveEmptyEntries);

                Dictionary<String, Object> parent = result;
                for (int idx = 0; idx < split.Length; idx++)
                {
                    String item = split[idx];
                    if (idx < split.Length - 1)
                    {
                        if (!parent.ContainsKey(item))
                            parent.Add(item, new Dictionary<String, object>());

                        parent = (Dictionary<String, object>)parent[item];
                        continue;
                    }

                    parent.Add(item, context.Request.Params[param]);
                }
            }

            return result;
        }
        public static Dictionary<String, Object> ASMX_GetParamDictElem(Dictionary<String, Object> dict, String name)
        {
            if (!dict.ContainsKey(name))
                return null;

            return dict[name] as Dictionary<String, Object>;
        }
        public static String ASMX_GetParamDictString(Dictionary<String, Object> dict, String name)
        {
            if (!dict.ContainsKey(name))
                return "";

            return dict[name].ToString();
        }
        public static int? ASMX_GetParamDictInt(Dictionary<String, Object> dict, String name)
        {
            if (!dict.ContainsKey(name))
                return null;

            int valor;
            if (!int.TryParse(dict[name].ToString(), out valor))
                return null;

            return valor;
        }
        public static double? ASMX_GetParamDictDecimal(Dictionary<String, Object> dict, String name)
        {
            if (!dict.ContainsKey(name))
                return null;

            double valor;
            if (!double.TryParse(dict[name].ToString(), NumberStyles.Any, CultureInfo.CreateSpecificCulture("en-US"), out valor))
                return null;

            return valor;
        }
        public static DateTime? ASMX_GetParamDictDateTime(Dictionary<String, Object> dict, String name)
        {
            if (!dict.ContainsKey(name))
                return null;

            DateTime data;
            if (!DateTime.TryParse(dict[name].ToString(), out data))
                return null;

            return data;
        }

        /// <summary>
        /// Obter a expressão de OrderBy para uma lista
        /// </summary>
        public static string ASMX_GetListOrderBy(HttpContext context)
        {

            // Procurar todas as expressões de ordenação
            Dictionary<String, String[]> order = new Dictionary<String, String[]>();
            foreach (String parm1 in context.Request.Params.AllKeys)
            {
                if (!parm1.StartsWith("order["))
                    continue;

                String ordIdx = parm1.Substring(6, parm1.IndexOf("]") - 6);
                if (!order.ContainsKey(ordIdx))
                    order.Add(ordIdx, new String[2]);

                if (parm1.Contains("[dir]"))
                {
                    order[ordIdx][1] = context.Request[parm1];
                    continue;
                }

                if (!parm1.Contains("[column]"))
                    continue;

                String ordCol = context.Request[parm1];

                // Procurar o nome da coluna
                foreach (String parm2 in context.Request.Params.AllKeys)
                {
                    if (!parm2.StartsWith("columns[" + ordCol + "][data]"))
                        continue;

                    order[ordIdx][0] = context.Request[parm2];
                    break;
                }
            }

            String orderBy = "";
            foreach (String ordIdx in order.Keys)
            {
                String[] ordPair = order[ordIdx];
                if (String.IsNullOrEmpty(ordPair[0]))
                    continue;

                if (!String.IsNullOrEmpty(orderBy))
                    orderBy += ", ";

                orderBy += ordPair[0] + " " + (!String.IsNullOrEmpty(ordPair[1]) ? ordPair[1] : "asc");
            }

            return orderBy;
        }

        /// <summary>
        /// Formatar uma data conforme o idioma ativo
        /// </summary>
        public static String GetLanguageDate(DateTime date)
        {
            String idioma = System.Threading.Thread.CurrentThread.CurrentUICulture.Name.Substring(0, 2).ToLowerInvariant();

            String format = "dd/MM/yyyy";
            if (idioma == "en")
                format = "yyyy-MM-dd";

            return date.ToString(format);
        }

        /// <summary>
        /// Obter o endereço base da aplicação
        /// </summary>
        /// <returns></returns>
        public static String SiteURL
        {
            get { return FullUrl("~/"); }
        }

        /// <summary>
        /// Obter o diretório onde está instalada a aplicação
        /// </summary>
        public static String SitePath
        {
            get { return System.Web.Hosting.HostingEnvironment.MapPath("~/"); }
        }

        /// <summary>
        /// Converter um URL para absoluto
        /// </summary>
        public static String FullUrl(String url)
        {
            if (url.IndexOf(@"://") >= 0 || url == "#")
                return url;

            HttpRequest req = HttpContext.Current.Request;
            return String.Format("{0}://{1}{2}", req.Url.Scheme, req.Url.Authority, VirtualPathUtility.ToAbsolute(url));
        }

        /// <summary>
        /// Converter a localização fisica de um ficheiro num Url
        /// </summary>
        public static String FileUrl(String filePath)
        {
            if (!filePath.ToLowerInvariant().StartsWith(SitePath.ToLowerInvariant()))
                throw new ArgumentException("O ficheiro não está dentro do diretório da aplicação");

            return @"~/" + filePath.Replace(SitePath, "").Replace("\\", "/");
        }

        /// <summary>
        /// Indicar que um pedido não está autenticado (serviços)
        /// </summary>
        public static void SetNotAuthenticated()
        {
            HttpContext.Current.Response.Status = "401 Unauthorized";
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Indicar que um pedido não está autorizado (serviços)
        /// </summary>
        public static void SetNotAuthorized()
        {
            HttpContext.Current.Response.Status = "403 Forbidden";
            HttpContext.Current.Response.StatusCode = 403;
            HttpContext.Current.Response.End();
        }

        /// <summary>
        /// Indicar que um pedido não está autorizado (páginas)
        /// </summary>
        public static void RedirectNotAuthorized()
        {
            String pagePath;

            // Se estiver numa página com master page tenta usar NotAutorized ao nivel da Master Page
            System.Web.UI.Page page = HttpContext.Current.Handler as System.Web.UI.Page;
            if (page != null)
            {
                if (!String.IsNullOrWhiteSpace(page.MasterPageFile))
                {
                    String masterPath = HttpContext.Current.Server.MapPath(page.MasterPageFile);
                    pagePath = Path.Combine(Path.GetDirectoryName(masterPath), "~/Default.aspx");
                    if (File.Exists(pagePath))
                    {
                        HttpContext.Current.Response.Redirect(FileUrl(pagePath));
                        return;
                    }
                }
            }

            // Senão, se existir NotAuthorized ao nivel da raiz
            pagePath = HttpContext.Current.Server.MapPath("~/Default.aspx");
            if (File.Exists(pagePath))
            {
                HttpContext.Current.Response.Redirect(FileUrl(pagePath));
                return;
            }

            // Se não encontra a página, devolve apenas status NotAuthorized
            SetNotAuthorized();
        }

        /// <summary>
        /// Validar um ficheiro carregado e transformar em definitivo se necessário
        /// </summary>
        /// <returns>Devolve o URL para a localização definitiva do ficheiro</returns>
        public static String UploadCheckFile(String fileUrl, String savePath)
        {
            fileUrl = fileUrl.TrimStart('~', '/');
            fileUrl = "~/" + fileUrl;

            // Verificar se o ficheiro existe
            String filePath = HttpContext.Current.Server.MapPath(fileUrl);
            if (!File.Exists(filePath))
            {
                return "";
            }

            // Se já é um ficheiro definitivo, não altera
            String fileName = Path.GetFileName(filePath);
            if (!fileName.ToLowerInvariant().StartsWith("tmp_"))
                return fileUrl.TrimStart('~');

            // Se for um ficheiro temporário, transforma em definitivo
            String newPath = savePath.Trim('~', '/');
            newPath = "~/" + newPath + "/";
            newPath += fileName.Substring(4);

            String newUrl = VirtualPathUtility.ToAbsolute(newPath);

            // Mover o ficheiro temporário para definitivo
            newPath = HttpContext.Current.Server.MapPath(newUrl);

            String fileDir = Path.GetDirectoryName(newPath);
            if (!Directory.Exists(fileDir))
            {
                try
                {
                    Directory.CreateDirectory(fileDir);
                }
                catch (Exception ex)
                {
                    UtilsEx.Log(ex);
                    return "";
                }
            }

            try
            {
                File.Move(filePath, newPath);
            }
            catch (Exception ex)
            {
                UtilsEx.Log(ex);
                return "";
            }

            newUrl = VirtualPathUtility.ToAppRelative(newUrl);
            newUrl = newUrl.TrimStart('~');

            return newUrl;
        }

        /// <summary>
        /// Eliminar um ficheiro carregado
        /// </summary>
        public static void UploadDeleteFile(String url)
        {
            UploadDeleteFile(url, "");
        }
        public static void UploadDeleteFile(String oldUrl, String newUrl)
        {
            String oldFile = "";
            try
            {
                oldFile = HttpContext.Current.Server.MapPath(oldUrl);
            }
            catch { }

            String newFile = (!String.IsNullOrWhiteSpace(newUrl) ? HttpContext.Current.Server.MapPath(newUrl) : "");
            if (newFile == oldFile)
                return;

            if (!File.Exists(oldFile))
                return;

            // Eliminar o ficheiro antigo
            try
            {
                File.Delete(oldFile);
            }
            catch (Exception ex)
            {
                UtilsEx.Log(ex);
            }
        }


        //************************************************************************************
        //************************************************************************************


        /// <summary>
        /// Obter valor de um parametro de Imagem (Byte)
        /// </summary>
        public static bool ASMX_GetByteParam(HttpContext context, string name, out byte[] value)
        {
            return ASMX_GetByteParam(context, name, false, out value);
        }
        public static bool ASMX_GetByteParam(HttpContext context, string name, bool required, out byte[] value)
        {
            value = new byte[0];

            String param;
            if (!ASMX_GetStringParam(context, name, required, out param))
                return false;

            if (String.IsNullOrWhiteSpace(param) && !required)
                return true;

            return true;
        }


        //************************************************************************************
        //************************************************************************************



        /// <summary>
        /// Processar a foto do cartão do cidadão
        /// </summary>
        /// <returns>
        /// - Aumentar ao Gama para ficar mais clara
        /// - Aumentar ao contraste para se distinguir do fundo
        /// - Obter apenas o quadrado central
        /// </returns>
        public static byte[] ProcessFoto(String base64Foto)
        {

            // Carregar a fotografia
            Bitmap oldFoto = new Bitmap(new MemoryStream(Convert.FromBase64String(base64Foto)));

            // Converter imagem para um retangulo
            Bitmap newFoto = ProcessFoto_Rectangle(oldFoto);

            // Gamma
            ProcessFoto_Gamma(newFoto, 2, 2, 2);

            // Contrast
            ProcessFoto_Contrast(newFoto, 30);

            // Exportar a fotografia
            MemoryStream stream = new MemoryStream();
            newFoto.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            byte[] imageBytes = stream.ToArray();
            stream.Close();

            return imageBytes;
        }
        private static void ProcessFoto_Gamma(Bitmap bmap, double red, double green, double blue)
        {
            Color c;

            byte[] redGamma = ProcessFoto_GetGamma(red);
            byte[] greenGamma = ProcessFoto_GetGamma(green);
            byte[] blueGamma = ProcessFoto_GetGamma(blue);

            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    bmap.SetPixel(i, j, Color.FromArgb(redGamma[c.R], greenGamma[c.G], blueGamma[c.B]));
                }
            }
        }
        private static byte[] ProcessFoto_GetGamma(double color)
        {
            byte[] gammaArray = new byte[256];
            for (int i = 0; i < 256; ++i)
                gammaArray[i] = (byte)Math.Min(255, (int)((255.0 * Math.Pow(i / 255.0, 1.0 / color)) + 0.5));

            return gammaArray;
        }
        private static void ProcessFoto_Brigtness(Bitmap bmap, int brightness)
        {
            if (brightness < -255) brightness = -255;
            if (brightness > 255) brightness = 255;

            Color c;
            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    int cR = c.R + brightness;
                    int cG = c.G + brightness;
                    int cB = c.B + brightness;

                    if (cR < 0) cR = 1;
                    if (cR > 255) cR = 255;

                    if (cG < 0) cG = 1;
                    if (cG > 255) cG = 255;

                    if (cB < 0) cB = 1;
                    if (cB > 255) cB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)cR, (byte)cG, (byte)cB));
                }
            }
        }
        private static void ProcessFoto_Contrast(Bitmap bmap, double contrast)
        {
            Color c;

            if (contrast < -100) contrast = -100;
            if (contrast > 100) contrast = 100;

            contrast = (100.0 + contrast) / 100.0;
            contrast *= contrast;

            for (int i = 0; i < bmap.Width; i++)
            {
                for (int j = 0; j < bmap.Height; j++)
                {
                    c = bmap.GetPixel(i, j);
                    double pR = c.R / 255.0;
                    pR -= 0.5;
                    pR *= contrast;
                    pR += 0.5;
                    pR *= 255;
                    if (pR < 0) pR = 0;
                    if (pR > 255) pR = 255;

                    double pG = c.G / 255.0;
                    pG -= 0.5;
                    pG *= contrast;
                    pG += 0.5;
                    pG *= 255;
                    if (pG < 0) pG = 0;
                    if (pG > 255) pG = 255;

                    double pB = c.B / 255.0;
                    pB -= 0.5;
                    pB *= contrast;
                    pB += 0.5;
                    pB *= 255;
                    if (pB < 0) pB = 0;
                    if (pB > 255) pB = 255;

                    bmap.SetPixel(i, j, Color.FromArgb((byte)pR, (byte)pG, (byte)pB));
                }
            }
        }
        private static Bitmap ProcessFoto_Rectangle(Bitmap bmap)
        {
            int targetWidth = bmap.Width;
            int targetHeight = bmap.Height;
            if (targetWidth > targetHeight)
                targetWidth = targetHeight;
            else
                targetHeight = targetWidth;

            int x = bmap.Width / 2 - targetWidth / 2;
            int y = bmap.Height / 2 - targetHeight / 2;

            Rectangle cropArea = new Rectangle(x, y, targetWidth, targetHeight);

            return bmap.Clone(cropArea, bmap.PixelFormat);
        }

        /// <summary>
        /// Invocar um WebService remoto
        /// </summary>
        public static T CallWebService<T>(String url)
        {
            return CallWebService<T>(url, null);
        }
        public static T CallWebService<T>(String url, Dictionary<String, String> parms)
        {
            String info;

            // Obter dados do serviço
            String json = CallWebService(url, parms);

            // Tenta converter para o tipo pretendido
            Exception tipoEx;
            try
            {
                T obj = JSON.FromJSON<T>(json);
                return obj;
            }
            catch (Exception ex)
            {
                // Guardar a excepção
                tipoEx = ex;
            }

            // Se não devolveu o tipo pretendido, verifica se devolveu informação de erro
            RespostaInfo result = null;
            try
            {
                result = JSON.FromJSON<RespostaInfo>(json);
            }
            catch { }
            if (result != null && result.estado == "ERRO")
            {
                info = "Erro a invocar o serviço " + url + "\r\n" + result.info;
                throw new Exception(result.info);
            }

            // Senão, registar mesmo a excepção a converter para o tipo pretendido
            info = "Erro a invocar o serviço " + url;
            throw new Exception(info, tipoEx);
        }
        public static String CallWebService(String url)
        {
            return CallWebService(url, null, "POST");
        }
        public static String CallWebService(String url, String method)
        {
            return CallWebService(url, null, method);
        }
        public static String CallWebService(String url, Dictionary<String, String> parms)
        {
            return CallWebService(url, parms, "POST");
        }
        public static String CallWebService(String url, Dictionary<String, String> parms, String method)
        {
            Boolean isGet = (method.ToLowerInvariant() == "get");

            // Se for via POST, enviar dados
            if (!isGet)
            {
                NameValueCollection webParms = new NameValueCollection();
                if (parms != null)
                {
                    foreach (KeyValuePair<String, String> pair in parms)
                        webParms.Add(pair.Key, pair.Value);
                }

                try
                {
                    using (WebClient webClient = new WebClient())
                    {
                        byte[] bytes = webClient.UploadValues(url, method, webParms);
                        return Encoding.UTF8.GetString(bytes);
                    }
                }
                catch (Exception ex)
                {
                    UtilsEx.Log(ex);
                    throw;
                }
            }

            // Se for GET, adicionar ao Url
            if (parms != null)
            {
                foreach (KeyValuePair<String, String> pair in parms)
                    url += (url.IndexOf('?') > 0 ? "&" : "?") + pair.Key + "=" + Uri.EscapeDataString(pair.Value);
            }

            try
            {
                using (WebClient webClient = new WebClient())
                {
                    byte[] bytes = webClient.DownloadData(url);
                    return Encoding.UTF8.GetString(bytes);
                }
            }
            catch (Exception ex)
            {
                UtilsEx.Log(ex);
                throw;
            }
        }
    }
}