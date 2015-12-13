using System.IO;
using System.Windows;
using Microsoft.Win32;

using Baku.Choregraphe;

namespace FileConverterSample
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        //ファイル選択ボタンを押した時のハンドラです。
        private void OnSelectFileInRequested(object sender, RoutedEventArgs e)
        {
            var dialog = new OpenFileDialog();
            dialog.Filter = "csv,tsv(*.csv;*.tsv)|*.csv;*.tsv";
            if (dialog.ShowDialog() == true)
            {
                TextBoxFileIn.Text = dialog.FileName;
            }
        }

        //実際にファイルがドロップされた時のハンドラです。
        private void FileInDrop(object sender, DragEventArgs e)
        {
            var dropFiles = e.Data.GetData(DataFormats.FileDrop) as string[];
            if (dropFiles == null) return;

            TextBoxFileIn.Text = dropFiles[0];
        }

        //ファイルドロップを許可するためのハンドラです。
        private void FileInDragOver(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop, true))
            {
                e.Effects = DragDropEffects.Copy;
            }
            else
            {
                e.Effects = DragDropEffects.None;
            }
            e.Handled = true;
        }

        //ファイル書き出しの要求に対するイベントハンドラです。
        private void OnSaveFileRequested(object sender, RoutedEventArgs e)
        {
            string fileIn = TextBoxFileIn.Text;
            if (!File.Exists(fileIn))
            {
                MessageBox.Show("Error: 入力ファイルが設定されていません。ファイルを先に指定してください。");
                return;
            }

            var dialog = new SaveFileDialog()
            {
                Filter = "Behavior File(*.xar)|*.xar",
                InitialDirectory = Path.GetDirectoryName(fileIn)
            };

            if (dialog.ShowDialog() != true)
            {
                return;
            }

            var loadSetting = GetActuatorListLoadSetting(fileIn);
            var actuatorList = ActuatorListLoader.Load(fileIn, loadSetting);

            var project = ProjectFactory.CreateProjectWithSingleTimeline(actuatorList);
            project.Save(dialog.FileName);
        }

        //入力ファイル名を参照してアクチュエータリストのロード設定を取得します。
        private ActuatorListLoadSetting GetActuatorListLoadSetting(string filename)
        {
            var loaderSetting = new ActuatorListLoadSetting();

            string extension = Path.GetExtension(filename);
            if (extension == ".csv")
            {
                loaderSetting.Delimiter = ',';
            }
            else if (extension == ".tsv")
            {
                loaderSetting.Delimiter = '\t';
            }
            else
            {
                loaderSetting.Delimiter = ',';
            }

            //区切り文字以外の設定も順に拾う
            int interval = 0;
            int.TryParse(TextBoxDataSkipWidth.Text, out interval);
            if (interval > 0)
            {
                loaderSetting.Interval = interval;
            }

            int framePerData = 0;
            int.TryParse(TextBoxFramePerData.Text, out framePerData);
            if (framePerData > 0)
            {
                loaderSetting.FramePerData = framePerData;
            }

            loaderSetting.UseLastData = CheckBoxUseLastLine.IsChecked.GetValueOrDefault();
            loaderSetting.UseRadianInputData = CheckBoxUseDataAsRadianBase.IsChecked.GetValueOrDefault();

            return loaderSetting;
        }
    }
}
