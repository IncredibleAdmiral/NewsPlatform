using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class News
    {
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        public string Text { get; set; }
        public DateTime CreateDate { get; set; }


        public int AuthorId{ get; set; }
        public Author Author { get; set; }
      
        public List<NewsTopics> NewsTopics { get; set; }

}
}
