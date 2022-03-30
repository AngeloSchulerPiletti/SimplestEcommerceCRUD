namespace SimplestEcommerceCRUD.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CustomerId { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual List<ItemPurchase> ItemPurchases { get; set; }
    }
}
