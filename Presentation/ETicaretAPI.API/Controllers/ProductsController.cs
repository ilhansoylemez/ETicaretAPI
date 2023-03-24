using ETicaretAPI.Application.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ETicaretAPI.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        readonly private IProductWriteRepository _productWriteRepository;
        readonly private IProductReadRepository _productReadRepository;
        public ProductsController(IProductWriteRepository productWriteRepository, IProductReadRepository productReadRepository)
        {
            _productWriteRepository = productWriteRepository;
            _productReadRepository = productReadRepository;
        }
        [HttpGet]
        public async void Get()
        {
            _productWriteRepository.AddRangeAsync(new()
            {
                new() { Id = Guid.NewGuid(), Name = "Product1", Stock=100, Price=500,CreatedDate = DateTime.UtcNow  },
                new() { Id = Guid.NewGuid(), Name = "Product2", Stock=200, Price=600,CreatedDate = DateTime.UtcNow  },
                new() { Id = Guid.NewGuid(), Name = "Product3", Stock=300, Price=5000,CreatedDate = DateTime.UtcNow  },
            }
                );
            await _productWriteRepository.SaveAsync();
        }
    }
}
