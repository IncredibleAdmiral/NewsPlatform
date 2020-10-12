using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class PostsTopics
    {
        public   Guid PostId { get; set; }
        public Post Post { get; set; }


        public string TopicName { get; set; }
        public Topic Topic { get; set; }
    }
}
