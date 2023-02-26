namespace EFCoreApp.DAL.Models
{
    public class OrderDetail
    {
        public int Id { get; set; }
        public string? Quantity { get; set; }
        public int ProductId { get; set; }
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public Product Product { get; set; }

    }
}