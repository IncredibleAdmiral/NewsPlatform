
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

            // многие ко многим новости и темы
            modelBuilder.Entity<NewsTopics>()
           .HasKey(nt => new { nt.NewsId, nt.TopicName });

            modelBuilder.Entity<NewsTopics>()
                .HasOne(sc => sc.News)
                .WithMany(s => s.NewsTopics)
                .HasForeignKey(sc => sc.NewsId);

            modelBuilder.Entity<NewsTopics>()
                .HasOne(sc => sc.Topic)
                .WithMany(c => c.NewsTopics)
                .HasForeignKey(sc => sc.TopicName);


            // // многие ко многим посты и темы

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






            //  один к одному пост и новость
            modelBuilder
            .Entity<News>()
            .HasOne(n => n.Post)
            .WithOne(p => p.News)
            .HasForeignKey<Post>(p => p.NewsId);




            //// один ко многим автор пост

            //modelBuilder.Entity<Post>()
            //    .HasOne(a => a.Author)
            //    .WithMany(p => p.Posts)
            //    .HasForeignKey(sc => sc.AuthorId);

            //// один ко многим автор новость

            //modelBuilder.Entity<News>()
            //    .HasOne(a => a.Author)
            //    .WithMany(n => n.News)
            //    .HasForeignKey(sc => sc.AuthorId);

        }
    }
}
