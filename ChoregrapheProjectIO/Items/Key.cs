
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    public class Key
    { 
        [XmlAttribute(AttributeName = "frame")]
        public int frame { get; set; }

        /// <summary>角度、ここは度数表記になることに注意！！</summary>
        [XmlAttribute(AttributeName = "value")]
        public float value { get; set; }
    }
}
