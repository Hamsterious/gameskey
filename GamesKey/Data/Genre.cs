using System.Collections.Generic;

namespace GamesKey.Data
{
    public class Genre : GameRelation
    {
        public virtual ICollection<GameGenre> GameGenres { get; set; }
    }
}
