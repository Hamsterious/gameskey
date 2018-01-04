using GamesKey.Data;
using GamesKey.Services;
using GamesKey.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace GamesKey.Controllers
{
    [Route("api/[controller]")]
    public class GamesController : Controller
    {
        private readonly IGamesService _service;

        public GamesController(IGamesService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(_service.Find());
        }

        [HttpGet("{gameId}")]
        public async Task<IActionResult> GetAsync(int gameId)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            return Ok(await _service.FindAsync(gameId));
        }

        [HttpPost]
        public async Task<IActionResult> PostAsync(IFormCollection collection)
        {
            if (collection.Keys.Count <= 0 && collection.Files.Count >= 1) return Ok();
            var viewModel = JsonConvert.DeserializeObject<GameViewModel>(collection["viewModel"]);
            var picture = collection.Files.GetFile("picture");

            TryValidateModel(viewModel);
            if (!ModelState.IsValid) return BadRequest(ModelState);

            if (picture.Length > 0)
            {
                using (var stream = new MemoryStream())
                {
                    await picture.CopyToAsync(stream);
                    viewModel.Model.Picture = new Picture { File = stream.ToArray() };
                }
            }

            return Ok(await _service.CreateAsync(viewModel));
        }
    }
}
