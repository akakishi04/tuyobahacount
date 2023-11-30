using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Diagnostics.PerformanceData;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
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
using System.Xml.Serialization;
using tuyobahacount.DataModel;
using tuyobahacount.UserControl;
using tuyobahacount.ViewModel;

namespace tuyobahacount
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private ProBahaHLView ProtBaha;
        private AkashaView Akasha;
        private Timer saveTimer;

        public MainWindow()
        {
            InitializeComponent();


            this.MouseLeftButtonDown += new MouseButtonEventHandler(MainWindow_MouseLeftButtonDown);
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);

            this.Topmost = Properties.Settings.Default.Top;

            ProtBaha = new ProBahaHLView();
            Akasha = new AkashaView();

            DataModelContainer container;

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

                container = InitializationDMC();
                // 他のプロパティも同様に初期化

                // 初回起動フラグを更新
                Properties.Settings.Default.IsFirstRun = false;
                Properties.Settings.Default.Save();
            }
            else
            {
               


                if (File.Exists("CounterData.xml"))
                {
                    container = IO.LoadDataModelFromXml("CounterData.xml");
                }
                else
                {

                    container = InitializationDMC();
                    Debug.WriteLine($"Init...");

                }

               
               

            }

            ProtBaha.ProtBaha = container.ProtBahaHL;
            Akasha.Akasha = container.Akasha;

            myProtBahaHLC.DataContext = ProtBaha;
            myAkashaC.DataContext = Akasha;

            Application.Current.Exit += Current_Exit;

            saveTimer = new Timer(60000); // 1分 = 60000ミリ秒
            saveTimer.Elapsed += OnTimedEvent;
            saveTimer.AutoReset = true;
            saveTimer.Enabled = true;

        }

        private void SaveData()
        {
            var container = new DataModelContainer();
            var pbv = myProtBahaHLC.DataContext as ProBahaHLView;
            var akv = myAkashaC.DataContext as AkashaView;
            container.ProtBahaHL = pbv.ProtBaha;
            container.Akasha = akv.Akasha;
            Debug.WriteLine($"Saving data: {container.ProtBahaHL.TotalCount}, {container.ProtBahaHL.None}, ...");
            IO.SaveData("CounterData.xml", container);

        }


        private void Current_Exit(object sender, ExitEventArgs e)
        {
            // 終了時の処理
            SaveSettings();

            //データの保存
            
           SaveData();

            saveTimer.Stop();
            saveTimer.Dispose();

        }

        private void OnTimedEvent(Object source, ElapsedEventArgs e)
        {
            // ここに保存処理を記述
            SaveData();
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
                if (customDialog.ShowDialog() == true)
                {
                    Application.Current.Shutdown();
                }
            }
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
            string versionString = $"{version.Major}.{version.Minor}.{version.Build}.{version.Revision}";
            Properties.Settings.Default.version = versionString;

            // 設定を保存
            Properties.Settings.Default.Save();
        }
       

        private DataModelContainer InitializationDMC()
        {

            DataModelContainer container = new DataModelContainer();
            container.ProtBahaHL.TotalCount = 0;
            container.ProtBahaHL.None = 0;
            container.ProtBahaHL.BlueBox = 0;
            container.ProtBahaHL.Intricacy_Ring = 0;
            container.ProtBahaHL.Coronation_Ring = 0;
            container.ProtBahaHL.Lineage_Ring = 0;
            container.ProtBahaHL.Gold_Brick = 0;

            container.Akasha.TotalCount = 0;
            container.Akasha.BlueBox = 0;
            container.Akasha.None = 0;
            container.Akasha.Hollow_Key = 0;
            container.Akasha.Champion_Merit = 0;
            container.Akasha.Supreme_Merit = 0;
            container.Akasha.Legendary_Merit = 0;
            container.Akasha.Silver_Centrum = 0;
            container.Akasha.Weapon_Plus_Mark1 = 0;
            container.Akasha.Weapon_Plus_Mark2 = 0;
            container.Akasha.Weapon_Plus_Mark3 = 0;
            container.Akasha.Coronation_Ring = 0;
            container.Akasha.Lineage_Ring=0;
            container.Akasha.Intricacy_Ring = 0;
            container.Akasha.Gold_Brick= 0;

            return container;

        }
        private void TakeScreenshot()
        {
            try
            {
                string folderPath = "screenshot";
                if (!Directory.Exists(folderPath))
                {
                    Directory.CreateDirectory(folderPath);
                }

                // 日付をファイル名に含める
                string fileName = DateTime.Now.ToString("yyMMdd") + ".png";
                string filePath = System.IO.Path.Combine(folderPath, fileName);

                // ウィンドウのサイズを取得

                // ウィンドウのサイズを取得
                var width = (int)this.ActualWidth;
                var height = (int)this.ActualHeight;

                // レンダリングするビットマップを作成
                var renderTargetBitmap = new RenderTargetBitmap(width, height, 96, 96, PixelFormats.Pbgra32);
                renderTargetBitmap.Render(this);

                // PNG形式で保存
                var pngImage = new PngBitmapEncoder();
                pngImage.Frames.Add(BitmapFrame.Create(renderTargetBitmap));

                // ファイルに保存
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    pngImage.Save(fileStream);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("スクリーンショットの取得に失敗しました: " + ex.Message);
            }
        }

        private void screenshot_Click(object sender, RoutedEventArgs e)
        {
            TakeScreenshot();
        }
    }
}
