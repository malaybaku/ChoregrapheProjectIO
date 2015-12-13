using System;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    /// <summary>Choregrapheのタイムラインを表します。</summary>
    public class Timeline 
    {
        [XmlIgnore]
        public bool Enable { get; set; }

        [XmlAttribute(AttributeName = "enable")]
        public int EnableAsSerializeValue
        {
            get { return Enable ? 1 : 0; }
            set { Enable = (value != 0); }
        }

        [XmlAttribute(AttributeName = "fps")]
        public int Fps { get; set; } = 25;

        [XmlAttribute(AttributeName = "start_time")]
        public int StartTime { get; set; } = 1;

        [XmlAttribute(AttributeName = "end_frame")]
        public int EndFrame { get; set; } = -1;

        [XmlAttribute(AttributeName = "size")]
        public int Size { get; set; } = 1;

        /// <summary>NOTE: レイヤーは見た感じ複数個作れそうにも見える。</summary>
        [XmlElement(ElementName = "BehaviorLayer")]
        public BehaviorLayer BehaviorLayer { get; set; } = new BehaviorLayer();

        /// <summary>モーターの制御数値の列挙。使わない場合はnullで放置すればOK</summary>
        [XmlElement(ElementName = "ActuatorList")]
        public ActuatorList ActuatorList { get; set; }

    }
}
