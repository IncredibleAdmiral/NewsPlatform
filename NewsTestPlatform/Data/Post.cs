using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class Post
    {
      
        [Key]       
        public Guid Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        [Required]
        [StringLength(200)]
        public string Annotation { get; set; }

        public Author Author { get; set; }
        public int AuthorId { get; set; }

        public DateTime CreateDate { get; set; }


        public Guid NewsId { get; set; }
        public News News { get; set; }


        //public int AuthorId { get; set; }
        

        public List<PostsTopics> PostsTopics { get; set; }
    }
}
