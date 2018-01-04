using GamesKey.Data;

namespace GamesKey.ViewModels
{
    public class PictureViewModel : ViewModel<Picture>
    {
        public byte[] File { get => _model.File; set => _model.File = value; }

        public PictureViewModel(Picture picture = default(Picture)) : base(picture)
        {

        }
    }
}
