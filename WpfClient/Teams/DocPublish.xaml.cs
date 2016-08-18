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
    /// DocPublish.xaml 的交互逻辑
    /// </summary>
    public partial class DocPublish : MyMacClass_noneMaxBtn
    {
        public DocPublish()
        {
            InitializeComponent();
        }

        private void expan_Collapsed(object sender, RoutedEventArgs e)
        {
            Expander sen = sender as Expander;
            if (sen != null)
            {
                //if (sen.IsExpanded == true)
                //{
                //    this.Height = 334;
                //}
                //if(sen.IsExpanded==false)
                //{
                //    this.Height = 132;
                //}
            }
        }
    }
}
