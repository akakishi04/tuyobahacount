using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
            this.MouseLeftButtonDown += new MouseButtonEventHandler(MainWindow_MouseLeftButtonDown);
            this.KeyDown += new KeyEventHandler(MainWindow_KeyDown);
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
    }
}
