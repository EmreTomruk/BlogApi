﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Blog.Models.Dtos
{
    public class ArticleDto
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public string BlogContent { get; set; }
        public DateTime ArticleDate { get; set; }
        [Required]
        public int CategoryId { get; set; }
    }
}
