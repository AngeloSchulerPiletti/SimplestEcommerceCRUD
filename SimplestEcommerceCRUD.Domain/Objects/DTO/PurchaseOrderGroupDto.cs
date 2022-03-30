namespace SimplestEcommerceCRUD.Domain.Objects.DTO
{
    public class PurchaseOrderGroupDto
    {
        public PurchaseOrderGroupDto(List<PurchaseOrderDto> purchases)
        {
            Purchases = purchases;
            int total = 0;
            foreach (PurchaseOrderDto purchaseOrder in purchases)
            {
                total += purchaseOrder.Total;
            }
            Total = total;
        }

        public List<PurchaseOrderDto> Purchases { get; set; }
        public int Total { get; set; } 
    }
}
