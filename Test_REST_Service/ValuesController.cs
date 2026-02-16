using Infrastructure.Context;
using Microsoft.AspNetCore.Mvc;

namespace Test_REST_Service {
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase {
        private readonly IConnection _connection;

        public ValuesController(IConnection connection) {
            _connection = connection;
        }

        [HttpGet("test")]
        public IActionResult Test() {
            try {
                using var db = _connection.GetConnection();
                return Ok("DB connected successfully!");
            } catch (Exception ex) {
                return StatusCode(500, ex.Message);
            }
        }
    }
}
