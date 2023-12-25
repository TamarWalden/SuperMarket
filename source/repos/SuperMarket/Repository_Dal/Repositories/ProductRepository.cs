using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Repository_Dal.Interfaces;
using Repository_Dal.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository_Dal.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private readonly IContext context;
        private readonly ILogger<string> logger;
        public ProductRepository(IContext context, ILogger<string> logger)
        {
            this.context = context;
            this.logger = logger;
        }
        public async Task<Product> AddAsync(Product entity)
        {
            try
            {
                var newProduct = await this.context.Products.AddAsync(entity);
                await context.SaveChangesAsync();
                return newProduct.Entity;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to add product" + ex.Message.ToString());
                return new Product();
            }
        }

        public async Task DeleteAsync(int id)
        {
            try
            {
                var product = await GetByIdAsync(id);
                context.Products.Remove(product);
                await context.SaveChangesAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to delete product" + ex.Message.ToString());
            }
        }

        public async Task<List<Product>> GetAllAsync()
        {
            try
            {
                return await context.Products.ToListAsync();
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get products" + ex.Message.ToString());
                return new List<Product>();
            }
        }

        public async Task<Product> GetByIdAsync(int code)
        {
            try
            {
                var prodact = await context.Products
                    .Include(p => p.CompanyCodeNavigation)
                    .Include(p=>p.DepartmentCodeNavigation)
                    .FirstOrDefaultAsync(p => p.Code == code);
                if (prodact == null)
                {
                    logger.LogError("The Product is null");
                    return new Product();
                }
                return prodact;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to get product" + ex.Message.ToString());
                return new Product();
            }
        }

        public async Task<Product> UpdateAsync(Product entity)
        {
            try
            {
                var productToUpdate = await GetByIdAsync(entity.Code);
                if (productToUpdate == null)
                {
                    logger.LogError("the code is not exit");
                    return new Product();
                }
                productToUpdate.Name = entity.Name;
                productToUpdate.DepartmentCode = entity.DepartmentCode;
                productToUpdate.CompanyCode = entity.CompanyCode;
                productToUpdate.Price = entity.Price;
                productToUpdate.Description = entity.Description;
                productToUpdate.Picture = entity.Picture;
                //TODO: update company, department,purchaseDetails with implement IClonable
                //company.clone();
                await context.SaveChangesAsync();
                return productToUpdate;
            }
            catch (Exception ex)
            {
                logger.LogError("failed to update product" + ex.Message.ToString());
                return new Product();
            }
        }
    }
}
