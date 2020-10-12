using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class Topic
    {
        string TopicName { get; set; }

        

        public List<NewsTopics> NewsTopics { get; set; }

        public List<PostsTopics> PostsTopics { get; set; }
    }
}
