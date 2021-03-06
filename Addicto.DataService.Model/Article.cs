﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Addicto.DataService.Model
{
    public class Article
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Key { get; set; }

        [Required]
        public string Content { get; set; }
    }
}
