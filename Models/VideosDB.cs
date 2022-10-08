using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AppYTVideoAlbum.Models
{
    public class VideosDB
    {
        private readonly AppYTVideoDBEntities DB = new AppYTVideoDBEntities();


        public bool CreateLinkRegister(Videos model)
        {
            try
            {
                DB.Videos.Add(model);
                DB.SaveChanges();
                return true;

            }
            catch
            {

                return false;
            }
        }
        public Videos GetRegisterById(int Id)
        {
            Videos video = new Videos();
            try
            {
                video = DB.Videos.Find(Id);
                return video;
            }
            catch 
            {

                return video;
            }
        }
        public bool RemoveLink(int Id)
        {
            try
            {
                Videos video = DB.Videos.Find(Id);
                DB.Videos.Remove(video);
                DB.SaveChanges();
                return true;
            }
            catch
            {

                return false;
            }
        }
        public List<Videos> GetAllVideos()
        {
            return DB.Videos.OrderByDescending(colum => colum.IdVideo).ToList();
        }

    }
}