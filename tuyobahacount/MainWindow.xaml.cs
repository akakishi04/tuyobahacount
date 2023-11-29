using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using tuyobahacount.ViewModel;

namespace tuyobahacount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

#if DEBUG
            // このコードはデバッグビルド時のみ実行されます
            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionString = $"Version {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            Debug.WriteLine(versionString);
            // ここにデバッグ専用のコードを書く
#endif

            this.MouseLeftButtonDown += new MouseButtonEventHandler(MainWindow_MouseLeftButtonDown);
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            this.Topmost = Properties.Settings.Default.Top;

            var ProtBaha = new ProBahaHLView();
            var ProtBahaHLC = new UserControl.ProtBahaHLC();

            if (this.Topmost)
            {
                toggleButton.Background = new SolidColorBrush(Colors.Blue);

            }
            else 
            { 

                toggleButton.Background = new SolidColorBrush(Colors.White);

            }

            if (Properties.Settings.Default.IsFirstRun)
            {
                // 初回起動時の処理
                // 例: データモデルの数値を初期化
               
                ProtBaha.ProtBaha.TotalCount = 0;
                ProtBaha.ProtBaha.None = 0;
                ProtBaha.ProtBaha.BlueBox = 0;
                ProtBaha.ProtBaha.Intricacy_Ring = 0;
                ProtBaha.ProtBaha.Coronation_Ring = 0;
                ProtBaha.ProtBaha.Lineage_Ring = 0;
                ProtBaha.ProtBaha.Gold_Brick = 0;
                // 他のプロパティも同様に初期化

                // 初回起動フラグを更新
                Properties.Settings.Default.IsFirstRun = false;
                Properties.Settings.Default.Save();
            }
            else
            {
                ProtBaha.ProtBaha.TotalCount = 0;
                ProtBaha.ProtBaha.None = 0;
                ProtBaha.ProtBaha.BlueBox = 0;
                ProtBaha.ProtBaha.Intricacy_Ring = 0;
                ProtBaha.ProtBaha.Coronation_Ring = 0;
                ProtBaha.ProtBaha.Lineage_Ring = 0;
                ProtBaha.ProtBaha.Gold_Brick = 0;
            }

            ProtBahaHLC.DataContext = ProtBaha;

            Application.Current.Exit += Current_Exit;

        }


        private void Current_Exit(object sender, ExitEventArgs e)
        {
            // 終了時の処理
            SaveSettings();
        }

        private void MainWindow_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            // ウィンドウをドラッグで移動
            this.DragMove();

        }
        private void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            // Esc キーが押されたかチェック
            if (e.Key == Key.Escape)
            {
                // 確認ダイアログを表示
                var customDialog = new ConfirmationDialog();
                customDialog.Owner = this; // 'this' は現在のウィンドウを指します
                
             

                // 「はい」が選択された場合、アプリケーションを終了
                if ( customDialog.ShowDialog()==true)
                {
                    Application.Current.Shutdown();
                }
            }
        }

        private void Nodrop(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var currentColor = (toggleButton.Background as SolidColorBrush)?.Color;

            // 背景色を切り替える
            if (currentColor == Colors.Blue)
            {
                toggleButton.Background = new SolidColorBrush(Colors.White);
                this.Topmost = false;
            }
            else
            {
                toggleButton.Background = new SolidColorBrush(Colors.Blue);
                this.Topmost = true;
            }
        }

        private void SaveSettings()
        {
            // 設定の変更
            Properties.Settings.Default.Top = this.Topmost;

            Version version = Assembly.GetExecutingAssembly().GetName().Version;
            string versionString = $"Version {version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            Properties.Settings.Default.version = versionString;

            // 設定を保存
            Properties.Settings.Default.Save();
        }
    }
}
