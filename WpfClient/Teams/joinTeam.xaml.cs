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
    /// jioinTeam.xaml 的交互逻辑
    /// </summary>
    public partial class joinTeam : MyMacClass_noneMaxBtn
    {
        List<SignalCore.OrgInfo> list_org = new List<SignalCore.OrgInfo>();

        public joinTeam()
        {
            InitializeComponent();

            list_org = SignalCore.Data.InitOrganization();
            //listbox_org.Items.Clear();
            //listbox_org.ItemsSource = list_org;
            
        }

        private void btn_Search_Click(object sender, RoutedEventArgs e)
        {
            listbox_org.Items.Clear();
            foreach (var item in list_org)
            {
                if(item.OrgName.Contains(organizitionName.Text.Trim()))
                {
                    //MessageBox.Show("包含");
                    ListBoxItem lbi = new ListBoxItem();
                    lbi.Content = item.OrgName;
                    lbi.Tag = item;
                    listbox_org.Items.Add(lbi);
                }
            }
        }

    
    }
}
