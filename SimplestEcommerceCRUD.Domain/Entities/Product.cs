namespace SimplestEcommerceCRUD.Domain.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public virtual List<ItemPurchase> ItemPurchases { get; set; }
    }
}
