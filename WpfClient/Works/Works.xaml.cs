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

namespace WpfClient.Works
{
    /// <summary>
    /// Works.xaml 的交互逻辑
    /// </summary>
    public partial class Works : UserControl
    {

        public Works()
        {
            InitializeComponent();

            LoadWorkItem();
        }


        private void mi_AddNoneDutyWork_Click(object sender, RoutedEventArgs e)
        {
            SysResource.AppStore appStore = new SysResource.AppStore();
            appStore.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            appStore.ShowDialog();
        }




        /// <summary>
        /// 树节点双击事件，打开对应系统
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void tv_mainWork_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            string header = (tv_mainWork.SelectedItem as PropertyNodeItem).Header.ToString();
            switch (header)
            {
                case "BIM公路建设管理系统":
                    var process = System.Diagnostics.Process.Start("iexplore.exe", " www.turingit.cn");
                    process.WaitForInputIdle();
                    break;
                case "征地管理系统":
                    Application1 app1 = new Application1();
                    app1.WindowStartupLocation = WindowStartupLocation.CenterScreen;
                    app1.ShowDialog();
                    break;
                default: break;

            }
        }

        /// <summary>
        /// 加载工作树
        /// </summary>
        void LoadWorkItem()
        {
            PropertyNodeItem JLnode = new PropertyNodeItem() { Header = "江罗高速分公司" };
            PropertyNodeItem JLnode1 = new PropertyNodeItem() { ImgSource = "/WpfClient;component/Images/广东交通集团.jpg", Header = "BIM公路建设管理系统" };
            PropertyNodeItem JLnode2 = new PropertyNodeItem() { ImgSource = "/WpfClient;component/Images/广东交通集团.jpg", Header = "征地管理系统" };
            PropertyNodeItem JLnode3 = new PropertyNodeItem() { ImgSource = "/WpfClient;component/Images/广东交通集团.jpg", Header = "公路应急管理系统" };
            PropertyNodeItem JLnode4 = new PropertyNodeItem() { ImgSource = "/WpfClient;component/Images/广东交通集团.jpg", Header = "机电设备管理系统" };
            PropertyNodeItem JLnode5 = new PropertyNodeItem() { ImgSource = "/WpfClient;component/Images/广东交通集团.jpg", Header = "视频监控管理系统" };

            JLnode.Children.Add(JLnode1);
            JLnode.Children.Add(JLnode2);
            JLnode.Children.Add(JLnode3);
            JLnode.Children.Add(JLnode4);
            JLnode.Children.Add(JLnode5);

            PropertyNodeItem TLnode = new PropertyNodeItem() { Header = "图之灵计算机技术有限公司" };
            PropertyNodeItem TLnode1 = new PropertyNodeItem() { ImgSource = "/WpfClient;component/Images/TR_Logo.jpg", Header = "客户管理系统" };
            PropertyNodeItem TLnode2 = new PropertyNodeItem() { ImgSource = "/WpfClient;component/Images/TR_Logo.jpg", Header = "软件开发管理系统" };

            TLnode.Children.Add(TLnode1);
            TLnode.Children.Add(TLnode2);

            PropertyNodeItem Localnode = new PropertyNodeItem() { Header = "本地单机系统" };
            PropertyNodeItem Localnode1 = new PropertyNodeItem() { Header = "日志" };
            PropertyNodeItem Localnode2 = new PropertyNodeItem() { Header = "计划任务" };

            Localnode.Children.Add(Localnode1);
            Localnode.Children.Add(Localnode2);

            tv_mainWork.Items.Add(JLnode);
            tv_mainWork.Items.Add(TLnode);
            tv_mainWork.Items.Add(Localnode);
        }
    }


    /// <summary>
    /// 树节点的类
    /// </summary>
    internal class PropertyNodeItem
    {
        public string ImgSource { get; set; }
        public string Header { get; set; }

        public List<PropertyNodeItem> Children { get; set; }

        public PropertyNodeItem()
        {
            Children = new List<PropertyNodeItem>();
        }
    }


}
