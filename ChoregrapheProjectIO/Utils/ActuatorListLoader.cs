using System;
using System.IO;
using System.Linq;

namespace Baku.Choregraphe
{
    /// <summary>定められたフォーマットに文字区切り済ファイルの内容をActuatorListに変換する方法を定義します。</summary>
    public static class ActuatorListLoader
    {
        /// <summary>ファイルからActuatorListをロードします。</summary>
        /// <param name="filename">ファイル名</param>
        /// <param name="delimiter">ファイル内の数値を区切る文字(既定値:カンマ(','))</param>
        /// <param name="interval">データのFPSが高すぎる場合の間引き値。スキップ幅を表し、0以下の場合はスキップが無いことを示す。</param>
        /// <param name="framePerData">生成されたリストのキーフレーム1ステップあたりに対応するフレーム数(既定値:1)</param>
        /// <param name="forceToUseLastData">最終フレームを</param>
        /// <returns></returns>
        public static ActuatorList Load(string filename, ActuatorListLoadSetting setting)
        {
            if (!File.Exists(filename)) return new ActuatorList();

            //NOTE: ちょっとメモリが膨れるがどうせテキストだし適当にやろう適当に。
            string[] lines = File.ReadAllLines(filename);

            int keyFrameCount = 0;
            //1行目には関節名が入ってる想定なのでそこを抽出
            var actuatorCurves = lines[0]
                .Split(setting.Delimiter)
                .Select(aname => new ActuatorCurve() { actuator = aname })
                .ToArray();

            //指定した行番号の位置に書かれているキーフレームの値を読み込む
            Action<int> addKeyframes = i =>
            {
                var keyAngles = lines[i]
                    .Split(setting.Delimiter)
                    .Select(v => float.Parse(v))
                    .ToArray();

                for (int j = 0; j < actuatorCurves.Length; j++)
                {
                    actuatorCurves[j].Keys.Add(new Key()
                    {
                        frame = keyFrameCount * setting.FramePerData,
                        value = keyAngles[j] * (setting.UseRadianInputData ? (float)(180.0 / Math.PI) : 1.0f)
                    });
                }
            };

            //2行目からラストの手前まで一気に走査
            for (int i = 1; i < lines.Length - 1; i += setting.Interval)
            {
                keyFrameCount++;
                addKeyframes(i);
            }

            //設定に応じて終端の値を使う
            if (setting.UseLastData)
            {
                keyFrameCount++;
                addKeyframes(lines.Length - 1);
            }

            return new ActuatorList()
            {
                ActuatorCurves = actuatorCurves.ToList()
            };
        }
    }

    /// <summary>ActuatorListLoaderの設定を表します。</summary>
    public class ActuatorListLoadSetting
    {
        public static ActuatorListLoadSetting DefaultSetting
            => new ActuatorListLoadSetting();

        public char Delimiter { get; set; } = ',';

        public int Interval { get; set; } = 1;

        public int FramePerData { get; set; } = 1;

        /// <summary>
        /// 最終フレームに登録されたデータをinterval設定にかかわらず必ず保存するかを取得、設定します。
        /// モーションの最後が決めポーズである場合などはtrueにした方が無難です。
        /// </summary>
        public bool UseLastData { get; set; } = true;

        /// <summary>
        /// 入力データが弧度法で指定されているかどうかを指定します。
        /// Choregrapheでは度数法指定がデフォルトであるため既定値はfalseです。
        /// </summary>
        public bool UseRadianInputData { get; set; } = false;
    }


}
