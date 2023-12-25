using AutoMapper;
using Common_DTO.Models;
using Microsoft.Extensions.Logging;
using Repository_Dal.Interfaces;
using Repository_Dal.Models;
using Service_BLL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_BLL.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository<Product> productRepository;
        private readonly IMapper mapper;
        private readonly ILogger<string> logger;

        public ProductService(IRepository<Product> productRepository, IMapper mapper, ILogger<string> logger)
        {
            this.productRepository = productRepository;
            this.mapper = mapper;
            this.logger = logger;
        }

        public async Task<ProductDTO> AddNewProductAsync(ProductDTO product)
        {
            try
            {
                var mapProduct = mapper.Map<Product>(product);
                var answer=await productRepository.AddAsync(mapProduct);
                return mapper.Map<ProductDTO>(answer);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to add product in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                await productRepository.DeleteAsync(id);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to delete product in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<List<ProductDTO>> GetAllProductsAsync()
        {
            try
            {
                var answer= await productRepository.GetAllAsync();
                return mapper.Map<List<ProductDTO>>(answer);    
            }
            catch (Exception ex)
            {
                logger.LogError("faild to get all products in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<ProductDTO> GetByIdAsync(int id)
        {
            try
            {
                var answer= await productRepository.GetByIdAsync(id);
                return mapper.Map<ProductDTO>(answer);
            }
            catch (Exception ex)
            {
                logger.LogError("faild to get product in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }

        public async Task<ProductDTO> UpdateAsync(ProductDTO product)
        {
            try
            {
                var mapProduct= mapper.Map<Product>(product);
                var answer= await productRepository.UpdateAsync(mapProduct);
                return mapper.Map<ProductDTO>(answer);
            }
            catch(Exception ex)
            {
                logger.LogError("faild to update product in the service" + ex.Message);
                //TODO: handele exception
                throw ex;
            }
        }
    }
}
