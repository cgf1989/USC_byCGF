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
    /// AddNewContactWin.xaml 的交互逻辑
    /// </summary>
    public partial class CreateNormalGroup : MyMacClass_noneMaxBtn
    {
        public string NewGroupName { set; get; }

        public CreateNormalGroup()
        {
            InitializeComponent();
            NewGroupName = tb_GroupName.Text.Trim();
        }

        private void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (tb_GroupName.Text.Trim() != "")
            {
                NewGroupName = tb_GroupName.Text.Trim();
                this.Close();
            }
            else
            {
                MessageBox.Show("分组名不能为空");
            }
        }
    }
}
