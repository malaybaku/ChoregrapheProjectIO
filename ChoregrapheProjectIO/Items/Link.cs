using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    public class Link 
    {
        [XmlAttribute(AttributeName = "inputowner")]
        public int inputowner { get; set; }

        [XmlAttribute(AttributeName = "indexofinput")]
        public int indexofinput { get; set; }

        [XmlAttribute(AttributeName = "outputowner")]
        public int outputowner { get; set; }

        [XmlAttribute(AttributeName = "indexofoutput")]
        public int indexofoutput { get; set; }
    }
}
