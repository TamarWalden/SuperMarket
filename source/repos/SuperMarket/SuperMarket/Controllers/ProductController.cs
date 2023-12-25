using Common_DTO.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Service_BLL.Interfaces;

namespace SuperMarket.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        readonly IProductService productService;
        private ILogger<string> logger;
        public ProductController(IProductService service, ILogger<string> logger)
        {
            productService = service;
            this.logger = logger;
        }

        [HttpGet]
        public async Task<ProductDTO> Get(int code)
        {
            try
            {
                return await productService.GetByIdAsync(code);
            }
            catch (Exception ex)
            {
                logger.LogError("faild in api to add product" + ex.Message);
                throw ex;
            }
        }
        // POST api/<ValuesController>
        [HttpPost]
        public async Task AddNewAssignment(ProductDTO newProduct)
        {
            try
            {
                await productService.AddNewProductAsync(newProduct);
            }
            catch (Exception ex) 
            {
                logger.LogError("faild in api to add product" + ex.Message);
            }
        }
    }
}
