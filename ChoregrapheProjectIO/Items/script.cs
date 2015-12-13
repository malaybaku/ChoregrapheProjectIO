using System.Xml.Linq;
using System.Xml.Serialization;

namespace Baku.Choregraphe
{
    public class Script
    {
        /// <summary>Choregrapheの仕様が分からないのだがこのLanguageは日本語の意味なのかPythonの意味なのか。</summary>
        [XmlAttribute(AttributeName = "language")]
        public int Language { get; set; } = 4;

        /// <summary>スクリプトある場合はその内容、無ければEmptyのままでOK</summary>
        [XmlElement(ElementName = "content")]
        public string Content { get; set; } = string.Empty;

        //NOTE??上の方法だと書き込みの際にCDATA使うことが強制出来ない。
        //まあ特段困るわけじゃないので無視かな？

    }

}
