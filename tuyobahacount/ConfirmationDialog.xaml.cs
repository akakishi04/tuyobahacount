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
    /// ConfirmationDialog.xaml の相互作用ロジック
    /// </summary>
    public partial class ConfirmationDialog : Window
    {
        public ConfirmationDialog()
        {
            InitializeComponent();
        }
        private void YesButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = true;
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            this.DialogResult = false;
        }
    }
}
