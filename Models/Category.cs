using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace filmdizikitap.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string KategoriAdi { get; set; }

        public int Blog_Sayisi { get; set; }
        public List<Blog> Bloglar { get; set; }
    }
}