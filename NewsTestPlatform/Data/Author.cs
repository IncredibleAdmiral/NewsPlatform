using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Data
{
    public class Author
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string NickName { get; set; }
        public DateTime CreateDataTime { get; set; }

        public List<Post> Posts { get; set; }

        public List<News> News { get; set; }

        
    }
}
