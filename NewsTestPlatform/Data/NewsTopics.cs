using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class NewsTopics
    {
       public Guid NewsId { get; set; }
        public News News { get; set; }


        public string TopicName { get; set; }
        public Topic Topic { get; set; }
    
    }
}
