using Core.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Concrete
{
    public class Order : IEntity
    {
        [Key]
        public int Id { get; set; }
        public int Amount { get; set; }
        public int Discount { get; set; }
        public int Piece { get; set; }
        public decimal Price { get; set; }
        public decimal TotalPrice { get; set; }
        public string Description { get; set; }

        public Product Product { get; set; }
        public int ProductId { get; set; }

        public Fabric Fabric { get; set; }
        public int FabricId { get; set; }

        public ProductColor ProductColor { get; set; }
        public int ProductColorId { get; set; }

        public int FootId { get; set; }
        public Foot Foot { get; set; }

        public FootColor FootColor { get; set; }
        public int FootColorId { get; set; }

        public int ProformaId { get; set; }
        public Proforma Proforma { get; set; }

        public bool Status { get; set; }

    }
}
