using System.Xml.Linq;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    public abstract class BoxIO 
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; } = string.Empty;

        [XmlAttribute(AttributeName = "type")]
        public int Type { get; set; } = 1;
        [XmlAttribute(AttributeName = "type_size")]
        public int TypeSize { get; set; } = 1;
        [XmlAttribute(AttributeName = "nature")]
        public int Nature { get; set; } = 1;
        [XmlAttribute(AttributeName = "inner")]
        public int Inner { get; set; } = 1;

        [XmlAttribute(AttributeName = "tooltip")]
        public string Tooltip { get; set; } = string.Empty;

        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; } = 1;
    }

    //NOTE: どっちも構造としては変わらないけど区別ついた方が都合いいのです

    public class Input : BoxIO { }

    public class Output : BoxIO { }

}
