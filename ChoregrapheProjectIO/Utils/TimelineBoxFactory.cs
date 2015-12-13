using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Baku.Choregraphe
{
    static class TimelineBoxFactory
    {
        /// <summary>タイムライン設定に必要な要素を明示的に指定してタイムラインボックスを取得します。</summary>
        /// <param name="frameSize">モーションの合計フレーム数</param>
        /// <param name="aList">アクチュエータの動きをキーフレームとして定義した一覧</param>
        /// <returns>モーションを定義したタイムラインボックス
        /// </returns>
        public static Box CreateTimelineBox(int frameSize, ActuatorList aList)
        {
            var box = new Box(true);
            box.Bitmap.Filename = Bitmap.TimelineBitmapImageFile;

            box.Timeline.Enable = true;
            box.Timeline.Size = frameSize;
            box.Timeline.ActuatorList = aList;

            return box;
        }
    }
}
