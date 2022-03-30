using SimplestEcommerceCRUD.Business.Interfaces;
using SimplestEcommerceCRUD.Domain.Entities;
using SimplestEcommerceCRUD.Domain.Objects.VO;
using SimplestEcommerceCRUD.Repository.Interfaces;

namespace SimplestEcommerceCRUD.Business
{
    public class ProductBusiness : IProductBusiness
    {
        private readonly IProductRepository _repository;

        public ProductBusiness(IProductRepository repository)
        {
            _repository = repository;
        }

        public ResponseVo GetProduct(int productId)
        {
            Product product = _repository.GetProduct(productId);
            if (product == null) return new ResponseVo("Product not found", $"The product of id {productId} were not found");
            return new ResponseBagVo<Product>(product, "Product found", "The product were found succesfully", false);
        }
    }
}
