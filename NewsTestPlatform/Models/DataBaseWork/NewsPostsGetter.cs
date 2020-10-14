using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsTestPlatform.Data;
using NewsTestPlatform.Interfaces;
using NewsTestPlatform.Models.Convertors;
using NewsTestPlatform.Models.Logging;
using NewsTestPlatform.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Models.DataBaseWork
{
    public class NewsPostsGetter : INewsPostsGetter
    {
        private readonly PlatformContext context;
        private readonly ILogger logger;


        public NewsPostsGetter(ILogger<NewsPostsGetter> logger)
        {
            context = new PlatformContext();
            this.logger = logger;
        }

        public ViewNewsModel GetNews(Guid id)
        {
            var result = context.News.Include(nt => nt.NewsTopics).Include(a => a.Author).SingleOrDefault(n=> n.Id == id).ConvertNews();
            return result;
        }

        public ViewPostModel GetPost(Guid id)
        {
            var result = context.Posts.Include(pt => pt.PostsTopics).Include(a => a.Author).SingleOrDefault(p => p.Id == id).ConvertPost();

            return result;
        }

        public List<ViewPostModel> GetPosts(int skipPosts)
        {
            var result = context.Posts.Include(tp=> tp.PostsTopics).Include(a=> a.Author).Skip(skipPosts).Take(6).Select(x => x.ConvertPost()).ToList();

            return result;
        }

        public List<ViewPostModel> GetPostsByTopic(string genre, int skipPosts)
        {
            var result = context.PostsTopics.Where(pt => pt.TopicName == genre).Include(pt => pt.Post).Select(x => x.Post).Skip(skipPosts).Take(6).Include(x=> x.PostsTopics)
                .Include(x=>x.Author).Select(x => x.ConvertPost()).ToList();
             
            return result;
        }
    }
}
