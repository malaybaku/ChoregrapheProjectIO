using System.Collections.Generic;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    /// <summary>ダイアグラムを表します。</summary>
    public class Diagram 
    {
        [XmlElement(ElementName = "Box")]
        public List<Box> Boxes { get; set; } = new List<Box>();

        [XmlElement(ElementName = "Link")]
        public List<Link> Links { get; set; } = new List<Link>();
    }
}
