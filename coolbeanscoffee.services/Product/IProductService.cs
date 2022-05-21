using coolbeanscoffee.services;

namespace coolbeanscoffee.services.Product {
    public interface IProductService {
        List<coolbeanscoffee.data.Models.Product> GetAllProducts();
        coolbeanscoffee.data.Models.Product GetProductById(int id);
        ServiceResponse<coolbeanscoffee.data.Models.Product> CreateProduct(coolbeanscoffee.data.Models.Product product);
        ServiceResponse<coolbeanscoffee.data.Models.Product> ArchiveProduct(int id);
    }
}