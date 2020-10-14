using NewsTestPlatform.Data;
using NewsTestPlatform.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Models.Convertors
{
    public static class ConvertorModelToView
    {
        public static ViewNewsModel ConvertNews(this News news)
        {
            return new ViewNewsModel()
            {
                 Id = news.Id.ToString(),
                  Text = news.Text,
                   Title= news.Name,
                    Topics = news.NewsTopics.Select(nt=> nt.TopicName).ToList() ,
                     Author = news.Author.NickName
            };
        }

        public static ViewPostModel ConvertPost(this Post post)
        {
            return new ViewPostModel()
            {
                Id = post.Id.ToString(),
                ShortNews = post.Annotation,
                Title = post.Name,
                Topics = post.PostsTopics.Select(pt => pt.TopicName).ToList(),
                Author = post.Author.NickName

            };
        }
    }
}
