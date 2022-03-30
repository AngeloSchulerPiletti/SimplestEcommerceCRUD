namespace SimplestEcommerceCRUD.Domain.Objects.DTO
{
    public class PurchaseOrderDto
    {
        public PurchaseOrderDto(List<PurchaseItemDto> purchaseItems)
        {
            PurchaseItems = purchaseItems;
            var total = 0;
            foreach (PurchaseItemDto purchaseItem in purchaseItems)
            {
                total += purchaseItem.Total;
            }
            Total = total;
        }

        public List<PurchaseItemDto> PurchaseItems { get; set; }
        public int Total { get; set; }
    }
}
