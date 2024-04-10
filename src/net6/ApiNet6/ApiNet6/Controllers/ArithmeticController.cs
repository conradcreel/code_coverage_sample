using ApiNet6.Domain.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiNet6.Controllers
{
    public class ArithmeticController : ControllerBase
    {
        private readonly IArithmeticService _arithmeticService;

        public ArithmeticController(IArithmeticService arithmeticService)
        {
            _arithmeticService = arithmeticService ?? throw new ArgumentNullException(nameof(arithmeticService));
        }

        [HttpGet("add")]
        public async Task<IActionResult> Add([FromQuery] double firstTerm, [FromQuery] double secondTerm)
        {
            return Ok(
                new
                {
                    firstTerm,
                    secondTerm,
                    sum = await _arithmeticService.Add(firstTerm, secondTerm)
                }
            );
        }
    }
}
