using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Interfaces
{
  public  interface INewsWriter
    {

        public void WriteDownNewsToBase(int authorId, string newsName, string text, string annotaion, List<string> topicList);

        public void DeleteNews(string newsId);
    }
}
