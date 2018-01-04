using GamesKey.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace GamesKey.ViewModels
{
    public class GameViewModel : ViewModel<Game>, IEquatable<GameViewModel>
    {
        [Required]
        public string Title { get => _model.Title; set => _model.Title = value; }
        [Required, StringLength(200, MinimumLength = 30)]
        public string ShortDescription { get => _model.ShortDescription; set => _model.ShortDescription = value; }
        [Required]
        public string Description { get => _model.Description; set => _model.Description = value; }
        [Required]
        public DateTime Release { get => _model.Release; set => _model.Release = value; }
        [Required]
        public decimal Price { get => _model.Price; set => _model.Price = value; }
        public int? PictureId { get => _model.PictureId; set => _model.PictureId = value; }

        public string Developer { get; set; }
        public string Publisher { get; set; }

        public string[] Genres { get; set; }
        public string[] Tags { get; set; }

        public GameViewModel(Game game = default(Game)) : base(game)
        {
            Genres = new string[0];
            Tags = new string[0];
        }

        public override bool Equals(object obj) => Equals(obj as GameViewModel);
        public bool Equals(GameViewModel other) =>
            other != null &&
            base.Equals(other) &&
            Title == other.Title &&
            ShortDescription == other.ShortDescription &&
            Description == other.Description &&
            Release == other.Release &&
            Price == other.Price &&
            EqualityComparer<int?>.Default.Equals(PictureId, other.PictureId) &&
            Developer == other.Developer &&
            Publisher == other.Publisher &&
            Enumerable.SequenceEqual(Genres, other.Genres) &&
            Enumerable.SequenceEqual(Tags, other.Tags);// &&
            //EqualityComparer<string[]>.Default.Equals(Genres, other.Genres) && 
            //EqualityComparer<string[]>.Default.Equals(Tags, other.Tags);

        public override int GetHashCode()
        {
            var hashCode = 1084869780;
            hashCode = hashCode * -1521134295 + base.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Title);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ShortDescription);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Description);
            hashCode = hashCode * -1521134295 + Release.GetHashCode();
            hashCode = hashCode * -1521134295 + Price.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<int?>.Default.GetHashCode(PictureId);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Developer);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Publisher);
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(Genres);
            hashCode = hashCode * -1521134295 + EqualityComparer<string[]>.Default.GetHashCode(Tags);
            return hashCode;
        }

        public static bool operator ==(GameViewModel model1, GameViewModel model2) => EqualityComparer<GameViewModel>.Default.Equals(model1, model2);
        public static bool operator !=(GameViewModel model1, GameViewModel model2) => !(model1 == model2);
    }
}
