using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    /// <summary>ビヘイビアキーフレーム(知らない)を表します。</summary>
    public class BehaviorKeyframe 
    {
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; } = "keyframe1";

        [XmlAttribute(AttributeName = "index")]
        public int index { get; set; } = 1;

        [XmlElement(ElementName = "Diagram")]
        public Diagram Diagram { get; set; } = new Diagram();

    }
}
