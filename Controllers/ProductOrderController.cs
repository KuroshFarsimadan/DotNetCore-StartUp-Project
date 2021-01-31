using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Project_Skeleton.Data;
using Project_Skeleton.Entities;
using Project_Skeleton.Models;

namespace Project_Skeleton.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductOrderController : BaseController
    {
        private readonly IProductRepository _productRepository;
        private readonly DataContext _dataContext;
        private readonly ILogger<ProductOrderController> _logger;
        private readonly IMapper _mapper;

        public ProductOrderController(IProductRepository productRepository, DataContext dataContext, ILogger<ProductOrderController> logger, IMapper mapper)
        {
            _productRepository = productRepository;
            _dataContext = dataContext;
            _logger = logger;
            _mapper = mapper;
        }

        // Notice that this method is not authorized as the products are public
        // Website visitors should see the products inserted by other users
        [HttpGet("products")]
        public IEnumerable<ProductDTO> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        [Authorize]
        [HttpGet("products/{id}")]
        public Product GetProductById(int id)
        {
            try
            {
                var product = _mapper.Map<ProductDTO, Product>(_productRepository.GetProductById(id));
                if (product == null)
                {
                    product.Successful = false;
                    product.ErrorDescription = "Failed to get the product"; 
                }
                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to get product: " + id + " " + ex);
                var product = new Product();
                product.Successful = false;
                product.ErrorDescription = "Failed to get the product";
                return product;
            }

        }

        [Authorize]
        [HttpPost("products")]
        public async Task<Product> InsertProductAsync([FromBody]Product product)
        {
            try
            {
                bool successful = false;
                if (ModelState.IsValid)
                {
                    // You can also use automapper here.
                    var productDto = new ProductDTO()
                    {
                        Name = product.Name,
                        Description = product.Description,
                        Category = product.Category,
                        Price = product.Price
                    };
                    successful = await _productRepository.InsertProduct(productDto);

                    if (successful)
                    {
                        product.Id = productDto.Id;
                        _logger.LogError("Successful to insert product: " + product);
                    }
                    else
                    {
                        _logger.LogError("Failed to insert product: " + product);
                        product.Successful = false;
                        product.ErrorDescription = "Failed to insert product: " + product;
                    }
                    return product;
                }

                return product;
            }
            catch (Exception ex)
            {
                _logger.LogError("Failed to insert product: " + product + " " + ex);
                product.Successful = false;
                product.ErrorDescription = "Failed to insert product: " + product;
                return product;
            }

        }

        // Notice that this method is authorized as the orders are not public. We don't
        // want to share private user orders with anyone.
        [Authorize]
        [HttpGet("orders")]
        public async Task<IEnumerable<Order>> GetProductOrders()
        {
            var orders = await _dataContext.Orders.ToListAsync();
            return _mapper.Map<IEnumerable<OrderDTO>, IEnumerable<Order>>(orders);
        }

        [Authorize]
        [HttpGet("orders/{id}")]
        public async Task<Order> GetProductOrderById(int id)
        {
            var order = await _dataContext.Orders.FindAsync(id);
            return _mapper.Map<OrderDTO, Order>(order);
        }

        [Authorize]
        [HttpGet("orders/custom/{id}")]
        public Order GetProductOrderCustomById(int id)
        {
            var order = _productRepository.GetOrderById(id);
            return _mapper.Map<OrderDTO, Order>(order);
        }

        [Authorize]
        [HttpGet("orderitems")]
        public ActionResult<IEnumerable<OrderDTO>> GetProductOrderItems()
        {
            return _dataContext.Orders.Include(o => o.OrderItems).ThenInclude
                (i => i.Product).ToList();   
        }

        [Authorize]
        [HttpGet("orders/{id}/orderitems/{id}")]
        public async Task<OrderItem> GetProductOrderItemsAsync(int orderId, int orderItemId)
        {
            var order = await _dataContext.Orders.FindAsync(orderId);
            if(order != null)
            {
                var orderItem = order.OrderItems.Where(i => i.Id == orderItemId).FirstOrDefault();
                
                return _mapper.Map<OrderItemDTO, OrderItem>(orderItem); 
            }
            return new OrderItem();
        }

    }
}
