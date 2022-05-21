using Microsoft.AspNetCore.Mvc;
using coolbeanscoffee.web.Serialization;
using coolbeanscoffee.web.ViewModels;
using coolbeans.services.Product;

namespace coolbeanscoffee.web.Controllers {
    
    [ApiController]
    public class ProductController : ControllerBase {
        private readonly ILogger<ProductController> _logger;
        private readonly IProductService _productService;

        public ProductController(ILogger<ProductController> logger, IProductService productService) {
            _logger = logger;
            _productService = productService;
        }

        /// <summary>
        /// Adds a new product
        /// </summary>
        /// <param name="product"></param>
        /// <returns></returns>
        [HttpPost("/api/product")]
        public ActionResult AddProduct([FromBody] ProductModel product) {
            if (!ModelState.IsValid) {
                return BadRequest(ModelState);
            }
            _logger.LogInformation("Adding product");
            var newProduct = ProductMapper.SerializeProductModel(product);
            var newProductResponse = _productService.CreateProduct(newProduct);
            return Ok(newProductResponse);
        }

        /// <summary>
        /// Returns all products
        /// </summary>
        /// <returns></returns>
        [HttpGet("/api/product")]
        public ActionResult GetProduct() {
            _logger.LogInformation("Getting all products");
            var products = _productService.GetAllProducts();
            var productViewModels = products
                .Select(ProductMapper.SerializeProductModel);
            return Ok(productViewModels);
        }

        /// <summary>
        /// Archives an existing product
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPatch("/api/product/{id}")]
        public ActionResult ArchiveProduct(int id) {
            _logger.LogInformation("Archiving product");
            var archiveResult = _productService.ArchiveProduct(id);
            return Ok(archiveResult);
        }
    }
}