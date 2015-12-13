using System.Collections.Generic;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    /// <summary>あるアクチュエータ一つに注目した動作順序を表します。</summary>
    public class ActuatorCurve
    {
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; } = "value";

        [XmlAttribute(AttributeName = "actuator")]
        public string actuator { get; set; } = "HeadYaw";

        [XmlAttribute(AttributeName = "recordable")]
        public int recordable { get; set; } = 0;

        [XmlAttribute(AttributeName = "mute")]
        public int mute { get; set; } = 0;

        [XmlAttribute(AttributeName = "unit")]
        public int unit { get; set; } = 0;

        [XmlElement(ElementName = "Key")]
        public List<Key> Keys { get; set; } = new List<Key>();

    }
}
