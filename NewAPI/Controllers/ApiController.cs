using Microsoft.AspNetCore.Mvc;
using NewAPI.Services;

namespace NewAPI.Controllers
{
    [Route("api/[controller]")]
    public class ApiController : ControllerBase
    {
        private readonly ApiService _apiService;

        public ApiController(ApiService apiService)
        {
            _apiService = apiService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _apiService.GetDataFromApi("/facts");  //TODO aggiungere percorso alla risorsa
            return Ok(data);
        }
    }
}
