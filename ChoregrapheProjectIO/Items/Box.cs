using System.Collections.Generic;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    /// <summary>ChoregrapheのBoxを表します。</summary>
    public class Box
    {
        /// <summary>デフォルトコンストラクタが無いとXmlSerializerに怒られるので作っておく</summary>
        public Box() : this(false) { }

        public Box(bool useBasicIO)
        {
            if(useBasicIO)
            {
                SetBasicIO();
            }
        }

        #region Attribute

        /// <summary>ボックス名</summary>
        [XmlAttribute(AttributeName = "name")]
        public string name { get; set; } = string.Empty;

        /// <summary>ボックスのID(rootの場合は-1)</summary>
        [XmlAttribute(AttributeName = "id")]
        public int id { get; set; } = 1;

        /// <summary>ロケール??手元のChoregrapheではすべて8だが、恐らく日本を指しているハズ</summary>
        [XmlAttribute(AttributeName = "localization")]
        public int localization { get; set; } = 8;

        /// <summary>ボックスの説明文</summary>
        [XmlAttribute(AttributeName = "tooltip")]
        public string tooltip { get; set; } = string.Empty;

        /// <summary>GUI上のボックス配置のX座標</summary>
        [XmlAttribute(AttributeName = "x")]
        public int x { get; set; }

        /// <summary>GUI上のボックス配置のY座標</summary>
        [XmlAttribute(AttributeName = "y")]
        public int y { get; set; }

        #endregion

        #region 子要素

        [XmlElement(ElementName = "bitmap")]
        public Bitmap Bitmap { get; set; } = new Bitmap();

        [XmlElement(ElementName = "script")]
        public Script Script { get; set; } = new Script();

        [XmlElement(ElementName = "Input")]
        public List<Input> Inputs { get; set; } = new List<Input>();

        [XmlElement(ElementName = "Output")]
        public List<Output> Outputs { get; set; } = new List<Output>();

        [XmlElement(ElementName = "Timeline")]
        public Timeline Timeline { get; set; } = new Timeline();

        #endregion

        /// <summary>ルート要素のボックスを生成します。</summary>
        /// <returns>ルート要素となるボックス</returns>
        public static Box CreateRootBox()
        {
            var box = new Box(true)
            {
                name = "root",
                id = -1,
                tooltip = @"Root box of Choregraphe's behavior. Highest level possible."
            };
            //localization, x, yは既定値で十分

            box.Bitmap.Filename = Bitmap.ApplicationRootImageFile;

            return box;
        }

        /// <summary>
        /// <para>ボックスの標準的なIOとして下記をセットする</para>
        /// <para>Input: onLoad, onStart, onStop</para>
        /// <para>Output: onStopped</para>
        /// </summary>
        public void SetBasicIO()
        {
            this.Inputs.Add(new Input()
            {
                Name = "onLoad",
                Type = 1,
                TypeSize = 1,
                Nature = 0,
                Inner = 1,
                Tooltip = "Signal sent when diagram is loaded.",
                Id = 1
            });
            this.Inputs.Add(new Input()
            {
                Name = "onStart",
                Type = 1,
                TypeSize = 1,
                Nature = 2,
                Inner = 0,
                Tooltip = "Box behavior starts when a signal is received on this input.",
                Id = 2
            });
            this.Inputs.Add(new Input()
            {
                Name = "onStop",
                Type = 1,
                TypeSize = 1,
                Nature = 3,
                Inner = 0,
                Tooltip = "Box behavior stops when a signal is received on this input.",
                Id = 3
            });
            this.Outputs.Add(new Output()
            {
                Name = "onStopped",
                Type = 1,
                TypeSize = 1,
                Nature = 1,
                Inner = 0,
                Tooltip = "Send signal when quitting behavior of the box",
                Id = 4
            });
        }

    }
}
