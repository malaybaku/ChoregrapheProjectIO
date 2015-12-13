using System.Collections.Generic;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    /// <summary>アクチュエータの動作をまとめて保持するコンテナを表します。</summary>
    public class ActuatorList 
    {
        [XmlAttribute(AttributeName = "model")]
        public string model { get; set; } = "pepper";

        [XmlElement(ElementName = "ActuatorCurve")]
        public List<ActuatorCurve> ActuatorCurves { get; set; } = new List<ActuatorCurve>();

    }
}
