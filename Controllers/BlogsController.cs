using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using filmdizikitap.Models;
using PagedList;
using PagedList.Mvc;

namespace filmdizikitap.Controllers
{
    public class BlogsController : Controller
    {
        private BlogContext db = new BlogContext();

        // GET: Blogs

        public ActionResult BlogListesi(int? page)
        {
            var bloglar = db.Bloglar.Include(b => b.Category).OrderByDescending(i => i.Eklenme_Tarihi);
            return View(bloglar.ToPagedList(page ?? 1, 6));


        }
        public PartialViewResult RecentPosts()
        {
            var bloglar = db.Bloglar
                .Select(i => new Blog()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Icerik = i.Icerik.Length > 300 ? i.Icerik.Substring(0, 300) + "..." : i.Icerik,
                    Aciklama = i.Aciklama.Length > 500 ? i.Aciklama.Substring(0, 500) + "..." : i.Aciklama,
                    Anasayfa = i.Anasayfa,
                    Eklenme_Tarihi = i.Eklenme_Tarihi,
                    Resim = i.Resim,
                    Onay = i.Onay

                })
                .Where(i => i.Onay == true && i.Anasayfa == true).OrderByDescending(i => i.Eklenme_Tarihi);


            return PartialView(db.Bloglar.ToList());

        }

        public ActionResult Index(int? page)
        {
            var bloglar = db.Bloglar
                .Select(i => new BlogModel()
                {
                    Id = i.Id,
                    Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                    Icerik = i.Icerik.Length > 300 ? i.Icerik.Substring(0, 300) + "..." : i.Icerik,
                    Aciklama = i.Aciklama.Length > 500 ? i.Aciklama.Substring(0, 500) + "..." : i.Aciklama,
                    Anasayfa = i.Anasayfa,
                    Eklenme_Tarihi = i.Eklenme_Tarihi,
                    Resim = i.Resim,
                    Onay = i.Onay

                })
                .Where(i => i.Onay == true);

            bloglar = bloglar.OrderByDescending(i => i.Eklenme_Tarihi);
            return View(bloglar.ToPagedList(page ?? 1, 9));


        }

        public ActionResult Category(int? id, string q)
        {
            var bloglar = db.Bloglar.Where(i => i.Onay == true).Select(i => new BlogModel()
            {
                Id = i.Id,
                Baslik = i.Baslik.Length > 100 ? i.Baslik.Substring(0, 100) + "..." : i.Baslik,
                Aciklama = i.Aciklama.Length > 500 ? i.Aciklama.Substring(0, 500) + "..." : i.Aciklama,
                Anasayfa = i.Anasayfa,
                Eklenme_Tarihi = i.Eklenme_Tarihi,
                Resim = i.Resim,
                Icerik = i.Icerik.Length > 300 ? i.Icerik.Substring(0, 300) + "..." : i.Icerik,
                Onay = i.Onay,
                CategoryID = i.CategoryID,
            }).AsQueryable();


            if (id != null)
            {
                bloglar = bloglar.Where(i => i.CategoryID == id);
                
            }

            else if (string.IsNullOrEmpty("q") == false)
            {
                bloglar = bloglar.Where(i => i.Baslik.Contains(q) || i.Aciklama.Contains(q));
            }

            ViewBag.categoryid = id;
            bloglar = bloglar.OrderByDescending(i => i.Eklenme_Tarihi);
            return View(bloglar.ToList().ToPagedList(1, 9));
        }

        // GET: Blogs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // GET: Blogs/Create
        public ActionResult Create()
        {
            ViewBag.CategoryID = new SelectList(db.Kategoriler, "Id", "KategoriAdi");
            return View();
        }

        // POST: Blogs/Create
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Eklenme_Tarihi,Onay,Anasayfa,CategoryID,yazar_adi,yazar_resim,yazar_aciklama")] Blog blog)
        {
            if (ModelState.IsValid)
            {
                blog.Eklenme_Tarihi = DateTime.Now;
                db.Bloglar.Add(blog);
                db.SaveChanges();
                return RedirectToAction("BlogListesi");
            }

            ViewBag.CategoryID = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryID);
            return View(blog);
        }

        // GET: Blogs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryID = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryID);
            return View(blog);
        }

        // POST: Blogs/Edit/5
        // Aşırı gönderim saldırılarından korunmak için bağlamak istediğiniz belirli özellikleri etkinleştirin. 
        // Daha fazla bilgi için bkz. https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Baslik,Aciklama,Resim,Icerik,Onay,Anasayfa,CategoryID,yazar_adi,yazar_resim,yazar_aciklama")] Blog blog)
        {
            if (ModelState.IsValid)
            {

                var entity = db.Bloglar.Find(blog.Id);
                if (entity != null)
                {
                    entity.CategoryID = blog.CategoryID;
                    entity.Anasayfa = blog.Anasayfa;
                    entity.Baslik = blog.Baslik;
                    entity.Aciklama = blog.Aciklama;
                    entity.Icerik = blog.Icerik;
                    entity.yazar_adi = blog.yazar_adi;
                    entity.yazar_resim = blog.yazar_resim;
                    entity.yazar_aciklama = blog.yazar_aciklama;
                    entity.Resim = blog.Resim;
                    entity.Onay = blog.Onay;
                    db.SaveChanges();
                    return RedirectToAction("BlogListesi");

                }

                
            }
            ViewBag.CategoryID = new SelectList(db.Kategoriler, "Id", "KategoriAdi", blog.CategoryID);
            return View(blog);
        }

        // GET: Blogs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Blog blog = db.Bloglar.Find(id);
            if (blog == null)
            {
                return HttpNotFound();
            }
            return View(blog);
        }

        // POST: Blogs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Blog blog = db.Bloglar.Find(id);
            db.Bloglar.Remove(blog);
            db.SaveChanges();
            return RedirectToAction("BlogListesi");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
