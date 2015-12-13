using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    /// <summary>Choregrapheのビヘイビアレイヤー(知らない)を表します。</summary>
    public class BehaviorLayer 
    {
        public const string DefaultBehaviorLayerName = "behavior_layer1";

        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; } = DefaultBehaviorLayerName;

        [XmlElement(ElementName = "BehaviorKeyframe")]
        public BehaviorKeyframe BehaviorKeyframe { get; set; } = new BehaviorKeyframe();

    }
}
