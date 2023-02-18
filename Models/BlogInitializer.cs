using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace filmdizikitap.Models
{
    public class BlogInitializer : DropCreateDatabaseIfModelChanges<BlogContext>
    {
        protected override void Seed(BlogContext context)
        {
            List<Category> kategoriler = new List<Category>()
            {
                new Category() {KategoriAdi="Filmler"},
                new Category() {KategoriAdi="Diziler"},
                new Category() {KategoriAdi="Kitaplar"},


            };

            foreach (var item in kategoriler)
            {
                context.Kategoriler.Add(item);
            }
            context.SaveChanges();
            List<Blog> bloglar = new List<Blog>()
            {
                new Blog(){
                    Baslik = "çok güzel kitap çıktı",
                    Aciklama = "çok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktı",
                    Eklenme_Tarihi= DateTime.Now,
                    Onay = true,
                    Anasayfa=true,
                    CategoryID= 3,
                    Icerik = "sanane la 1",
                    yazar_aciklama = "bu yazar en iyi yazardır daha iyisi hiç yok mükemmel bi adam",
                    yazar_adi = "Eslem Başaran",
                    yazar_resim = "user.jpg",
                    Resim = "carousel-1.jpg" },
                new Blog(){
                    Baslik = "lan çok iyi kitap",
                    Aciklama = "lan çok iyi kitaplan çok iyi kitaplan çok iyi kitaplan çok iyi kitaplan çok iyi kitapitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktıçok güzel kitap çıktı",
                    Eklenme_Tarihi= DateTime.Now,
                    Onay = true,
                    Anasayfa=true,
                    CategoryID= 3,
                    yazar_aciklama = "bu yazar en iyi yazardır daha iyisi hiç yok mükemmel bi adam",
                    yazar_adi = "Eslem Başaran",
                    yazar_resim = "user.jpg",
                    Icerik = "sanane la 2",
                    Resim = "carousel-2.jpg" },
                new Blog(){
                    Baslik = "eslem eslem eslemı",
                    Aciklama = "eslem eslem eslemı güzel kitap çıktıçok güzel eslem eslem eslemıeslem eslem eslemıeslem eslem eslemıeslem eslem eslemıeslem eslem eslemıeslem eslem eslemıeslem eslem eslemıeslem eslem eslemıeslem eslem eslemı",
                    Onay = true,
                    Eklenme_Tarihi= DateTime.Now,
                    Anasayfa=true,
                    CategoryID= 3,
                    Icerik = "sanane la 3",
                    Resim = "portfolio-1.jpg",
                    yazar_aciklama = "bu yazar en iyi yazardır daha iyisi hiç yok mükemmel bi adam",
                    yazar_adi = "Eslem Başaran",
                    yazar_resim = "user.jpg",},

            };
            foreach (var item in bloglar)
            {
                context.Bloglar.Add(item);
            }
            context.SaveChanges();

            List<Comment> yorumlar = new List<Comment>()
            {
                new Comment() {yorum="çok iyiydi",adsoyad="eslem",BlogID=1,EklenmeTarihi = DateTime.Now},
                new Comment() {yorum="eh işte i",adsoyad="eslem",BlogID=2,EklenmeTarihi = DateTime.Now},
                new Comment() {yorum="fena değil",adsoyad="eslem",BlogID=3,EklenmeTarihi = DateTime.Now},



            };

            foreach (var item in yorumlar)
            {
                context.Yorumlar.Add(item);
            }
            context.SaveChanges();
            base.Seed(context);
        }
    }
}