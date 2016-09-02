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
using System.Windows.Shapes;

namespace WpfClient.Contacts
{
    /// <summary>
    /// PictureBrower.xaml 的交互逻辑
    /// </summary>
    public partial class PictureBrower : MyMacClass
    {
        public BitmapImage PicSource { set; get; }

        public PictureBrower()
        {
            InitializeComponent();
        }

        private void MyMacClass_Loaded(object sender, RoutedEventArgs e)
        {
            imgContent.Source = PicSource;
        }
    }
}
