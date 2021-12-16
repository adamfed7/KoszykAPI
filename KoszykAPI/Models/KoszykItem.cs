using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace KoszykAPI.Models
{
    public class KoszykItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public string Promotion { get; set; } 
        public byte Quantity { get; set; }
        public bool InStock { get; set; }
    }
}
