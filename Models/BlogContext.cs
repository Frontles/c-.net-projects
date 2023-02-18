using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace filmdizikitap.Models
{
    public class BlogContext: DbContext
    {
        public BlogContext():base("Filmdiziveritabani")
        {
            Database.SetInitializer(new BlogInitializer());
        }
        public DbSet<Blog> Bloglar { get; set; }
        public DbSet<Category> Kategoriler { get; set; }
        public DbSet<Comment> Yorumlar { get; set; }

    }
}