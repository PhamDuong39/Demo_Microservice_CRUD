using Product.Domain.Contractors.IEntities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Product.Domain.Entites
{
    public class TypeProduct : IEntities<int>
    {
        [Key]
        public int Id { get; set; }
        public string? TypeName { get; set; }

        public IEnumerable<Product> Products { get; set;}
    }
}
