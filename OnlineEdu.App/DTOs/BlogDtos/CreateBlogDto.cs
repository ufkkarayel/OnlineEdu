using OnlineEdu.App.DTOs.BlogCategoryDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.App.DTOs.BlogDtos
{
    public class CreateBlogDto
    {        
        public string Title { get; set; }
        public string Content { get; set; }
        public string ImageUrl { get; set; }
        public DateTime Date { get; set; } = DateTime.Now;
        public int BlogCategoryID { get; set; }
    }
}
