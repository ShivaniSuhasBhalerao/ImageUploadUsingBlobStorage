﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BookStore
{
    public class GetBlobRequestDto
    {
        [Required]
        public string Name { get; set; }
    }
}
