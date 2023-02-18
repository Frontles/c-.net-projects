using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filmdizikitap.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public string yorum { get; set; }
        public DateTime EklenmeTarihi { get; set; }
        public string adsoyad { get; set; }
        public int BlogID { get; set; }
        public Blog Blog { get; set; }
    }
}