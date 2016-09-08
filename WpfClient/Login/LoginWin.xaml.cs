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
using BCP.ViewModel;
using WpfClient.Contacts;
using BCP.WebAPI.SignalR;

namespace WpfClient.Login
{
    /// <summary>
    /// LoginWin.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWin : MyMacClass_noneMaxBtn
    {
        public static SignalRProxy SignalRProxy { get; set; }
        public static SignalRMessagePackage SignalR_MsgPackage { get; set; }

        public LoginWin()
        {
            InitializeComponent();
        }

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tb_account.Text.Trim() == "" || tb_password.Password.Trim() == "")
            {
                MessageBox.Show("账号或密码为空，请输入");
            }
            else
            {
                UserDTO user = new UserDTO();
                //SignalCore.UserInfo user = new SignalCore.UserInfo();
                user.UserName = tb_account.Text.Trim();
                user.Password = tb_password.Password.Trim();

                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/Login/Login?userName=" + user.UserName + "&userPwd=" + user.Password);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    if (ds.ToString() == "false")
                    {
                        MessageBox.Show("用户名或密码错误");
                    }
                    else
                    {
                        CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                        if (result.Success)
                        {
                            UserDTO currentUser = JsonConvert.DeserializeObject<UserDTO>(result.Data);
                            MainClient.CurrentUser = currentUser;  //返回当前用户
                            MainClient mainWin = new MainClient();
                            
                            MessageTab.MessageBox mb = new MessageTab.MessageBox();//消息页面

                            //登录服务器（聊天模块相关,160905新增）
                            SignalRProxy = new SignalRProxy();
                            SignalRProxy.ConnectAsync();
                            System.Threading.Thread.Sleep(10000);

                            SignalRProxy.Login(MainClient.CurrentUser.UserName, MainClient.CurrentUser.Password);

                            if (SignalRProxy.ReceviceMessage == null)
                            {

                                SignalRProxy.ReceviceMessage = (package) =>
                                {

                                    this.Dispatcher.Invoke(() =>
                                    {
                                      
                                        if (package.SMType == SignalRMessageType.StateMessage) { return; }


                                        if (package.SCType == SignalRCommunicationType.PersonToPerson)
                                        {
                                            if (Contacts.Contacts.PrivateDialogList.Count > 0)
                                            {
                                                foreach (var item in Contacts.Contacts.PrivateDialogList)
                                                {

                                                    if (MainClient.CurrentUser.ID.Equals(package.ToUserId) && package.FromUserId == item.ReplyId)
                                                    {
                                                        LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                        leftMessageBoxUControl.Init(item.To, package.Context.ToString());
                                                        item.MessageStackPanel.Children.Add(leftMessageBoxUControl);
                                                    }
                                                    else if (MainClient.CurrentUser.ID.Equals(package.FromUserId) && package.ToUserId == item.ReplyId)
                                                    {
                                                        RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                                                        rightMessageBoxUControl.Init(item.Self, package.Context.ToString(), null, "Text");
                                                        item.MessageStackPanel.Children.Add(rightMessageBoxUControl);
                                                    }

                                                }
                                            }
                                            else     //接收消息加载到消息页面
                                            {

                                                //加载到界面
                                                Image img = new Image();
                                                BitmapImage bitImg = new BitmapImage(new Uri("WpfClient;component/Images/Img_Header/unKnowHeaderImg.jpg", UriKind.Relative));
                                                img.Source = bitImg;
                                                ListViewItem lvi = new ListViewItem();

                                                ResourceDictionary mWindowResouce = new ResourceDictionary();
                                                mWindowResouce.Source = new Uri("WpfClient;component/Resource/ControlStyle.xaml", UriKind.Relative);
                                                this.Resources.MergedDictionaries.Add(mWindowResouce);
                                                lvi.Style = (Style)mWindowResouce["MessagePanelListViewItemStyle"];

                                                lvi.Name = "_"+package.FromUserId.ToString();
                                                lvi.Uid = "1";
                                                lvi.ToolTip = "10:02";
                                                lvi.Tag = package.Context;
                                                lvi.Content = img;

                                                mb.Lv_message.Items.Add(lvi);

                                            }
                                        }
                                        else if (package.SCType == SignalRCommunicationType.PersonToGroup)
                                        {
                                           
                                            if (Teams.organizationPanel.NormalGroupDialogList.Count > 0)
                                            {
                                                

                                                foreach (var item in Teams.organizationPanel.NormalGroupDialogList)
                                                {
                                                                                                        
                                                    if (MainClient.CurrentUser.ID.Equals(package.FromUserId) && package.ToUserId == item.CurrentGroup.Id)
                                                    {
                                                        RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                                                        rightMessageBoxUControl.Init(MainClient.CurrentUser.ActualName, package.Context.ToString(), null, "Text");
                                                        item.NoticeStackPanel.Children.Add(rightMessageBoxUControl);
                                                    }
                                                    else 
                                                    {
                                                        string actualName = item.groupMembers.Where(l => l.UserId == package.FromUserId).FirstOrDefault().Name;
                                                        LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                        leftMessageBoxUControl.Init(actualName, package.Context.ToString());
                                                        item.NoticeStackPanel.Children.Add(leftMessageBoxUControl);
                                                    }


                                                }
                                              

                                            }

                                        }


                                    }
                                    );



                                };
                            }

                        

                            mainWin.MsgPanel.Content=mb;//消息页面加到主窗体
                            //后台绑定
                           
                            this.Close();
                           
                            mainWin.ShowDialog();

                       
                        }
                        else
                        {
                            MessageBox.Show("用户名或密码错误");
                        }
                    }

                }

                //foreach (var currentUser in userList)
                //{
                //    if (currentUser.UserAccount == user.UserAccount)
                //    {
                //        if (currentUser.UserPwd== user.UserPwd)
                //        {
                //            MainClient.currentUser = currentUser;
                //            MainClient mainWin = new MainClient();
                //            this.Close();



                //            mainWin.ShowDialog();
                //        }
                //        else
                //        {
                //            MessageBox.Show("密码错误");
                //        }
                //        return;
                //    }

                //}

                //MessageBox.Show("该账户不存在");
            }



        }

        //private void MainWin_Loaded(object sender, RoutedEventArgs e)
        //{
        //    Binding MsgBinding = new Binding("ActualHeigh");
        //    MsgBinding.ElementName = "mainWin.MsgPanel";
        //    mb.SetBinding(MessageTab.MessageBox.HeightProperty, MsgBinding);
        //}


        /// <summary>
        /// 用户注册账号
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hpLink_registAccount_Click(object sender, RoutedEventArgs e)
        {
            RegistWin rgWin = new RegistWin();
            rgWin.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            rgWin.ShowDialog();
        }

        /// <summary>
        /// 找回密码 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void hpLink_findPassword_Click(object sender, RoutedEventArgs e)
        {
            UserManageWin umw = new UserManageWin();
            umw.ShowDialog();
        }
    }




}
