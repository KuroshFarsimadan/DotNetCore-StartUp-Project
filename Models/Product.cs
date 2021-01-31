using Project_Skeleton.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Models
{
    public class Product : BaseModel
    {
        public int Id { get; set; }
        [Required]
        [MinLength(8)]
        public string Name { get; set; }
        [Required]
        [MinLength(5)]
        public string Category { get; set; }
        [Required]
        [MinLength(15)]
        public string Description { get; set; }
        public decimal Price { get; set; }
    }
}
