﻿using OnlineEdu.DTO.DTOs.BlogDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineEdu.App.DTOs.BlogCategoryDtos
{
    public class UpdateBlogCategoryDto
    {
        public int BlogCategoryID { get; set; }
        public string Name { get; set; }        
    }
}
