using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class Topic
    {
       
      [Key]
      public  string TopicName { get; set; }

        

        public List<NewsTopics> NewsTopics { get; set; }

        public List<PostsTopics> PostsTopics { get; set; }
    }
}
