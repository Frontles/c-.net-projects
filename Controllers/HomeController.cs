using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using filmdizikitap.Models;
using PagedList;
using PagedList.Mvc;

namespace filmdizikitap.Controllers
{
    public class HomeController : Controller

    {
        private BlogContext context = new BlogContext();
        // GET: Home
        public ActionResult Index()
        {
            var bloglar = context.Bloglar
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Aciklama = i.Aciklama.Length > 500 ? i.Aciklama.Substring(0, 500) + "..." : i.Aciklama,
                    Anasayfa = i.Anasayfa,
                    Eklenme_Tarihi = i.Eklenme_Tarihi,
                    Resim = i.Resim,
                    Onay = i.Onay,
                    Icerik = i.Icerik.Length > 300 ? i.Icerik.Substring(0, 300) + "..." : i.Icerik,
                    CategoryID = i.CategoryID,


                })
                .Where(i => i.Onay == true);
            
            return View(bloglar.ToList().ToPagedList(1, 6));
        }


    }
}