using Microsoft.AspNetCore.Mvc;
using Project_Skeleton.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Project_Skeleton.Data
{
    public interface IProductRepository
    {
        IEnumerable<ProductDTO> GetProducts();
        IEnumerable<ProductDTO> GetProductsByCategory(string category);
        IEnumerable<ProductDTO> GetProductsByName(string name);
        bool SaveChanges();
        ProductDTO GetProductById(int id);
        OrderDTO GetOrderById(int id);
        Task<bool> InsertProduct(ProductDTO product);
    }
}