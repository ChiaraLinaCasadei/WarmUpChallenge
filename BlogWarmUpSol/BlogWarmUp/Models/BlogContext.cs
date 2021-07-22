using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogWarmUp.Models
{
    public class BlogContext: DbContext
    {
        public BlogContext(DbContextOptions<BlogContext> options)
            : base(options)
        {
        }

        public override int SaveChanges()
        {
            //Soft Delete
            foreach(var item in ChangeTracker.Entries()
                .Where(e => e.State == EntityState.Deleted &&
                       e.Metadata.GetProperties().Any(x => x.Name == "isDeleted")))
            {
                item.State = EntityState.Unchanged;
                item.CurrentValues["isDeleted"] = true;
            }
            return base.SaveChanges();
        }
        public DbSet<Post> Posts { get; set; }
    }
}
