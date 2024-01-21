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
            return Ok(result);
        }
        [HttpGet(("getbyid"))]
        public IActionResult GetById(int productId)
        {
            var result = _productService.GetById(productId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet(("getallhomeproduct"))]
        public IActionResult GetAllHome()
        {
            var result = _productService.GetHomeList();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet(("getallhomecategoryproduct"))]
        public IActionResult GetAllHomeCategoryId(int categoryId)
        {
            var result = _productService.GetByCateggoryIdProductList(categoryId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        //[HttpGet("getallbycategoryid")]
        //public IActionResult GetById(int id)
        //{
        //    var result = _productService.GetById(id);
        //    if (result.IsSuccess)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
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
