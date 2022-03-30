namespace SimplestEcommerceCRUD.Domain.Entities
{
    public class Purchase
    {
        public int Id { get; set; }
        public int CostumerId { get; set; }
        public virtual Costumer Costumer { get; set; }
        public virtual List<ItemPurchase> ItemPurchases { get; set; }
    }
}
