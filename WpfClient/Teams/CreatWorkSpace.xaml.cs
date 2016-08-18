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

namespace WpfClient.Teams
{
    /// <summary>
    /// CreatWorkSpace.xaml 的交互逻辑
    /// </summary>
    public partial class CreatWorkSpace : MyMacClass
    {
        public CreatWorkSpace()
        {
            InitializeComponent();
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            // 不要在设计时加载数据。
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//在此处加载数据并将结果指派给 CollectionViewSource。
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        public String NewWorkSpaceName { get; set; }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            if (contentTextBox.Text.Trim() != "")
            {
                NewWorkSpaceName = contentTextBox.Text;
                this.Close();
            }
            else
            {
                MessageBox.Show("请输入工作空间名称");
            }
        }

        private void btn_AppStore_Click(object sender, RoutedEventArgs e)
        {
            SysResource.AppStore appStore = new SysResource.AppStore();
            appStore.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            appStore.ShowDialog();
        }
    }
}
