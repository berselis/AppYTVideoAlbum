
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml;


namespace AppYTVideoAlbum.Setup
{
    public class ApiKeyProvider
    {
        public string Getkey()
        {
            try
            {
                string xmlFile = HttpContext.Current.Server.MapPath("~/Setup/APIKEY.xml");
                XmlDocument xml = new XmlDocument();
                xml.Load(xmlFile);
                XmlElement root = xml.DocumentElement;
                return root.InnerText;
            }
            catch
            {
                return "YOUR_API_KEY";
            }
        }
    }
}