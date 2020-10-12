
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class PlatformContext : DbContext
    {
  

        public  DbSet<Author> Authors { get; set; }
        public  DbSet<News> News { get; set; }       
        public  DbSet<Post> Posts { get; set; }        
        public  DbSet<Topic> Topics { get; set; }

       

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            
            
                optionsBuilder.UseSqlServer("Data Source = Admiral\\SQLEXPRESS; Initial Catalog = NewsPlatformBase; Integrated Security = True");
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<NewsTopics>()
           .HasKey(nt => new { nt.NewsId, nt.TopicName});

            modelBuilder.Entity<NewsTopics>()
                .HasOne(sc => sc.News)
                .WithMany(s => s.NewsTopics)
                .HasForeignKey(sc => sc.NewsId);

            modelBuilder.Entity<NewsTopics>()
                .HasOne(sc => sc.Topic)
                .WithMany(c => c.NewsTopics)
                .HasForeignKey(sc => sc.TopicName);

            modelBuilder.Entity<PostsTopics>()
           .HasKey(pt => new { pt.PostId, pt.TopicName });

            modelBuilder.Entity<PostsTopics>()
                .HasOne(sc => sc.Post)
                .WithMany(s => s.PostsTopics)
                .HasForeignKey(sc => sc.PostId);

            modelBuilder.Entity<PostsTopics>()
                .HasOne(sc => sc.Topic)
                .WithMany(c => c.PostsTopics)
                .HasForeignKey(sc => sc.TopicName);




        }
    }
}
