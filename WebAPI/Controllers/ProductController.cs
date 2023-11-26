using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        [HttpGet(("getall"))]
        public IActionResult GetAll()
        {
            var result = _productService.GetProductList();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpGet("getallbycategoryid")]
        public IActionResult GetById(int id)
        {
            var result = _productService.GetById(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Product product)
        {
            var result = _productService.Add(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

        [HttpPut("update")]
        public IActionResult Update(Product product)
        {
            var result = _productService.Update(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }
        [HttpDelete("delete")]
        public IActionResult Delete(Product product)
        {
            var result = _productService.Delete(product);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return BadRequest(result.Message);
        }

    }
}
