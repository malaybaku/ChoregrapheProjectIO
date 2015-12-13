using System.IO;
using System.Linq;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    [XmlRoot(
        ElementName = "ChoregrapheProject", 
        Namespace = "http://www.aldebaran-robotics.com/schema/choregraphe/project.xsd")]
    public class ChoregrapheProject
    {
        [XmlIgnore]
        public static XNamespace Namespace { get; } = "http://www.aldebaran-robotics.com/schema/choregraphe/project.xsd";

        /// <summary>
        /// xarファイルの形式バージョンらしいが現状で3以外の数値を確認した試しがない
        /// </summary>
        [XmlAttribute(AttributeName = "xar_version")]
        public int XarVersion { get; set; } = 3;

        /// <summary>実質のルート要素となるボックス</summary>
        [XmlElement(ElementName="Box")]
        public Box Box { get; set; } = Box.CreateRootBox();

        /// <summary>GUIから触れる最上位レイヤーのダイアグラムを取得</summary>
        [XmlIgnore]
        public Diagram RootDiagram => Box.Timeline.BehaviorLayer.BehaviorKeyframe.Diagram;

        /// <summary>指定したファイルにプロジェクトを保存します。</summary>
        /// <param name="file">保存先ファイル名(同名のファイルがある場合上書き)</param>
        public void Save(string file)
        {
            using (var sw = new StreamWriter(file))
            {
                new XmlSerializer(typeof(ChoregrapheProject))
                    .Serialize(sw, this);
            }
        }
    }


}
