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
using System.IO;
using BCP.Common.Helper;

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

                                        if (package.SMType == SignalRMessageType.StateMessage || package.SMType == SignalRMessageType.File) { return; }  //文件的显示没做好，暂时忽略

                                        if (package.SMType == SignalRMessageType.Img)
                                        {
                                            if (package.SCType == SignalRCommunicationType.PersonToGroup)
                                            {
                                                if (Teams.organizationPanel.NormalGroupDialogList.Count > 0)
                                                {

                                                    foreach (var item in Teams.organizationPanel.NormalGroupDialogList)
                                                    {
                                                        //Uri server = new Uri(String.Format("{0}?filename={1}", api, ServerFileName));
                                                        HttpClient httpClient = new HttpClient();
                                                        string picName = FileHelper.Encrept_byCgf(package.Title);
                                                        string p = System.IO.Path.GetDirectoryName(@"D:\"+picName);

                                                        if (!Directory.Exists(p))
                                                            Directory.CreateDirectory(p);
                                                        string pathPic = package.Context.ToString();
                                                        HttpResponseMessage responseMessage = httpClient.GetAsync("http://localhost:37768/api/User/DownloadFile?fileName=" + pathPic).Result;

                                                        if (responseMessage.IsSuccessStatusCode)
                                                        {
                                                            using (FileStream fs = File.Create(@"D:\" + picName))
                                                            {
                                                                Stream streamFromService = responseMessage.Content.ReadAsStreamAsync().Result;
                                                                streamFromService.CopyTo(fs);
                                                            }

                                                            byte[] b = File.ReadAllBytes(@"D:\" + picName);

                                                            BitmapImage myBitmapImage = new BitmapImage();
                                                            myBitmapImage.BeginInit();
                                                            myBitmapImage.StreamSource = new MemoryStream(b);
                                                            myBitmapImage.EndInit();

                                                            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                                                            img.Source = myBitmapImage;
                                                            if (img != null)
                                                            {
                                                                if (MainClient.CurrentUser.ID.Equals(package.FromUserId) && package.ToUserId == item.CurrentGroup.Id)
                                                                {
                                                                    RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                                                                    rightMessageBoxUControl.Init(MainClient.CurrentUser.ActualName, "", img, "Image");
                                                                    item.NoticeStackPanel.Children.Add(rightMessageBoxUControl);
                                                                }
                                                                else
                                                                {
                                                                    string actualName = item.groupMembers.Where(l => l.UserId == package.FromUserId).FirstOrDefault().Name;
                                                                    LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                                    leftMessageBoxUControl.Init(actualName, "",img,"Image");
                                                                    item.NoticeStackPanel.Children.Add(leftMessageBoxUControl);
                                                                }
                                                            }

                                                        }
                                                    }

                                                }
                                            }
                                        }
                                        else if (package.SMType == SignalRMessageType.Text)
                                        {
                                            #region 点对点接收文本信息
                                            if (package.SCType == SignalRCommunicationType.PersonToPerson)
                                            {
                                                if (Contacts.Contacts.PrivateDialogList.Count > 0)
                                                {
                                                    foreach (var item in Contacts.Contacts.PrivateDialogList)
                                                    {

                                                        if (MainClient.CurrentUser.ID.Equals(package.ToUserId) && package.FromUserId == item.ReplyId)
                                                        {
                                                            LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                            leftMessageBoxUControl.Init(item.To, package.Context.ToString(),null,"Text");
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


                                                    UserDTO userInfo = MainClient.SysUserCollection.Where(l => l.ID == package.FromUserId).FirstOrDefault();
                                                    lvi.Name = "_" + userInfo.ActualName; // 纯数字会出错所以加了下划线开头
                                                    lvi.Uid = "1";
                                                    lvi.ToolTip = "10:02";
                                                    lvi.Tag = package.Context;
                                                    lvi.Content = img;

                                                    mb.Lv_message.Items.Add(lvi);

                                                }
                                            }
                                            #endregion
                                            #region 点对群接收文本
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
                                                            leftMessageBoxUControl.Init(actualName, package.Context.ToString(),null,"Text");
                                                            item.NoticeStackPanel.Children.Add(leftMessageBoxUControl);
                                                        }


                                                    }


                                                }

                                            }
                                            #endregion

                                        }
                                    }
                                    );



                                };
                            }



                            mainWin.MsgPanel.Content = mb;//消息页面加到主窗体
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
