using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class News
    {
       [Key]
        
        public Guid Id { get; set; }

        [Required]
        public string Text { get; set; }

       
        [Required]
        public Author Author { get; set; }

        public DateTime CreateDate { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        
        

        public Post Post { get; set; }


        


        public List<NewsTopics> NewsTopics { get; set; }

    }
}
