namespace OkraFurnitureUI.Models
{
    public class ProformaViewModel
    {
        public int Amount { get; set; }
        public int Discount { get; set; }
        public decimal Price { get; set; }
        public int ProductId { get; set; }
        public int FabricId { get; set; }
        public int ProductColorId { get; set; }
        public int FootColorId { get; set; }
        public string CompanyName { get; set; }
        public string Address { get; set; }
    }
}
