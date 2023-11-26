using Business.Abstract;
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
            //Thread.Sleep(2000);
            var result = _commentService.GetCommentList();
            if (result.Data != null)
            {
                return Ok(result);

            }

            return BadRequest(result);
        }
    }
}
