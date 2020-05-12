using API.Error;
using Infrastructure.Data;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    public class ErrorController : BaseController
    {
        private readonly AppDbContext _Context;
        public ErrorController(AppDbContext Context)
        {
            _Context = Context;

        }

        [HttpGet("notfound")]
        public ActionResult GetNotFoundRequest()
        {
            
            var item = _Context.Products.Find(42);
            if(item == null)
            {
              return  NotFound(new ApiResponse(404));
            }

            return Ok(item);
        }

        [HttpGet("servererror")]
        public ActionResult GetServerError()
        {
            var item = _Context.Products.Find(42);
            var itemString = item.ToString();
            return Ok();
        }

         [HttpGet("badrequest")]
        public ActionResult GetBadRequest()
        {
          return BadRequest(new ApiResponse(400));
        }
         [HttpGet("badrequest/{id}")]
        public ActionResult GetBadRequest(int id)
        {
            return Ok();
        }
    }
}