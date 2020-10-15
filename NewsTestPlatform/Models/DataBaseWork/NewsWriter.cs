using Microsoft.Extensions.Logging;
using NewsTestPlatform.Data;
using NewsTestPlatform.Interfaces;
using NewsTestPlatform.Models.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace NewsTestPlatform.Models.DataBaseWork
{
    public class NewsWriter : INewsWriter
    {
       

        private readonly PlatformContext context;
        private readonly ILogger logger;
            
        public NewsWriter(ILogger logger)
        {
            context = new PlatformContext();
            this.logger = logger;
        }

        public void DeleteNews(string newsId)
        {
            try
            {
                Guid guidId = Guid.Parse(newsId);
                var delNews = context.News.SingleOrDefault(n => n.Id == guidId);
                context.News.Remove(delNews);
                context.SaveChanges();
            }
            catch (System.FormatException ex)
            {
                Logger.GetLogExeption(logger, ex, this);
                throw new Exception("GuidParseException  " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.GetLogExeption(logger, ex, this);
                throw new Exception(ex.Message);
            }

        }

        public void WriteDownNewsToBase(int authorId, string newsName, string text, string annotaion, List<string> topicList)
        {
            var author = context.Authors.SingleOrDefault(a => a.Id == authorId);

            if (author != null)
            {

                try
                {

                    Guid newNewsId = Guid.NewGuid();
                    Guid newPostId = Guid.NewGuid();


                    DateTime currentDate = DateTime.Now;

                    var newNews = new News()
                    {
                        Id = newNewsId,
                        Author = author,
                        CreateDate = currentDate,
                        Name = newsName,
                        Text = text,
                        NewsTopics = topicList.Select(t => new NewsTopics() { NewsId = newNewsId, TopicName = t }).ToList()

                    };


                    var newPost = new Post()
                    {
                        Id = newPostId,
                        Author = author,
                        CreateDate = currentDate,
                        Name = newsName,
                        Annotation = annotaion,
                        News = newNews,
                        PostsTopics = topicList.Select(t => new PostsTopics() { PostId = newPostId, TopicName = t }).ToList()

                    };

                    context.News.Add(newNews);
                    context.Posts.Add(newPost);
                    context.SaveChanges();
                }
                catch (System.FormatException ex)
                {
                    Logger.GetLogExeption(logger, ex, this);
                    throw new Exception("GuidParseException  " + ex.Message);
                }
                catch (Exception ex)
                {
                    Logger.GetLogExeption(logger, ex, this);
                    throw new Exception(ex.Message);
                }
            }
        }
    
    
    }
}
