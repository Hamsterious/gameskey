using System;
using System.Collections.Generic;

namespace GamesKey.Data
{
    public class Game : Record<int>, IEquatable<Game>
    {
        public string Title { get; set; }
        public string ShortDescription { get; set; }
        public string Description { get; set; }

        public DateTime Release { get; set; }

        // TODO: Add system requirements properties

        public decimal Price { get; set; }

        public int? DeveloperId { get; set; }
        public virtual Developer Developer { get; set; }
        public int? PublisherId { get; set; }
        public virtual Publisher Publisher { get; set; }
        public int? PictureId { get; set; }
        public virtual Picture Picture { get; set; }

        public virtual ICollection<GameGenre> GameGenres { get; set; }
        public virtual ICollection<GameTag> GameTags { get; set; }

        public Game()
        {
            GameGenres = new List<GameGenre>();
            GameTags = new List<GameTag>();
        }

        public override bool Equals(object obj) => Equals(obj as Game);
        public bool Equals(Game other) => 
            other != null && 
            base.Equals(other) && 
            Title == other.Title && 
            ShortDescription == other.ShortDescription &&
            Description == other.Description &&
            Release == other.Release && 
            Price == other.Price && 
            EqualityComparer<int?>.Default.Equals(DeveloperId, other.DeveloperId) &&
            EqualityComparer<int?>.Default.Equals(PublisherId, other.PublisherId);

        public override int GetHashCode()
        {
            var hashCode = 1748564805;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShortDescription);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Release.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(DeveloperId);
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(PublisherId);
            return hashCode;
        }

        public static bool operator ==(Game game1, Game game2) => EqualityComparer<Game>.Default.Equals(game1, game2);
        public static bool operator !=(Game game1, Game game2) => !(game1 == game2);
    }

    public class GameGenre
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int GenreId { get; set; }
        public virtual Genre Genre { get; set; }
    }

    public class GameTag
    {
        public int GameId { get; set; }
        public virtual Game Game { get; set; }
        public int TagId { get; set; }
        public virtual Tag Tag { get; set; }
    }
}
