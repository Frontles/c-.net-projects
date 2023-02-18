using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filmdizikitap.Models
{
    public class Blog
    {
        public int Id { get; set; }
        public string Baslik { get; set; }
        public string Aciklama { get; set; }
        public string Resim { get; set; }
        public string Icerik { get; set; }
        public DateTime Eklenme_Tarihi { get; set; }
        public bool Onay { get; set; }
        public bool Anasayfa { get; set; }
        public string yazar_adi { get; set; }
        public string yazar_resim { get; set; }
        public string yazar_aciklama { get; set; }


        public int CategoryID { get; set; }
        public Category Category { get; set; }
        


    }
}