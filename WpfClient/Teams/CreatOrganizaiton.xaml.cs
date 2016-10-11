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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfClient.Teams
{
    /// <summary>
    /// CreatOrganizaiton.xaml 的交互逻辑
    /// </summary>
    public partial class CreatOrganizaiton : MyMacClass
    {
        /// <summary>
        /// 组织ID，顶级的
        /// </summary>
        public int OrgRootID { set; get; }

        public CreatOrganizaiton()
        {
            InitializeComponent();
            establishmentDateDatePicker.SelectedDate = System.DateTime.Now;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            if (OrgRootID != null)
            {
                LoadDepartment();
            }
            // 不要在设计时加载数据。
            // if (!System.ComponentModel.DesignerProperties.GetIsInDesignMode(this))
            // {
            // 	//在此处加载数据并将结果指派给 CollectionViewSource。
            // 	System.Windows.Data.CollectionViewSource myCollectionViewSource = (System.Windows.Data.CollectionViewSource)this.Resources["Resource Key for CollectionViewSource"];
            // 	myCollectionViewSource.Source = your data
            // }
        }

        /// <summary>
        /// 创建组织
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btnCreateOrg_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/Org/RegisterOrg?certificates=certificates&userId=" + MainClient.CurrentUser.ID + "&isRoot=true&markerString=markerString&notes=备注&orgaName=" + orgaNameTextBox.Text + "&parentId=0&type=" + typeTextBox.Text + "&orgCode=" + organizationCodeTextBox.Text);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    MessageBox.Show("创建成功");
                    this.Close();
                    //newContactId = SelectedUser.ID;
                }
            }
        }

        /// <summary>
        /// 新建部门 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_CreateDepartment_Click(object sender, RoutedEventArgs e)
        {
            WinForCreateDepartment win4createDep = new WinForCreateDepartment();
            win4createDep.OrgRootID = this.OrgRootID;
            win4createDep.ShowDialog();

            //刷新
            if (win4createDep.IsSucess == true)
            {
                LoadDepartment();
            }
        }


        /// <summary>
        /// 加载部门信息
        /// </summary>
        async void LoadDepartment()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Org/GetOrgChildren?orgId=" + OrgRootID);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        lbox_Department.Items.Clear();
                        List<OrganizationDTO> depList = new List<OrganizationDTO>();
                        depList = JsonConvert.DeserializeObject<List<OrganizationDTO>>(result.Data);
                        foreach (var item in depList)
                        {
                            ListBoxItem lbi = new ListBoxItem();
                            lbi.Content = item.OrgaName;
                            lbi.Tag = item.Id;
                            lbox_Department.Items.Add(lbi);
                        }

                    }
                }
            }
            catch
            { MessageBox.Show("加载部门出错"); }
        }

        /// <summary>
        /// 改部门，目前暂时为移除部门
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_EditDepartment_Click(object sender, RoutedEventArgs e)
        {
            if (lbox_Department.SelectedItem == null)
            {
                MessageBox.Show("未选择要移除的部门");
                return;
            }

            var curDepInfo = lbox_Department.SelectedItem as ListBoxItem;
            if (MessageBox.Show("是否移除部门-"+curDepInfo.Content, "注意", MessageBoxButton.YesNo, MessageBoxImage.Warning) == MessageBoxResult.Yes)
            {                

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Org/RemoveOrg?orgId=" + curDepInfo.Tag + "&loginId=" + MainClient.CurrentUser.ID);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);//{"Success":false,"Message":"非叶子节点、根节点","Type":null,"Data":"null","IsGeneric":false}
                    if (result.Success)
                    {
                        //从界面移除
                        lbox_Department.Items.Remove(lbox_Department.SelectedItem);
                    }
                }
            }
        }
    }
}
