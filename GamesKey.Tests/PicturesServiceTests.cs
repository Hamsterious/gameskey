using GamesKey.Services;
using GamesKey.ViewModels;
using Microsoft.EntityFrameworkCore;
using System.IO;
using Xunit;

namespace GamesKey.Tests
{
    public class PicturesServiceTests
    {
        private PictureViewModel _picture01;

        public PicturesServiceTests()
        {
            _picture01 = new PictureViewModel { File = File.ReadAllBytes(Path.Combine(Directory.GetCurrentDirectory(), "Assets", "picture-12.jpg")) };
        }

        [Fact]
        public async void Find()
        {
            var options = TestHelpers.GetDbOptions(nameof(Find));

            using (var context = new GamesKeyDbContext(options))
            {
                await new PicturesService(context).CreateAsync(_picture01);
            }

            PictureViewModel actual;

            using (var context = new GamesKeyDbContext(options))
            {
                actual = await new PicturesService(context).FindAsync((await context.Pictures.FirstAsync()).Id);
            }

            Assert.Equal(_picture01.File, actual.File);
        }
    }
}
