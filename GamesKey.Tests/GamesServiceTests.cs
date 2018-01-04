using GamesKey.Services;
using GamesKey.ViewModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using Xunit;

namespace GamesKey.Tests
{
    public class GamesServiceTests
    {
        private GameViewModel _game01;
        private GameViewModel _game02;
        private GameViewModel _game03;
        private GameViewModel _game04;

        public GamesServiceTests()
        {
            _game01 = new GameViewModel
            {
                Title = "The Witcher 3: Wild Hunt",
                ShortDescription =
                    "The Witcher: Wild Hunt is a story-driven, next-generation open world role-playing game set in a visually stunning fantasy universe full of meaningful choices and impactful consequences." +
                    " In The Witcher you play as the professional monster hunter, Geralt of Rivia, tasked with finding a child of prophecy in a vast open world rich with merchant cities, " +
                    "viking pirate islands, dangerous mountain passes, and forgotten caverns to explore.",
                Description = "Insert incredibly long and convoluted description here.",
                Release = new DateTime(2015, 5, 18),
                Price = 29.99m,
                Developer = "CD PROJEKT RED",
                Publisher = "CD PROJEKT RED",
                Genres = new string[] { "RPG" },
                Tags = new string[] { "Open World", "RPG", "Story Rich", "Atmospheric" }
            };
            _game02 = new GameViewModel
            {
                Title = "Dota 2",
                ShortDescription = "Every day, millions of players worldwide enter battle as one of over a hundred Dota heroes. " +
                        "And no matter if it's their 10th hour of play or 1,000th, there's always something new to discover. " +
                        "With regular updates that ensure a constant evolution of gameplay, features, and heroes, Dota 2 has truly taken on a life of its own.",
                Description = "Insert description here.",
                Release = new DateTime(2013, 7, 9),
                Price = 0,
                Developer = "Valve",
                Publisher = "Valve",
                Genres = new string[] { "Action", "Free to Play", "Strategy" },
                Tags = new string[] { "Free to Play", "MOBA", "Strategy", "Multiplayer", "PvP" }
            };
            _game03 = new GameViewModel
            {
                Title = "The Witcher 2: Assassins of Kings",
                ShortDescription = "Enjoy a captivating story, dynamic combat system and beautiful graphics in the second installment in the RPG saga about the Witcher, Geralt of Rivia.",
                Description = "Whatever",
                Release = new DateTime(2011, 5, 17),
                Price = 19.99m,
                Developer = "CD PROJEKT RED",
                Publisher = "CD PROJEKT RED",
                Genres = new string[] { "RPG" },
                Tags = new string[] { "RPG", "Fantasy", "Mature", "Choices matter", "Nudity" }
            };
            _game04 = new GameViewModel
            {
                Title = "The Witcher 3: Wild Hunt",
                ShortDescription =
                    "The Witcher: Wild Hunt is a story-driven, next-generation open world role-playing game set in a visually stunning fantasy universe full of meaningful choices and impactful consequences." +
                    " In The Witcher you play as the professional monster hunter, Geralt of Rivia, tasked with finding a child of prophecy in a vast open world rich with merchant cities, " +
                    "viking pirate islands, dangerous mountain passes, and forgotten caverns to explore.",
                Description = "Insert incredibly long and convoluted description here.",
                Release = new DateTime(2015, 5, 18),
                Price = 29.99m
            };
        }

        [Fact]
        public async void FindMany()
        {
            var options = TestHelpers.GetDbOptions(nameof(FindMany));

            using (var context = new GamesKeyDbContext(options))
            {
                await new GamesService(context).CreateAsync(_game01);
            }

            using (var context = new GamesKeyDbContext(options))
            {
                await new GamesService(context).CreateAsync(_game02);
            }

            using (var context = new GamesKeyDbContext(options))
            {
                var actual = new GamesService(context).Find();

                Assert.Equal(_game01.Model, actual.First().Model);
                Assert.Equal(_game02.Model, actual.Last().Model);
            }
        }

        // TODO: Check if needed.
        //[Fact]
        //public async void FindManyRequired()
        //{
        //    var options = TestHelpers.GetDbOptions(nameof(FindManyRequired));

        //    using (var context = new GamesKeyDbContext(options))
        //    {
        //        await new GamesService(context).CreateAsync(_game01);
        //    }

        //    using (var context = new GamesKeyDbContext(options))
        //    {
        //        await new GamesService(context).CreateAsync(_game04);
        //    }

        //    using (var context = new GamesKeyDbContext(options))
        //    {
        //        var actual = new GamesService(context).Find();

        //        Assert.Equal(_game01, actual.First());
        //        Assert.Equal(_game02, actual.Last());
        //    }
        //}

        [Fact]
        public async void Find()
        {
            var options = TestHelpers.GetDbOptions(nameof(Find));

            using (var context = new GamesKeyDbContext(options))
            {
                await new GamesService(context).CreateAsync(_game01);
            }

            using (var context = new GamesKeyDbContext(options))
            {
                var actual = await new GamesService(context).FindAsync((await context.Games.FirstAsync()).Id);
                Assert.Equal(_game01, actual);
            }
        }

        [Fact]
        public async void FindRequired()
        {
            var options = TestHelpers.GetDbOptions(nameof(FindRequired));

            using (var context = new GamesKeyDbContext(options))
            {
                await new GamesService(context).CreateAsync(_game04);
            }

            using (var context = new GamesKeyDbContext(options))
            {
                Assert.Equal(_game04, await new GamesService(context).FindAsync((await context.Games.FirstAsync()).Id));
            }
        }

        [Fact]
        public async void Create()
        {
            var options = TestHelpers.GetDbOptions(nameof(Create));

            using (var context = new GamesKeyDbContext(options))
            {
                var exptected = await new GamesService(context).CreateAsync(_game01);

                Assert.Equal(exptected.Developer, (await context.Developers.SingleAsync()).Name);
                Assert.Equal(exptected.Publisher, (await context.Publishers.SingleAsync()).Name);
                Assert.Equal(exptected.Genres, context.Genres.Select(g => g.Name));
                Assert.Equal(exptected.Tags, context.Tags.Select(t => t.Name));
                Assert.Equal(exptected.Model, await context.Games.SingleAsync());
            }
        }

        [Fact]
        public async void CreateRequired()
        {
            var options = TestHelpers.GetDbOptions(nameof(CreateRequired));

            using (var context = new GamesKeyDbContext(options))
            {
                var exptected = await new GamesService(context).CreateAsync(_game04);

                Assert.Empty(context.Developers);
                Assert.Empty(context.Publishers);
                Assert.Empty(context.Genres);
                Assert.Empty(context.Tags);
                Assert.Equal(exptected.Model, await context.Games.SingleAsync());
            }
        }

        // TODO: Fix this, low prio though...
        //[Fact]
        //public async void CreateDuplicateModels()
        //{
        //    var options = TestHelpers.GetDbOptions(nameof(CreateDuplicateModels));

        //    GameViewModel expected;

        //    using (var context = new GamesKeyDbContext(options))
        //    {
        //        expected = await new GamesService(context).CreateAsync(_game01);
        //    }

        //    using (var context = new GamesKeyDbContext(options))
        //    {
        //        await new GamesService(context).CreateAsync(_game01);
        //    }

        //    var actual = new GamesKeyDbContext(options);

        //    Assert.Equal(expected.Developer, (await actual.Developers.SingleAsync()).Name);
        //    Assert.Equal(expected.Publisher, (await actual.Publishers.SingleAsync()).Name);
        //    Assert.Equal(expected.Genres, actual.Genres.Select(g => g.Name));
        //    Assert.Equal(expected.Tags, actual.Tags.Select(t => t.Name));
        //    Assert.Equal(expected.Model, await actual.Games.FirstAsync());
        //}

        [Fact]
        public async void CreateDuplicateReferences()
        {
            var options = TestHelpers.GetDbOptions(nameof(CreateDuplicateReferences));

            GameViewModel exptected1;
            GameViewModel exptected2;

            using (var context = new GamesKeyDbContext(options))
            {
                exptected1 = await new GamesService(context).CreateAsync(_game01);
            }

            using (var context = new GamesKeyDbContext(options))
            {
                exptected2 = await new GamesService(context).CreateAsync(_game03);
            }

            var actual = new GamesKeyDbContext(options);

            Assert.Equal(exptected1.Developer, (await actual.Developers.SingleAsync()).Name);
            Assert.Equal(exptected1.Publisher, (await actual.Publishers.SingleAsync()).Name);
            Assert.Equal(exptected1.Genres, actual.Genres.Select(g => g.Name));
            // TODO: test for correct tags as well.
            Assert.Equal(exptected1.Model, await actual.Games.FirstAsync());
            Assert.Equal(exptected2.Model, await actual.Games.LastAsync());
        }
    }
}
