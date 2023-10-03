using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Product : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public bool Status { get; set; }
        public bool IsKaputhane { get; set; }
        public Category Category { get; set; }
        public int CategoryId { get; set; }
        public List<Order> Orders { get; set; }
    }
}
