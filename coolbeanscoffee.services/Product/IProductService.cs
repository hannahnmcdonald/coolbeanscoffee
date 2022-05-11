using System.Collections.Generic;
using coolbeanscoffee.services;

namespace coolbeansservices.Product {
    public interface IProductService {
        List<data.Models.Product> GetAllProducts();
        data.Models.Product GetProductById(int id);
        ServiceResponse<data.Models.Product> CreateProduct(data.Models.Product product);
        ServiceResponse<data.Models.Product> ArchiveProduct(int id);
    }
}