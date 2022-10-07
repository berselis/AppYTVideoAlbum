using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using static System.Net.Mime.MediaTypeNames;
using AppYTVideoAlbum.Setup;
using System.Runtime.InteropServices;

namespace AppYTVideoAlbum
{
    public partial class Default : System.Web.UI.Page
    {
        //validado formato de url
        private bool ValidateUrl(string url)
        {
            Uri evaluateUri;
            if (Uri.TryCreate(url, UriKind.RelativeOrAbsolute, out evaluateUri))
            {
                try
                {
                    return (evaluateUri.Scheme == Uri.UriSchemeHttp || evaluateUri.Scheme == Uri.UriSchemeHttps);
                }
                catch
                {
                    return false;
                }

            }
            return false;

        }
        //función para validar todas las caracteristicas de la entrada del string
        private bool ValidateInputStringUrl(string text)
        {

            if (text.Length == 0)
            {
                LabelMsj.Text = "Campo obligatorio";
                LabelMsj.Visible = true;
                return false;
            }


            //obteniendo el resultado de la validación de formato de la url, hacemos la negación para entrar en la condicionante cuando el formato no sea vóalido
            if (!ValidateUrl(text))
            {
                LabelMsj.Text = "Url incorrecta";
                LabelMsj.Visible = true;
                return false;
            }




            return true;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelMsj.Visible = false;
        }
        private string GetIdFromYTUrl(string url)
        {
            int start = url.IndexOf('=');
            return url.Substring(start + 1);
        }
        private string GetApiKey()
        {
            ApiKeyProvider provider = new ApiKeyProvider();
            return provider.Getkey();
        }


        //Evento dispadador del boton añadir
        protected void BtnAddUrl_Click(object sender, EventArgs e)
        {
            //Ejecutando la función para validar el dato de entrada y obteniendo su resultado
            if (ValidateInputStringUrl(UrlText.Text))
            {
                string endPointYT = $"https://www.googleapis.com/youtube/v3/videos?id={GetIdFromYTUrl(UrlText.Text)}&key={GetApiKey()}&part=snippet";





            }
        }
    }
}