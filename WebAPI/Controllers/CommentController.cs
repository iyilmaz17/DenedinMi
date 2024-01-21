using Business.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentController : ControllerBase
    {
        private readonly ICommentService _commentService;
        public CommentController(ICommentService commentService)
        {
            _commentService = commentService;
        }
        [HttpGet("getall")]
        public IActionResult GetAll()
        {
            var result = _commentService.GetCommentList();
            if (result.Data != null)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }
        [HttpPost("add")]
        public IActionResult Add(Comment comment)
        {
            var result = _commentService.Add(comment);
            if (result.IsSuccess)
            {
                return Ok(result);

            }

            return BadRequest(result.Message);
        }
        [HttpGet("getbyproductid")]
        public IActionResult GetByProductId(int id)
        {
            var result = _commentService.GetByProductId(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet("getallbyproductid")]
        public IActionResult GetAllByProductId(int id)
        {
            var result = _commentService.GetAllByProductId(id);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet("getcommentdetail")]
        public IActionResult GetCommentDetail()
        {
            var result = _commentService.GetCommentAvg();
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
        [HttpGet("getcommentdetailbyproductid")]
        public IActionResult GetCommentDetailByProductId(int productId)
        {
            var result = _commentService.GetCommentDetailByProductId(productId);
            if (result.IsSuccess)
            {
                return Ok(result);
            }
            return Ok(result);
        }
    }
}
