using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NewsTestPlatform.Data;
using NewsTestPlatform.Interfaces;
using NewsTestPlatform.Models.Logging;
using NewsTestPlatform.Models.ViewModels;

namespace NewsTestPlatform.Controllers
{
    public class PostController : Controller
    {


        readonly INewsPostsGetter getter;
        private readonly ILogger logger;


        public PostController(INewsPostsGetter getter, ILogger<PostController> logger)
        {

            this.getter = getter;
            this.logger = logger;
        }

        public ViewNewsModel GetNewsById(string id)
        {
            try
            {
                var conId = Guid.Parse(id);

                return getter.GetNews(conId);

            }
            catch (System.FormatException ex)
            {
                Logger.GetLogExeption(logger, ex, this);
                throw new Exception("GuidParseException  " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.GetLogExeption(logger, ex, this);
                throw ex;
            }


        }

        public List<ViewPostModel> GetPosts(int skipPosts)
        {
            return getter.GetPosts(skipPosts);
        }

        public ViewPostModel GetPostById(string id)
        {
            try
            {
                var conId = Guid.Parse(id);

                return getter.GetPost(conId);

            }
            catch (System.FormatException ex)
            {
                Logger.GetLogExeption(logger, ex, this);
                throw new Exception("GuidParseException  " + ex.Message);
            }
            catch (Exception ex)
            {
                Logger.GetLogExeption(logger, ex, this);
                throw ex;
            }
        }

        public List<ViewPostModel> GetPostsByTopic(string genre, int skipPosts)
        {


            return getter.GetPostsByTopic(genre, skipPosts);


        }
    }
}
