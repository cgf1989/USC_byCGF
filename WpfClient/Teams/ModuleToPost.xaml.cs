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

namespace WpfClient.Teams
{
    /// <summary>
    /// ModuleToPost.xaml 的交互逻辑
    /// </summary>
    public partial class ModuleToPost : MyMacClass
    {
        public ModuleToPost()
        {
            InitializeComponent();
        }



        private void rbtn_geren_Click(object sender, RoutedEventArgs e)
        {
            gb_geren.IsEnabled = true;
            gb_gangwei.IsEnabled = false;
        }

        private void rbtn_gangwei_Click(object sender, RoutedEventArgs e)
        {
            gb_gangwei.IsEnabled = true;
            gb_geren.IsEnabled = false;
        }
    }
}
