using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace BLL
{
    public static class Utils
    {
        public static void MensajeToastr( Page page, string message, string title, string type = "info")
        {
            page.ClientScript.RegisterStartupScript(page.GetType(), "toastr_message",
                  String.Format("toastr.{0}('{1}', '{2}');", type.ToLower(), message, title), addScriptTags: true);
        }

        public static int ConvertirEntero(string texto)
        {
            int valor = 0;

            int.TryParse(texto, out valor);

            return valor;
        }
    }
}
