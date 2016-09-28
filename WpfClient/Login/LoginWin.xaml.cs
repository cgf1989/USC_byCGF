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

        /// <summary>
        /// 存放不同用户信息的字典
        /// </summary>
        public static Dictionary<int, ListViewItem> userMsgBoxs = new Dictionary<int, ListViewItem>();
        /// <summary>
        /// 存放某一用户的信息数量
        /// </summary>
        public static Dictionary<int, int> userMsgCount = new Dictionary<int, int>();

        /// <summary>
        /// 存放不同群的消息字典
        /// </summary>
        public static Dictionary<int, ListViewItem> groupMsgBoxs = new Dictionary<int, ListViewItem>();
        /// <summary>
        /// 存放某一群的信息数量
        /// </summary>
        public static Dictionary<int, int> groupMsgCount = new Dictionary<int, int>();
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
                        try
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
                                                #region 点对群接收图片信息
                                                if (package.SCType == SignalRCommunicationType.PersonToGroup)
                                                {
                                                    if (Teams.organizationPanel.NormalGroupDialogList.Count > 0)
                                                    {

                                                        foreach (var item in Teams.organizationPanel.NormalGroupDialogList)
                                                        {
                                                            //Uri server = new Uri(String.Format("{0}?filename={1}", api, ServerFileName));


                                                            HttpClient httpClient = new HttpClient();
                                                            string picName = FileHelper.Encrept_byCgf(package.Title);
                                                            //string p = System.IO.Path.GetDirectoryName(@"D:\MiniU_tempImg\" + picName);
                                                            //if (!Directory.Exists(p))
                                                            //    Directory.CreateDirectory(p);
                                                            string pathPic = package.Context.ToString();
                                                            HttpResponseMessage responseMessage = httpClient.GetAsync("http://localhost:37768/api/User/DownloadFile?fileName=" + pathPic).Result;

                                                            if (responseMessage.IsSuccessStatusCode)
                                                            {
                                                                using (FileStream fs = File.Create(@"D:\MiniU_tempImg\" + picName))
                                                                {
                                                                    Stream streamFromService = responseMessage.Content.ReadAsStreamAsync().Result;
                                                                    streamFromService.CopyTo(fs);
                                                                }

                                                                byte[] b = File.ReadAllBytes(@"D:\MiniU_tempImg\" + picName);

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
                                                                        string actualName = MainClient.SysUserCollection.Where(l => l.ID == package.FromUserId).FirstOrDefault().ActualName;
                                                                        //string actualName = item.groupMembers.Where(l => l.UserId == package.FromUserId).FirstOrDefault().Name;
                                                                        LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                                        leftMessageBoxUControl.Init(actualName, "", img, "Image");
                                                                        item.NoticeStackPanel.Children.Add(leftMessageBoxUControl);
                                                                    }
                                                                }
                                                            }



                                                            item.MsgScroll.ScrollToBottom();
                                                        }

                                                    }
                                                    else if (package.State == false) //显示在消息盒子,群没有state这一字段，这个是类里的，没对应所以没作用
                                                    {
                                                        //加载到界面
                                                        UserDTO userInfo = MainClient.SysUserCollection.Where(l => l.ID == package.FromUserId).FirstOrDefault();

                                                        if (groupMsgBoxs.ContainsKey(package.ToUserId))   //已有信息盒，覆盖，更新计数
                                                        {
                                                            ListViewItem lvi = new ListViewItem();
                                                            lvi = groupMsgBoxs[package.ToUserId];

                                                            lvi.Uid = (groupMsgCount[package.ToUserId] + 1).ToString();
                                                            lvi.ToolTip = "10:02";
                                                            lvi.Tag = userInfo.ActualName + ":[图片]";

                                                            groupMsgCount[package.ToUserId] += 1;
                                                        }
                                                        else     //未有该信息发送者信息盒，新建
                                                        {
                                                            Image img = new Image();
                                                            BitmapImage bitImg = new BitmapImage(new Uri("WpfClient;component/Images/Img_Header/unKnowHeaderImg.jpg", UriKind.Relative));
                                                            img.Source = bitImg;
                                                            ListViewItem lvi = new ListViewItem();

                                                            ResourceDictionary mWindowResouce = new ResourceDictionary();
                                                            mWindowResouce.Source = new Uri("WpfClient;component/Resource/ControlStyle.xaml", UriKind.Relative);
                                                            this.Resources.MergedDictionaries.Add(mWindowResouce);
                                                            lvi.Style = (Style)mWindowResouce["MessagePanelListViewItemStyle"];

                                                            GroupDTO userGroup = MainClient.SysUserGroupCollection.Where(l => l.Id == package.ToUserId).FirstOrDefault();

                                                            lvi.Name = "_" + userGroup.Name; // 纯数字会出错所以加了下划线开头
                                                            lvi.Uid = "1";
                                                            lvi.ToolTip = "10:02";
                                                            lvi.Tag = userInfo.ActualName + ":[图片]";
                                                            lvi.Content = img;
                                                            lvi.TabIndex = package.ToUserId;//跟点对点不同
                                                            lvi.MouseDoubleClick += Lvi_MouseDoubleClick;

                                                            mb.Lv_message.Items.Add(lvi);
                                                            mb.Lv_message.ScrollIntoView(lvi);//滚动条滚动到最后一条

                                                            groupMsgBoxs.Add(package.ToUserId, lvi);
                                                            groupMsgCount.Add(package.ToUserId, 1);
                                                        }
                                                    }
                                                }
                                                #endregion
                                                #region 点对点接收图片信息 (界面未完善，16.9.14注)
                                                else if (package.SCType == SignalRCommunicationType.PersonToPerson)
                                                {
                                                    if (Contacts.Contacts.PrivateDialogList.Count > 0)
                                                    {

                                                        foreach (var item in Contacts.Contacts.PrivateDialogList)
                                                        {
                                                            if (item.grid_historyMsg.Visibility == Visibility)
                                                            {

                                                            HttpClient httpClient = new HttpClient();
                                                            string picName = FileHelper.Encrept_byCgf(package.Title);
                                                            string pathPic = package.Context.ToString();
                                                            HttpResponseMessage responseMessage = httpClient.GetAsync("http://localhost:37768/api/User/DownloadFile?fileName=" + pathPic).Result;

                                                                if (responseMessage.IsSuccessStatusCode)
                                                                {
                                                                    using (FileStream fs = File.Create(@"D:\MiniU_tempImg\" + picName))
                                                                    {
                                                                        Stream streamFromService = responseMessage.Content.ReadAsStreamAsync().Result;
                                                                        streamFromService.CopyTo(fs);
                                                                    }

                                                                    byte[] b = File.ReadAllBytes(@"D:\MiniU_tempImg\" + picName);

                                                                    BitmapImage myBitmapImage = new BitmapImage();
                                                                    myBitmapImage.BeginInit();
                                                                    myBitmapImage.StreamSource = new MemoryStream(b);
                                                                    myBitmapImage.EndInit();

                                                                    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                                                                    img.Source = myBitmapImage;


                                                                    string userName=MainClient.SysUserCollection.Where(l => l.ID == package.FromUserId).FirstOrDefault().ActualName;
                                                                    Paragraph p = new Paragraph();
                                                                    Run r = new Run(userName);
                                                                    p.Inlines.Add(r);
                                                                    p.Foreground = Brushes.Blue;
                                                                    item.fdoc_historyMsg.Blocks.Add(p);


                                                                    p = new Paragraph();                                                                             
                                                                    p.Inlines.Add(img);
                                                                    item.fdoc_historyMsg.Blocks.Add(p);


                                                                }
                                                                
                                                             
                                                            }
                                                            else
                                                            {
                                                                //Uri server = new Uri(String.Format("{0}?filename={1}", api, ServerFileName));
                                                                HttpClient httpClient = new HttpClient();
                                                                string picName = FileHelper.Encrept_byCgf(package.Title);
                                                                //string p = System.IO.Path.GetDirectoryName(@"D:\MiniU_tempImg\" + picName);
                                                                //if (!Directory.Exists(p))
                                                                //    Directory.CreateDirectory(p);
                                                                string pathPic = package.Context.ToString();
                                                                HttpResponseMessage responseMessage = httpClient.GetAsync("http://localhost:37768/api/User/DownloadFile?fileName=" + pathPic).Result;

                                                                if (responseMessage.IsSuccessStatusCode)
                                                                {
                                                                    using (FileStream fs = File.Create(@"D:\MiniU_tempImg\" + picName))
                                                                    {
                                                                        Stream streamFromService = responseMessage.Content.ReadAsStreamAsync().Result;
                                                                        streamFromService.CopyTo(fs);
                                                                    }

                                                                    byte[] b = File.ReadAllBytes(@"D:\MiniU_tempImg\" + picName);

                                                                    BitmapImage myBitmapImage = new BitmapImage();
                                                                    myBitmapImage.BeginInit();
                                                                    myBitmapImage.StreamSource = new MemoryStream(b);
                                                                    myBitmapImage.EndInit();

                                                                    System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                                                                    img.Source = myBitmapImage;
                                                                    if (img != null)
                                                                    {
                                                                        if (MainClient.CurrentUser.ID.Equals(package.ToUserId) && package.FromUserId == item.ReplyId)
                                                                        {
                                                                            LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                                            leftMessageBoxUControl.Init(item.To, "", img, "Image");
                                                                            item.MessageStackPanel.Children.Add(leftMessageBoxUControl);
                                                                        }
                                                                        else if (MainClient.CurrentUser.ID.Equals(package.FromUserId) && package.ToUserId == item.ReplyId)
                                                                        {
                                                                            RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                                                                            rightMessageBoxUControl.Init(item.Self, "", img, "Image");
                                                                            item.MessageStackPanel.Children.Add(rightMessageBoxUControl);
                                                                        }
                                                                    }

                                                                }



                                                                item.MsgScroll.ScrollToBottom();
                                                            }
                                                        }

                                                    }
                                                    else
                                                    {
                                                        if (package.State == false && MainClient.CurrentUser.ID.Equals(package.ToUserId))//只显示接收并且未读的的，发送的没必要
                                                        {
                                                            //加载到界面


                                                            if (userMsgBoxs.ContainsKey(package.FromUserId))   //已有信息盒，覆盖，更新计数
                                                            {
                                                                ListViewItem lvi = new ListViewItem();
                                                                lvi = userMsgBoxs[package.FromUserId];

                                                                lvi.Uid = (userMsgCount[package.FromUserId] + 1).ToString();
                                                                lvi.ToolTip = "10:02";
                                                                lvi.Tag = "[图片]";

                                                                userMsgCount[package.FromUserId] += 1;
                                                            }
                                                            else     //未有该信息发送者信息盒，新建
                                                            {
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
                                                                lvi.Tag = "[图片]";
                                                                lvi.Content = img;
                                                                lvi.TabIndex = package.FromUserId;
                                                                lvi.MouseDoubleClick += Lvi_MouseDoubleClick1;

                                                                mb.Lv_message.Items.Add(lvi);
                                                                mb.Lv_message.ScrollIntoView(lvi);//滚动条滚动到最后一条

                                                                userMsgBoxs.Add(package.FromUserId, lvi);
                                                                userMsgCount.Add(package.FromUserId, 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion
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
                                                            if (item.grid_historyMsg.Visibility == Visibility)
                                                            {
                                                                //item.rtb_historyMsg.AppendText(package.FromUserId.ToString());
                                                                //item.rtb_historyMsg.SelectionBrush = Brushes.AliceBlue;
                                                                //item.rtb_historyMsg.Foreground = Brushes.Red;
                                                                //item.rtb_historyMsg.AppendText("\n");
                                                                //item.rtb_historyMsg.AppendText(package.Context.ToString());
                                                                //item.rtb_historyMsg.Foreground = Brushes.Blue;
                                                                //item.rtb_historyMsg.AppendText("\n");
                                                                //需要具体写历史记录页面的消息

                                                                string userName = MainClient.SysUserCollection.Where(l => l.ID == package.FromUserId).FirstOrDefault().ActualName;
                                                                string myString = package.Context.ToString();
                                                                //item.rtb_historyMsg.Document = new FlowDocument(new Paragraph(new Run(myString)));
                                                                Paragraph p = new Paragraph();  // Paragraph 类似于 html 的 P 标签
                                                                Run r = new Run(userName);      // Run 是一个 Inline 的标签
                                                                p.Inlines.Add(r);
                                                                p.Foreground = Brushes.Blue;
                                                                item.fdoc_historyMsg.Blocks.Add(p);

                                                                p = new Paragraph();  // Paragraph 类似于 html 的 P 标签
                                                                r = new Run(myString);      // Run 是一个 Inline 的标签
                                                                p.Inlines.Add(r);
                                                                p.Foreground = Brushes.Black;
                                                                item.fdoc_historyMsg.Blocks.Add(p);
                                                            }
                                                            else
                                                            {

                                                                if (MainClient.CurrentUser.ID.Equals(package.ToUserId) && package.FromUserId == item.ReplyId)
                                                                {
                                                                    LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                                    leftMessageBoxUControl.Init(item.To, package.Context.ToString(), null, "Text");
                                                                    item.MessageStackPanel.Children.Add(leftMessageBoxUControl);
                                                                }
                                                                else if (MainClient.CurrentUser.ID.Equals(package.FromUserId) && package.ToUserId == item.ReplyId)
                                                                {
                                                                    RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                                                                    rightMessageBoxUControl.Init(item.Self, package.Context.ToString(), null, "Text");
                                                                    item.MessageStackPanel.Children.Add(rightMessageBoxUControl);
                                                                }

                                                                item.MsgScroll.ScrollToBottom();
                                                            }
                                                        }
                                                    }
                                                    else     //接收消息加载到消息页面
                                                    {
                                                        if (package.State == false && MainClient.CurrentUser.ID.Equals(package.ToUserId))//只显示接收的，发送的没必要
                                                        {
                                                            //加载到界面



                                                            if (userMsgBoxs.ContainsKey(package.FromUserId))   //已有信息盒，覆盖，更新计数
                                                            {
                                                                ListViewItem lvi = new ListViewItem();
                                                                lvi = userMsgBoxs[package.FromUserId];

                                                                lvi.Uid = (userMsgCount[package.FromUserId] + 1).ToString();
                                                                lvi.ToolTip = "10:02";
                                                                lvi.Tag = package.Context;

                                                                userMsgCount[package.FromUserId] += 1;
                                                            }
                                                            else     //未有该信息发送者信息盒，新建
                                                            {
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
                                                                lvi.TabIndex = package.FromUserId;
                                                                lvi.Content = img;
                                                                lvi.MouseDoubleClick += Lvi_MouseDoubleClick1;

                                                                mb.Lv_message.Items.Add(lvi);
                                                                mb.Lv_message.ScrollIntoView(lvi);//滚动条滚动到最后一条

                                                                userMsgBoxs.Add(package.FromUserId, lvi);
                                                                userMsgCount.Add(package.FromUserId, 1);
                                                            }
                                                        }
                                                    }
                                                }
                                                #endregion
                                                #region 点对群接收文本信息
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
                                                                string actualName = MainClient.SysUserCollection.Where(l => l.ID == package.FromUserId).FirstOrDefault().ActualName;
                                                                //string actualName = item.groupMembers.Where(l => l.UserId == package.FromUserId).FirstOrDefault().Name;
                                                                LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                                                                leftMessageBoxUControl.Init(actualName, package.Context.ToString(), null, "Text");
                                                                item.NoticeStackPanel.Children.Add(leftMessageBoxUControl);
                                                            }


                                                            item.MsgScroll.ScrollToBottom();
                                                        }


                                                    }
                                                    else
                                                    {
                                                        //加载到界面
                                                        UserDTO userInfo = MainClient.SysUserCollection.Where(l => l.ID == package.FromUserId).FirstOrDefault();

                                                        if (groupMsgBoxs.ContainsKey(package.ToUserId))   //已有信息盒，覆盖，更新计数
                                                        {
                                                            ListViewItem lvi = new ListViewItem();
                                                            lvi = groupMsgBoxs[package.ToUserId];

                                                            lvi.Uid = (groupMsgCount[package.ToUserId] + 1).ToString();
                                                            lvi.ToolTip = "10:02";
                                                            lvi.Tag = userInfo.ActualName + ":" + package.Context;

                                                            groupMsgCount[package.ToUserId] += 1;
                                                        }
                                                        else if (package.State == false)    //未有该信息发送者信息盒，新建
                                                        {
                                                            Image img = new Image();
                                                            BitmapImage bitImg = new BitmapImage(new Uri("WpfClient;component/Images/Img_Header/unKnowHeaderImg.jpg", UriKind.Relative));
                                                            img.Source = bitImg;
                                                            ListViewItem lvi = new ListViewItem();

                                                            ResourceDictionary mWindowResouce = new ResourceDictionary();
                                                            mWindowResouce.Source = new Uri("WpfClient;component/Resource/ControlStyle.xaml", UriKind.Relative);
                                                            this.Resources.MergedDictionaries.Add(mWindowResouce);
                                                            lvi.Style = (Style)mWindowResouce["MessagePanelListViewItemStyle"];

                                                            GroupDTO userGroup = MainClient.SysUserGroupCollection.Where(l => l.Id == package.ToUserId).FirstOrDefault();

                                                            lvi.Name = "_" + userGroup.Name; // 纯数字会出错所以加了下划线开头
                                                            lvi.Uid = "1";
                                                            lvi.ToolTip = "10:02";
                                                            lvi.Tag = userInfo.ActualName + ":" + package.Context;
                                                            lvi.Content = img;
                                                            lvi.TabIndex = package.ToUserId;
                                                            lvi.MouseDoubleClick += Lvi_MouseDoubleClick;


                                                            mb.Lv_message.Items.Add(lvi);
                                                            mb.Lv_message.ScrollIntoView(lvi);//滚动条滚动到最后一条

                                                            groupMsgBoxs.Add(package.ToUserId, lvi);
                                                            groupMsgCount.Add(package.ToUserId, 1);
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


                                //创建存放临时图片的文件夹
                                if (!Directory.Exists(@"D:\MiniU_tempImg"))
                                    Directory.CreateDirectory(@"D:\MiniU_tempImg");

                                this.Close();

                                mainWin.ShowDialog();


                            }
                            else if (result.Message == "基础提供程序在 Open 上失败。")
                            {
                                MessageBox.Show("服务器连接失败");
                            }
                            else
                            {
                                MessageBox.Show("用户名或密码错误");
                            }
                        }
                        catch (Exception ex)
                        { MessageBox.Show("异常情况，请联系管理员"); }
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

        /// <summary>
        /// 点对点的信息盒双击事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lvi_MouseDoubleClick1(object sender, MouseButtonEventArgs e)
        {
            ListViewItem lvi = new ListViewItem();
            lvi = sender as ListViewItem;

            //检查窗口是否已经打开
            foreach (var item in Contacts.Contacts.PrivateDialogList)
            {
                if (item.ReplyId == lvi.TabIndex)
                    return;//群的有focus，这里没有，试试区别
            }

            PrivateDialog pd1 = new PrivateDialog();
            Contacts.Contacts.PrivateDialogList.Add(pd1);
            pd1.To = lvi.Name.Substring(1);
            pd1.Self = MainClient.CurrentUser.UserName;
            pd1.ReplyId = lvi.TabIndex;


            pd1.Closed += (sen, er) =>
            {
                Contacts.Contacts.PrivateDialogList.Remove(pd1);
            };

            pd1.Init();
            System.Threading.Thread.Sleep(1000);

            pd1.Show();


            SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTPTextPackage("", MainClient.CurrentUser.ID, pd1.ReplyId, System.DateTime.Now);
            String json_srmp = JsonConvert.SerializeObject(srmp);
            LoginWin.SignalRProxy.InitPTP(json_srmp);//InitPTP里面已经有获取数据，不过只获取未读数据
            LoginWin.SignalRProxy.MarkMessage(json_srmp);//标记已读
        }

        /// <summary>
        /// 主页消息盒子双击事件，打开聊天框（点对群）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Lvi_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {

            ListViewItem lvi = new ListViewItem();
            lvi = sender as ListViewItem;

            //检查窗口是否已经打开
            foreach (var item in Teams.organizationPanel.NormalGroupDialogList)
            {
                if (item.CurrentGroup.Id == lvi.TabIndex)
                {
                    item.Focus();
                    return;
                }

            }

            NormalGroupDialog pd = new NormalGroupDialog();
            Teams.organizationPanel.NormalGroupDialogList.Add(pd);


            pd.TitleLable = lvi.Name.Substring(1);
            GroupDTO userGroup = MainClient.SysUserGroupCollection.Where(l => l.Id == lvi.TabIndex).FirstOrDefault();
            pd.CurrentGroup = userGroup;
            pd.Closed += (sen, er) =>
            {
                Teams.organizationPanel.NormalGroupDialogList.Remove(pd);
            };


            //pd.Init(MainClient.CurrentUser.ActualName, group.Id.ToString());


            pd.Show();

            System.Threading.Thread.Sleep(500);

            SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTGTextPackage("", MainClient.CurrentUser.ID, userGroup.Id, System.DateTime.Now);
            String json_srmp = JsonConvert.SerializeObject(srmp);
            LoginWin.SignalRProxy.InitPTP(json_srmp);
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
            Window1 umw = new Window1();
            //UserManageWin umw = new UserManageWin();
            umw.ShowDialog();
        }
    }




}
