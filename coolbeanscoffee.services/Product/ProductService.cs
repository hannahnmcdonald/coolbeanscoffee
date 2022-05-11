using System;
using System.Collections.Generic;
using System.Linq;
using coolbeanscoffee.data;
using coolbeans.services.Product;
using coolbeanscoffee.services;
using coolbeanscoffee.data.Models;

namespace coolbeanscoffee.services.Product {
    public class ProductService : IProductService
    {

        private readonly CoolBeansDbContext _db;

        public ProductService(CoolBeansDbContext dbContext) {
            _db = dbContext;
        }
        
        /// <summary>
        /// Retrieves all Product from the database
        /// </summary>
        /// <returns></returns>
        public List<data.Models.Product> GetAllProducts() {
            return _db.Products.ToList();
        }

        /// <summary>
        /// Retrieves a Product from the database by primary key
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public data.Models.Product GetProductById(int id) {
            return _db.Products.Find(id);
        }

        /// <summary>
        /// Adds a new product to the database
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        public ServiceResponse<data.Models.Product> CreateProduct(data.Models.Product product) {
            try {
                _db.Products.Add(product);

                var newInventory = new ProductInventory {
                    Product = product,
                    QuantityOnHand = 0,
                    IdealQuantity = 10
                };

                _db.ProductInventories.Add(newInventory);
                
                _db.SaveChanges();
                
                return new ServiceResponse<data.Models.Product> {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Saved new product",
                    IsSuccess = true
                };
            }
            
            catch (Exception e) {
                return new ServiceResponse<data.Models.Product> {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false 
                };
            }
        }

        /// <summary>
        /// Archives a Product by setting boolean IsArchived to true
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public ServiceResponse<data.Models.Product> ArchiveProduct(int id) {
            try {
                var product = _db.Products.Find(id);
                product.IsArchived = true;
                _db.SaveChanges();

                return new ServiceResponse<data.Models.Product> {
                    Data = product,
                    Time = DateTime.UtcNow,
                    Message = "Archived Product",
                    IsSuccess = true
                };
            }

            catch (Exception e) {
                return new ServiceResponse<data.Models.Product> {
                    Data = null,
                    Time = DateTime.UtcNow,
                    Message = e.StackTrace,
                    IsSuccess = false
                };
            }
        }
    }
}