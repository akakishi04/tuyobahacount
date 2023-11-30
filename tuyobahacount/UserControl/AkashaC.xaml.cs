﻿using System;
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
using tuyobahacount.ViewModel;

namespace tuyobahacount.UserControl
{
    /// <summary>
    /// AkashaC.xaml の相互作用ロジック
    /// </summary>
    public partial class AkashaC : System.Windows.Controls.UserControl
    {
        public AkashaC()
        {
            InitializeComponent();
            var viewModel = new AkashaView();
            // UserControlのDataContextに設定
            this.DataContext = viewModel;
        }

       
    }
}