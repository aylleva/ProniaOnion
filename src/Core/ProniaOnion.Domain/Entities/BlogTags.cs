﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProniaOnion.Domain.Entities
{
    public class BlogTags
    {
        public int BlogId {  get; set; }
        public int TagId {  get; set; }
        public Blog Blog {  get; set; }
        public Tag Tag { get; set; }
    }
}