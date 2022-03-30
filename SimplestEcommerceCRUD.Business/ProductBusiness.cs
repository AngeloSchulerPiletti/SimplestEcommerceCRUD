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

        public ResponseVo CreateProduct(Product product)
        {
            try
            {
                Product savedProduct = _repository.CreateProduct(product);
                if (savedProduct == null) return new ResponseVo("Product not saved", "The product could not be saved");
                return new ResponseBagVo<Product>(savedProduct, "Product saved", "The product was saved succesfully", false);
            }
            catch (Exception)
            {
                return new ResponseVo("Product not saved", "Database problem");
            }
        }

        public ResponseVo DeleteProduct(int productId)
        {
            try
            {
                bool result = _repository.DeleteProduct(productId);
                if (result) return new ResponseVo("Product deleted", "The product was deleted successfully", false);
                return new ResponseVo("Product not deleted", "The product couldn't be deleted");
            }
            catch (Exception)
            {
                return new ResponseVo("Product not saved", "Database problem");
            }
        }

        public ResponseVo GetProduct(int productId)
        {
            Product product = _repository.GetProduct(productId);
            if (product == null) return new ResponseVo("Product not found", $"The product of id {productId} were not found");
            return new ResponseBagVo<Product>(product, "Product found", "The product were found succesfully", false);
        }
    }
}
