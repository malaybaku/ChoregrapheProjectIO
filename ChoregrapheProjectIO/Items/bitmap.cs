using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    public class Bitmap
    {
        public const string ApplicationRootImageFile = "media/images/box/root.png";
        public const string TimelineBitmapImageFile = "media/images/box/movement/move.png";

        [XmlText]
        public string Filename { get; set; } = TimelineBitmapImageFile;
    }
}
