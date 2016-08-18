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

namespace WpfClient.Contacts
{
    /// <summary>
    /// Contacts.xaml 的交互逻辑
    /// </summary>
    public partial class Contacts : UserControl
    {
        public Contacts()
        {
            InitializeComponent();

            LoadUserGroup();
        }
         

        private async void mi_AddGroup_Click(object sender, RoutedEventArgs e)
        {

            AddNewGroupWin ang_win = new AddNewGroupWin();
            ang_win.ShowDialog();
            if (ang_win.NewGroupName != "")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/User/AddCustomerGroup?userId=" + MainClient.CurrentUser.ID + "&groupName=" + ang_win.NewGroupName);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        //数据库添加成功
                        MessageBox.Show(result.Message);

                        //在界面添加
                        TreeViewItem tvi = new TreeViewItem();
                        tvi.Header = ang_win.NewGroupName;
                        Expander exp = new Expander() { Header= ang_win.NewGroupName };
                        tv_Contacts.Children.Add(exp);
                    }
                }
            }

     

        }


        /// <summary>
        /// 添加联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void mi_AddContact_Click(object sender, RoutedEventArgs e)
        {
            //获取当前用户分组
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/user/GetAllCustomerGroupWithoutUser?userId="+MainClient.CurrentUser.ID);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds =await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    List<CustomerGoupDTO> userGroups = JsonConvert.DeserializeObject<List<CustomerGoupDTO>>(result.Data);

         
                    AddNewContactWin anc_win = new AddNewContactWin();
                    anc_win.userGroupList = userGroups;
                    anc_win.ShowDialog();

                    //将人员加到界面的用户分组
                    foreach (Expander item in tv_Contacts.Children)
                    {
                        if (anc_win.GroupName == item.Header.ToString())
                        {
                            ListView listView;
                            if (item.Content != null)
                            {
                                listView = item.Content as ListView;
                            }
                            else
                            {
                                listView = new ListView();
                                item.Content = listView;
                            }
                            ListViewItem lvi = new ListViewItem();

                            //设置模板
                            ResourceDictionary mWindowResouce = new ResourceDictionary();
                            mWindowResouce.Source = new Uri("WpfClient;component/Resource/ControlStyle.xaml", UriKind.Relative);
                            this.Resources.MergedDictionaries.Add(mWindowResouce);
                            lvi.Style = (Style)mWindowResouce["ListViewItemStyle_ContractUser"];

                            lvi.Name = anc_win.userName;
                            BitmapImage image = new BitmapImage(new Uri("/WpfClient;component/Images/Img_Header/unKnowHeaderImg.jpg", UriKind.Relative));
                            Image img = new Image();
                            img.Source = image;
                            lvi.Content = img;
                            lvi.Tag = anc_win.newContactId;
                            lvi.MouseDoubleClick += TreeViewItem_MouseDoubleClick;

                            listView.Items.Add(lvi);

                        }

                    }
                }
            }

           
        }

        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
           

            PrivateDialog pd1 = new PrivateDialog();
            pd1.SignalRProxy = new SignalRProxy();
            pd1.SignalRProxy.ConnectAsync();
            pd1.To = (sender as ListViewItem).Name.ToString();
            pd1.Self = MainClient.CurrentUser.UserName;
            pd1.ReplyId = Convert.ToInt32((sender as ListViewItem).Tag.ToString());

            //PrivateDialog pd2 = new PrivateDialog();
            //pd2.SignalRProxy = new SignalRProxy();
            //pd2.SignalRProxy.ConnectAsync();
            //pd2.To = "hy";
            //pd2.Self = "cgf";
            //pd2.ReplyId = 1;

            pd1.Closed += (sen, er) =>
            {
                //pd1.SignalRProxy.Logout(MainClient.currentUser.UserName);
                pd1.SignalRProxy.Dispose();
            };
            //pd2.Closed += (sen, er) =>
            //{
            //    //pd2.SignalRProxy.Logout((sender as ListViewItem).Name.ToString());
            //    pd2.SignalRProxy.Dispose();
            //};

            pd1.Init();
            //pd2.Init();

            System.Threading.Thread.Sleep(1000);

            //string pwd1 = "";
            //string pwd2 = "";
            //foreach (SignalCore.UserInfo item in Login.LoginWin.userList)
            //{
            //    if (item.UserName == MainClient.currentUser.UserName)
            //    {
            //        pwd1 = item.UserPwd;
            //    }
            //    //if (item.UserName == (sender as ListViewItem).Name.ToString())
            //    //{
            //    //    pwd2 = item.UserPwd;
            //    //}
            //}

            //if (pd1.SignalRProxy.Login(MainClient.currentUser.UserName, pwd1))
            //{
            //    pd1.SignalRProxy.GetContactRecord(MainClient.currentUser.UserName, (sender as ListViewItem).Name.ToString());
            //    pd1.Show();
            //}
            //if (pd2.SignalRProxy.Login((sender as ListViewItem).Name.ToString(), pwd2))
            //{
            //    pd2.SignalRProxy.GetContactRecord((sender as ListViewItem).Name.ToString(), MainClient.currentUser.UserName);
            //    pd2.Show();
            //}

            pd1.SignalRProxy.Login(MainClient.CurrentUser.UserName,MainClient.CurrentUser.Password);
            
            pd1.Show();
            pd1.SignalRProxy.InitPTP(Convert.ToInt32((sender as ListViewItem).Tag.ToString()));


            //pd2.SignalRProxy.Login("cgf","cgf");
            //pd2.SignalRProxy.InitPTP(1);
            //pd2.Show();

        }

        /// <summary>
        /// 读取联系人分组，包含联系人
        /// </summary>
        async void LoadUserGroup()
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/User/GetAllCustomerGroupWithUser?userId=" + MainClient.CurrentUser.ID);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    List<CustomerGoupDTO> listUserGroup = JsonConvert.DeserializeObject<List<CustomerGoupDTO>>(result.Data);
                    foreach (var item in listUserGroup)
                    {
                        Expander exp = new Expander() {Header=item.GroupName,Background=new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ebf2f9")) };                      

                        ListView lv = new ListView();
                        lv.BorderThickness = new Thickness(0);
                        lv.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ebf2f9"));
                        exp.Content = lv;

                        List<UserDTO> userList = item.Members;
                        foreach (var user in userList)
                        {
                            ListViewItem lvi = new ListViewItem();
                            lvi.MouseDoubleClick += TreeViewItem_MouseDoubleClick;
                            //设置模板
                            ResourceDictionary mWindowResouce = new ResourceDictionary();
                            mWindowResouce.Source = new Uri("WpfClient;component/Resource/ControlStyle.xaml", UriKind.Relative);
                            this.Resources.MergedDictionaries.Add(mWindowResouce);
                            lvi.Style = (Style)mWindowResouce["ListViewItemStyle_ContractUser"];

                            //添加具体项
                            lvi.Name = user.ActualName;
                            lvi.Tag = user.ID;
                            lvi.ToolTip = "";
                            Image userHeader = new Image() { Source= new BitmapImage(new Uri("/WpfClient;component/Images/Img_Header/unKnowHeaderImg.jpg", UriKind.Relative)) };
                            lvi.Content = userHeader;

                            lv.Items.Add(lvi);
                        }

                        tv_Contacts.Children.Add(exp);
                    }
                }
            }
        }

        /// <summary>
        /// 删除联系人
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_DelContact_Click(object sender, RoutedEventArgs e)
        {
            DelContactWin dcw = new DelContactWin();
            dcw.ShowDialog();
            if (dcw.IsRefresh)
            {
                tv_Contacts.Children.Clear();
                LoadUserGroup();
            }
        }
    }
}
