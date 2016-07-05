using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
 
using MySql.Data.Entity;
using MySql.Data.MySqlClient;
using Ryan.DomainModel.Ryan;

namespace MigrationsDemo
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class RyanContext : DbContext
    {
        
        public RyanContext():base("database")
        {
            
        }
        public DbSet<Blog> Blogs { get; set; }

        public DbSet<BallEntity> Ball { get; set; }
    }

    public class Blog
    {
        public int BlogId { get; set; }
        [MaxLength(122)]
        public string Name { get; set; }
 
       
        public  List<Post> Posts { get; set; }
    }
    public class Post
    {
        public int PostId { get; set; }
        [MaxLength(200)]
        public string Title { get; set; }
        [MaxLength(230)]
        public string Content { get; set; }

        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }


}