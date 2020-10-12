using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class Post
    {
       public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(100)]
        public string Annotation { get; set; }
        
        public DateTime CreateDate { get; set; }

        public Guid NewsId { get; set; }

        public News News { get; set; }

        public int AuthorId { get; set; }
        public Author Author { get; set; }

        public  List<PostsTopics> PostsTopics { get; set; }
    }
}
