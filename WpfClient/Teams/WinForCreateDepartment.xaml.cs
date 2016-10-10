using BCP.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
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
    /// WinForCreateDepartment.xaml 的交互逻辑
    /// </summary>
    public partial class WinForCreateDepartment : MyMacClass_noneMaxBtn
    {
        public int OrgRootID { set; get; }
        /// <summary>
        /// 标识是否创建成功
        /// </summary>
        public bool IsSucess { set; get; }

        public WinForCreateDepartment()
        {
            InitializeComponent();
            IsSucess = false;
        }

        private async void btn_CreateDep_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = await client.GetAsync("api/Org/RegisterOrg?certificates=certificates&userId=" + MainClient.CurrentUser.ID + "&isRoot=false&markerString=markerString&notes=备注&orgaName=" + txt_DepName.Text + "&parentId="+OrgRootID+ "&type=部门&orgCode=20001");
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    MessageBox.Show("创建成功");
                    IsSucess = true;
                    this.Close();
                    //newContactId = SelectedUser.ID;
                }
            }
        }
    }
}
