using Microsoft.Win32;
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

namespace WpfClient.Login
{
    /// <summary>
    /// RegistWin.xaml 的交互逻辑
    /// </summary>
    public partial class RegistWin : Window
    {
        public RegistWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 浏览插入头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            //op.InitialDirectory = lblSavePath.Text;//默认的打开路径
            //op.RestoreDirectory = true;
            op.Filter = " 图片文件(*.jpg、*.png)|*.jpg;*.jpeg;*.png|所有文件(*.*)|*.*";
            //txtLocalUrl.Text = op.FileName;

            try
            {
                if (op.ShowDialog() == true)
                {
                    Img_Header.Source = new BitmapImage(new Uri(op.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件格式不正确");
            }
        }
    }
}
