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
using System.Net;
using System.Web.Script.Serialization;
using AppYTVideoAlbum.Models;
using System.Web.UI.HtmlControls;
using System.Security.Claims;

namespace AppYTVideoAlbum
{
    public partial class Default : System.Web.UI.Page
    {
        //Clase de negociación con la base de datos
        private readonly VideosDB videosDB = new VideosDB();
        private readonly JavaScriptSerializer json = new JavaScriptSerializer();

        protected void Page_Load(object sender, EventArgs e)
        {
            LabelMsj.Visible = false;
            SetAllVideoToList();
        }
        private void SetAllVideoToList()
        {
            List<Videos> videos = videosDB.GetAllVideos();
            foreach (Videos video in videos)
            {
                PanelVideoList.Controls.Add(GenerateFrameVideo(video));


            }

        }
        private Panel GenerateFrameVideo(Videos video)
        {
            Panel panel = new Panel
            {
                CssClass = "card-video"
            };
            HyperLink btnToRemoveLink = new HyperLink
            {
                CssClass = "btn-delete-video",
                ID = $"{video.IdVideo}_Remove",
                Text = "X"
            };
            panel.Controls.Add(btnToRemoveLink);

            HyperLink detail = new HyperLink
            {
                CssClass = "view-detail"

            };

            System.Web.UI.WebControls.Image img = new System.Web.UI.WebControls.Image
            {
                CssClass = "img-fluid",
                ImageUrl = video.UrlImg,
                ID = $"{video.IdVideo}_Img"
            };

            detail.Controls.Add(img);
            panel.Controls.Add(detail);

            //TextBox labelData = new TextBox
            //{
            //    CssClass = "hidden-element",
            //    ID = $"{video.IdVideo}_Label",
            //    Text = json.Serialize(video)
            //};

            Label labelData = new Label
            {
                CssClass = "hidden-element",
                ID = $"{video.IdVideo}_Label",
                Text = json.Serialize(video)
            };

            panel.Controls.Add(labelData);



            return panel;
        }
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
        private string QueryYTApi(string endPoint)
        {
            WebClient webClient = new WebClient();
            try
            {
                webClient.Encoding = System.Text.Encoding.UTF8;
                return webClient.DownloadString(endPoint);
            }
            catch
            {
                return "ERROR";

            }


        }
        private Videos TransformJsonToObject(string rawJSON)
        {

            Videos model = new Videos();


            try
            {
                JsonDataModelYT obj = json.Deserialize<JsonDataModelYT>(rawJSON);

                model.UrlVideo = UrlText.Text;
                model.Tittle = obj.Items.FirstOrDefault().Snippet.Title;
                model.Descript = obj.Items.FirstOrDefault().Snippet.Description;
                model.UrlImg = obj.Items.FirstOrDefault().Snippet.Thumbnails.High.Url;

                return model;
            }
            catch
            {
                return model;
            }
        }
        //Evento dispadador del boton añadir
        protected void BtnAddUrl_Click(object sender, EventArgs e)
        {
            //Validado la información de entrada y obteniendo su resultado
            if (ValidateInputStringUrl(UrlText.Text))
            {
                string endPointYT = $"https://www.googleapis.com/youtube/v3/videos?id={GetIdFromYTUrl(UrlText.Text)}&key={GetApiKey()}&part=snippet";

                string rawJSON = QueryYTApi(endPointYT);

                Videos newLink = TransformJsonToObject(rawJSON);
                if (newLink.Tittle == null)
                {
                    LabelMsj.Text = "Información inválida";
                    LabelMsj.Visible = true;
                    return;

                }

                if (videosDB.CreateLinkRegister(newLink)) Response.Redirect("Default.aspx");



            }
        }
        protected void BtnConfirmRemove_Click(object sender, EventArgs e)
        {
            int IdVideo = Convert.ToInt32(IdVideoDelete.Text);
            if (videosDB.RemoveLink(IdVideo)) Response.Redirect("Default.aspx");
        }
        protected void BtnVideoPlay_Click(object sender, EventArgs e)
        {
            int IdVideo = Convert.ToInt32(IdVideoPlay.Text);
            HttpContext.Current.Session.Add("IdVideo",IdVideo);

            Response.Redirect($"~/PlayVideo.aspx");
            //Response.Redirect($"~/PlayVideo.aspx?{IdVideo}");

        }
    }
}