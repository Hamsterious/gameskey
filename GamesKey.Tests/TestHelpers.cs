using Microsoft.EntityFrameworkCore;

namespace GamesKey.Tests
{
    public static class TestHelpers
    {
        public static DbContextOptions<GamesKeyDbContext> GetDbOptions(string dbName) => new DbContextOptionsBuilder<GamesKeyDbContext>().UseInMemoryDatabase(dbName).EnableSensitiveDataLogging().Options;
    }
}
