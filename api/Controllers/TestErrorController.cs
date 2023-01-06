using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace api.Controllers
{
    public class TestErrorController : BaseApiController
    {
        [HttpGet("not-found")]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult GetNotFoundRequest()
        {
            return NotFound();
        }
        
        [HttpGet("bad-request")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetBadRequest()
        {
            return BadRequest();
        }
        
        [HttpGet("500-error")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetServerError()
        {
            return StatusCode(500);
        }
        
        [HttpGet("401-error")]
        [ProducesResponseType(StatusCodes.Status401Unauthorized)]
        public ActionResult GetUnauthorized()
        {
            return Unauthorized();
        }
        
        [HttpGet]
        public ActionResult GetBadRequest(string message)
        {
            if (message == null)
            {
                return BadRequest();
            }
            return Ok("This is a valid request");
        }
        
        [HttpGet("validation-error")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult GetValidationError()
        {
            ModelState.AddModelError("Test", "This is a test error");
            return ValidationProblem();
        }
        
        [HttpGet("exception")]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult GetServerErrorException()
        {
            throw new Exception("This is a test exception");
        }
    }
}