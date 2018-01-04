using System.Collections.Generic;

namespace GamesKey.Data
{
    public class Tag : GameRelation
    {
        public virtual ICollection<GameTag> GameTags { get; set; }
    }
}
