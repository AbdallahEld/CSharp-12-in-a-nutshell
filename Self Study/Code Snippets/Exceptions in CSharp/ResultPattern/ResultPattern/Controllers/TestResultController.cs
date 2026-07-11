using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ResultPattern.Result_Pattern;

namespace ResultPattern.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestResultController : ControllerBase
    {
        [HttpGet("user/{id}")]
        public IActionResult GetUser(int id)
        {
            if (id <= 0)
            {
                var failureResult = Result<string>.ResultFailure(
                    error: "Invalid ID provided.",
                    message: "User ID must be greater than zero."
                );

                return BadRequest(failureResult);
            }

            var dummyUser = new { Id = id, Name = "Ahmed Ali", Email = "ahmed@example.com" };

            var successResult = Result<object>.ResultSuccess(
                value: dummyUser,
                message: "User fetched successfully."
            );

            return Ok(successResult);
        }

        [HttpGet("unauthorized-test")]
        public IActionResult GetUnauthorizedData()
        {
            var result = Result<string>.ResultFailure(
                error: "ERR_ACCESS_DENIED",
                message: "You do not have permission to view this resource."
            );

            return Unauthorized(result); // 401 Unauthorized
        }

        [HttpPost("calculate-square")]
        public IActionResult CalculateSquare([FromQuery] int number)
        {
            if (number > 1000)
            {
                var fail = Result<int>.ResultFailure(
                    error: "NUMBER_TOO_LARGE",
                    message: "Number cannot exceed 1000."
                );
                return BadRequest(fail);
            }

            int square = number * number;
            var success = Result<int>.ResultSuccess(
                value: square,
                message: $"Square of {number} calculated successfully."
            );

            return Ok(success);
        }
    }
}
