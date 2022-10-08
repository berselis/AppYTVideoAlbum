using AppYTVideoAlbum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;

namespace AppYTVideoAlbum
{
    public partial class PlayVideo : System.Web.UI.Page
    {
        private readonly VideosDB videosDB = new VideosDB();

        protected void Page_Load(object sender, EventArgs e)
        {
            int IdVideo = (int)HttpContext.Current.Session["IdVideo"];
            Videos video = videosDB.GetRegisterById(IdVideo);
            string embed = video.UrlVideo.Replace("watch?v=", "embed/");

            HtmlIframe frame = new HtmlIframe
            {
                Src = $"{embed}?controls=1&autoplay=1"
            };

            FameVideo.Controls.Add(frame);

           

        }
    }
}