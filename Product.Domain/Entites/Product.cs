using Product.Domain.Contractors.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entites
{
    public class Product : IEntities<int>
    {
        [Key]
        public int Id { get; set; }
        public int TypeProductId { get; set; }
        public string? ProductName { get; set; }
        public double? Price { get; set; }
        public string? Description { get; set; }
        public DateTime ExpDate { get; set; }
        public string? ProductSign { get; set; }
        public TypeProduct TypeProduct { get; set; }
    }
}
