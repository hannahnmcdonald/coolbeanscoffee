using System.Collections.Generic;
using coolbeanscoffee.services;
using coolbeanscoffee.data;
using coolbeanscoffee.data.Models;
using coolbeanscoffee.services;

namespace coolbeans.services.Product {
    public interface IProductService {
        List<coolbeanscoffee.data.Models.Product> GetAllProducts();
        coolbeanscoffee.data.Models.Product GetProductById(int id);
        ServiceResponse<coolbeanscoffee.data.Models.Product> CreateProduct(coolbeanscoffee.data.Models.Product product);
        ServiceResponse<coolbeanscoffee.data.Models.Product> ArchiveProduct(int id);
    }
}