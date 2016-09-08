using BCP.WebAPI.SignalR;
using Newtonsoft.Json;
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
using WpfClient.Login;

namespace WpfClient.MessageTab
{
    /// <summary>
    /// MessageBox.xaml 的交互逻辑
    /// </summary>
    public partial class MessageBox : UserControl
    {
        public MessageBox()
        {
            InitializeComponent();           
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {

            


            ConnectServer();

        }


        void ConnectServer()
        {
            try
            {
                SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTPTextPackage("", MainClient.CurrentUser.ID, 2);
                String json_srmp = JsonConvert.SerializeObject(srmp);
                LoginWin.SignalRProxy.InitPTP(json_srmp);
                              

            }
            catch (Exception ex)
            {
                System.Windows.Forms.MessageBox.Show("消息加载失败");
            }
        }

        
    }   
}
