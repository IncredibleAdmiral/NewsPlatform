using NewsTestPlatform.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Interfaces
{
    public interface INewsPostsGetter
    {
        public ViewNewsModel GetNews(Guid id);

        public List<ViewPostModel> GetPosts(int skipPosts);

        public ViewPostModel GetPost(Guid id);

        public List<ViewPostModel> GetPostsByTopic(string genre, int skipPosts);

    }
}
