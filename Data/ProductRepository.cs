using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Project_Skeleton.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Project_Skeleton.Data
{
    public class ProductRepository : IProductRepository
    {
        private readonly DataContext _dataContext;
        private readonly ILogger<DataContext> _logger;

        public ProductRepository(DataContext dataContext, ILogger<DataContext> logger)
        {
            _dataContext = dataContext;
            _logger = logger;
        }

        public IEnumerable<ProductDTO> GetProducts()
        {
            this._logger.LogInformation("GetProducts");
            return this._dataContext.Products.OrderBy(p => p.Name).ToList();
        }

        public IEnumerable<ProductDTO> GetProductsByName(string name)
        {
            this._logger.LogInformation("GetProductsByName " + name);
            return this._dataContext.Products.Where(p => p.Name == name).ToList();
        }

        public IEnumerable<ProductDTO> GetProductsByCategory(string category)
        {
            this._logger.LogInformation("GetProductsByCategory " + category);
            return this._dataContext.Products.Where(p => p.Category == category).ToList();
        }
        public ProductDTO GetProductById(int id)
        {
            this._logger.LogInformation("GetProductById " + id);
            return this._dataContext.Products.Find(id);
        }

        public async Task<bool> InsertProduct(ProductDTO product)
        {
            this._logger.LogInformation("GetProductById " + product);
            _dataContext.Products.Add(product);
            return await SaveChangesAsync();
        }
        public bool SaveChanges()
        {
            this._logger.LogInformation("SaveChanges");
            return this._dataContext.SaveChanges() > 0;
        }
        public async Task<bool> SaveChangesAsync()
        {
            this._logger.LogInformation("SaveChangesAsync");
            return await this._dataContext.SaveChangesAsync() > 0;
        }

        public OrderDTO GetOrderById(int id)
        {
            // Later include products also
            return this._dataContext.Orders
                .Include(o => o.OrderItems)
                .Where(o => o.Id == id)
                .FirstOrDefault();
        }
    }
}
