using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Models.ViewModels
{
    public class ViewPostModel
    {
      
            public string Id { get; set; }

            public string Title { get; set; }

            public string ShortNews { get; set; }

            public string Author { get; set; }

            public List<string> Topics { get; set; }

        
    }
}
