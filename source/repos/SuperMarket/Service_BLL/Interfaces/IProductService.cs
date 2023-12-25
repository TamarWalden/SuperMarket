using Common_DTO.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service_BLL.Interfaces
{
    public interface IProductService
    {
        Task<ProductDTO> AddNewProductAsync(ProductDTO product);
        Task DeleteAsync(int id);
        Task<ProductDTO> GetByIdAsync(int id);
        Task<List<ProductDTO>> GetAllProductsAsync();
        Task<ProductDTO> UpdateAsync(ProductDTO product);
    }
}
