using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace core_mvc.Models
{
    public class Generator
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public List<User> Users { get; set; }         
    }
}