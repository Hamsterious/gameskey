using GamesKey.Services;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace GamesKey.Controllers
{
    [Route("api/[controller]")]
    public class PicturesController : Controller
    {
        private readonly string _contentType = "image/jpeg";
        private readonly IPicturesService _service;

        public PicturesController(IPicturesService service)
        {
            _service = service;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAsync(int id)
        {
            var viewModel = await _service.FindAsync(id);
            return base.File(viewModel.File, _contentType);
        }
    }
}
