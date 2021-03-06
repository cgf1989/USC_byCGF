﻿using BCP.ViewModel;
using BCP.WebAPI.SignalR;
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
using WpfClient.Login;

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
            PrivateDialogList = new List<PrivateDialog>();

            LoadUserGroup();
            LoadGroupWihtoutUsers(); //分组改动时要重新加载，如添加分组，删除分组时


           MessageTab.MessageBox.IsMsgWinOpen = false; //设置未读信息窗口打开判断为否，以便聊天框打开之后点击未读消息页面，消息重复出在聊天框里

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
                        //TreeViewItem tvi = new TreeViewItem();
                        //tvi.Header = ang_win.NewGroupName;
                        //Expander exp = new Expander() { Header = ang_win.NewGroupName };
                        //tv_Contacts.Children.Add(exp);

                        //刷新界面
                        tv_Contacts.Children.Clear();
                        LoadUserGroup();
                        LoadGroupWihtoutUsers();

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

            HttpResponseMessage response = await client.GetAsync("api/user/GetAllCustomerGroupWithoutUser?userId=" + MainClient.CurrentUser.ID);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    List<CustomGroupDTO> userGroups = JsonConvert.DeserializeObject<List<CustomGroupDTO>>(result.Data);


                    AddNewContactWin anc_win = new AddNewContactWin();
                    anc_win.userGroupList = userGroups;
                    anc_win.ShowDialog();//这里最好做个判断，如果没有插入数据库成功，则提示添加失败，不走下面流程。

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
                                listView.BorderThickness = new Thickness(0);
                                listView.Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ebf2f9"));
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


        public static List<PrivateDialog> PrivateDialogList { get; set;}
        /// <summary>
        ///  点开聊天框（点对点）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void TreeViewItem_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            try
            {

                //检查窗口是否已经打开
                foreach (var item in PrivateDialogList)
                {
                    if (item.ReplyId == Convert.ToInt32((sender as ListViewItem).Tag.ToString()))
                        return;
                }

                PrivateDialog pd1 = new PrivateDialog();
                PrivateDialogList.Add(pd1);
                pd1.To = (sender as ListViewItem).Name.ToString();
                pd1.Self = MainClient.CurrentUser.ActualName;
                pd1.ReplyId = Convert.ToInt32((sender as ListViewItem).Tag.ToString());


                pd1.Closed += (sen, er) =>
                {
                    //LoginWin.SignalRProxy.Dispose();
                    PrivateDialogList.Remove(pd1);
                };

                pd1.Init();
                System.Threading.Thread.Sleep(1000);

                pd1.Show();


                SignalRMessagePackage srmp =SignalRMessagePackageFactory.GetPTPTextPackage("", MainClient.CurrentUser.ID, pd1.ReplyId, System.DateTime.Now);
                String json_srmp = JsonConvert.SerializeObject(srmp);
                LoginWin.SignalRProxy.InitPTP(json_srmp);//InitPTP里面已经有获取数据，不过只获取未读数据
                //pd1.SignalRProxy.GetAllMessage(json_srmp, System.DateTime.Now);//该方法获取所有数据不论有读未读，不过要指定日期
                //所以上面2个不用一起用。

                LoginWin.SignalRProxy.MarkMessage(json_srmp);//标记已读
            }
            catch (Exception ex)
            { MessageBox.Show("点对点聊天框打开出错\n"+ex.ToString()); }
     

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
                    List<CustomGroupDTO> listUserGroup = JsonConvert.DeserializeObject<List<CustomGroupDTO>>(result.Data);
                    foreach (var item in listUserGroup)
                    {
                        Expander exp = new Expander() { Header = item.GroupName, Background = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#ebf2f9")) };

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
                            Image userHeader = new Image() { Source = new BitmapImage(new Uri("/WpfClient;component/Images/Img_Header/unKnowHeaderImg.jpg", UriKind.Relative)) };
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

        /// <summary>
        /// 不包含用户内容的用户组list
        /// </summary>
        List<CustomGroupDTO> listUserGroupWithoutUser = new List<CustomGroupDTO>();
        /// <summary>
        /// 获取分组，不包含用户内容
        /// </summary>
        async void LoadGroupWihtoutUsers()
        {
            //GetAllCustomerGroupWithoutUser
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/User/GetAllCustomerGroupWithoutUser?userId=" + MainClient.CurrentUser.ID);
            response.EnsureSuccessStatusCode();
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    listUserGroupWithoutUser = JsonConvert.DeserializeObject<List<CustomGroupDTO>>(result.Data);
                }
            }
        }

        /// <summary>
        /// 删除联系人分组
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void mi_DelGroup_Click(object sender, RoutedEventArgs e)
        {

            RemoveGroupWin rgw = new RemoveGroupWin();
            rgw.GroupWitoutUserList = listUserGroupWithoutUser;
            rgw.ShowDialog();
            if (rgw.IsRefresh)
            {
                //刷新分组（不含用户）
                LoadGroupWihtoutUsers();
                //刷新分组并更新界面
                tv_Contacts.Children.Clear();
                LoadUserGroup();
            }
        }
    }
}
