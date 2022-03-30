namespace SimplestEcommerceCRUD.Domain.Entities
{
    public class ItemPurchase
    {
        public int Id { get; set; }
        public int Quantity { get; set; }
        public int PurchaseId { get; set; }
        public int ProductId { get; set; }
        public virtual Purchase Purchase { get; set; }
        public virtual Product Product { get; set; }
    }
}
