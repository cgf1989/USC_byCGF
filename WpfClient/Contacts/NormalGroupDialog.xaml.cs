using BCP.ViewModel;
using BCP.WebAPI.SignalR;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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
using WpfClient.Login;
using WpfClient.Teams;

namespace WpfClient.Contacts
{
    /// <summary>
    /// NormalGroupDialog.xaml 的交互逻辑
    /// </summary>
    public partial class NormalGroupDialog : MyMacClass
    {
        public NormalGroupDialog()
        {
            InitializeComponent();
            mWindowResouce.Source = new Uri("WpfClient;component/Contacts/MyWindow.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(mWindowResouce);
            //this.Style = (Style)mWindowResouce["WindowStyle"];
            //var windowTemplate = (ControlTemplate)mWindowResouce["WindowTemplate"];
            //this.Template = windowTemplate;
            //mTemplate = windowTemplate;
            this.Loaded += new RoutedEventHandler(WindowBase_Loaded);
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            mBackGroundType = BackGroundType.Blue;

            input.Click += InputNoticeBtn_Click;
            InputNoticeTBox.TextChanged += InputNoticeTBox_TextChanged;
            groupMembers = new List<GroupMemberDTO>();

            //Init(MainClient.CurrentUser.ActualName, CurrentGroup.ID.ToString());
            //this.SignalRProxy.Login(MainClient.CurrentUser.UserName, MainClient.CurrentUser.Password);
        }

        public String TitleLable { set; get; }

        private readonly ResourceDictionary mWindowResouce = new ResourceDictionary();
        private readonly ControlTemplate mTemplate;

        private const int WM_NCHITTEST = 0x0084;
        private const int WM_GETMINMAXINFO = 0x0024;

        private const int CORNER_WIDTH = 12; //拐角宽度  
        private const int MARGIN_WIDTH = 4; // 边框宽度  
        //private Point mMousePoint = new Point(); //鼠标坐标  
        private Button mMaxButton;
        private bool mIsShowMax = true;
        private bool IsShowMax = false;
        private BackGroundType mBackGroundType = BackGroundType.Blue;

        //public SignalRProxy SignalRProxy { get; set; }
        private String Group { get; set; }
        private String UserName { get; set; }
        private System.Guid CommentId { get; set; }
        public GroupDTO CurrentGroup { get; set; }
        public List<GroupMemberDTO> groupMembers { get; set; }

        void InputNoticeTBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (InputNoticeTBox.Text.Trim().Equals(""))
            {
                this.input.ToolTip = "发送";
            }
        }

        void InputNoticeBtn_Click(object sender, RoutedEventArgs e)
        {
            if (input.Content.Equals("+"))      //防止点击"+"直接发送消息了
                return;

            String keyword = Expander_Range.Header.ToString();

            if (input.ToolTip.Equals("发送"))
            {
                SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTGTextPackage(InputNoticeTBox.Text.Trim(), MainClient.CurrentUser.ID, CurrentGroup.Id);
                string json_srmp = JsonConvert.SerializeObject(srmp);
                LoginWin.SignalRProxy.SendMessage(json_srmp);


                RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                rightMessageBoxUControl.Init(MainClient.CurrentUser.ActualName, InputNoticeTBox.Text.Trim(), null, "Text");
                this.NoticeStackPanel.Children.Add(rightMessageBoxUControl);



            }
            else
            {
                //SignalRProxy.PublicSend(Group, true, String.Empty, CommentId,keyword, this.InputNoticeTBox.Text.Trim(), SignalCore.MessageType.Text);
            }


        }

        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {

            //-------------------给标头赋值------------------------

            //lb_Title.Content = TitleLable;
            this.Title = TitleLable;
            LoadGroupMembers();

        }

        public void Init(String userName, String group)
        {


            this.Group = group;
            this.UserName = userName;

            //if (LoginWin.SignalRProxy.ReceviceMessage == null)
            //{
            //    LoginWin.SignalRProxy.ReceviceMessage = (package) =>
            //    {

            //        this.Dispatcher.Invoke(() =>
            //       {         

            //            if (package.SMType == SignalRMessageType.StateMessage) { return; }
            //if (MainClient.CurrentUser.ID.Equals(package.FromUserId))
            //{
            //    RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
            //    rightMessageBoxUControl.Init(MainClient.CurrentUser.ActualName, package.Context.ToString(), null, "Text");
            //    this.NoticeStackPanel.Children.Add(rightMessageBoxUControl);

            //}
            //else
            //{
            //    string actualName = groupMembers.Where(l => l.UserId == package.FromUserId).FirstOrDefault().Name;

            //    LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
            //    leftMessageBoxUControl.Init(actualName, package.Context.ToString());
            //    this.NoticeStackPanel.Children.Add(leftMessageBoxUControl);
            //}
            //       });
            //    };
            //}



        }

        private List<SignalCore.publicMessage> _noticeList = new List<SignalCore.publicMessage>();

        void SaveMessage(SignalCore.publicMessage notice, string userName)
        {
            bool isExistence = false;
            foreach (var node in NoticeStackPanel.Children)
            {
                if ((node as PLeftMessageBoxUControl).Id == notice.Id)
                {
                    var item = node as PLeftMessageBoxUControl;
                    item.UpdateListBox(notice.Comments);
                    isExistence = true;
                    break;
                }
            }

            if (!isExistence)
            {
                if (notice.KeyWord == Expander_Range.Header.ToString() || Expander_Range.Header.ToString() == "所有内容")
                {
                    PLeftMessageBoxUControl pLeftMessage = new PLeftMessageBoxUControl();
                    pLeftMessage.Init(notice.Belongs, notice.Comments, notice.DateTime,
                        notice.From, notice.Id, notice.Message);
                    pLeftMessage.Comment = (id) =>
                    {
                        this.CommentId = id;
                        this.input.ToolTip = "评论";
                        this.InputNoticeTBox.Text = userName + ":";
                    };
                    NoticeStackPanel.Children.Add(pLeftMessage);
                }
            }
            _noticeList.Add(notice);
        }

        void Show(String keyword, String userName)
        {
            if (NoticeStackPanel.Children.Count >= 0)
                NoticeStackPanel.Children.Clear();
            foreach (var notice in _noticeList)
            {
                bool isExistence = false;
                foreach (var node in NoticeStackPanel.Children)
                {
                    if ((node as PLeftMessageBoxUControl).Id == notice.Id)
                    {
                        var item = node as PLeftMessageBoxUControl;
                        item.UpdateListBox(notice.Comments);
                        isExistence = true;
                        break;
                    }
                }

                if (!isExistence)
                {
                    if (notice.KeyWord == keyword || keyword == "所有内容")
                    {
                        PLeftMessageBoxUControl pLeftMessage = new PLeftMessageBoxUControl();
                        pLeftMessage.Init(notice.Belongs, notice.Comments, notice.DateTime,
                            notice.From, notice.Id, notice.Message);
                        pLeftMessage.Comment = (id) =>
                        {
                            this.CommentId = id;
                            this.input.ToolTip = "评论";
                            this.InputNoticeTBox.Text = userName + ":";
                        };
                        NoticeStackPanel.Children.Add(pLeftMessage);
                    }
                }
            }
        }




        //VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV邵工代码VVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVVV



        int clickCount = 0;


        private void input_Click(object sender, RoutedEventArgs e)
        {
            Button bt = sender as Button;
            if (bt != null)
            {
                if ((string)bt.Content == "+")
                {
                    if (clickCount == 0)
                    {
                        clickCount += 1;
                        //this.Height = 160;
                        wrap1.Visibility = Visibility.Visible;
                        wrap2.Visibility = Visibility.Visible;
                        //InputNoticeTBox.IsEnabled = false;
                        //this.RenderTransform = new TranslateTransform(0, -120);


                    }

                    else
                    {
                        clickCount = 0;
                        InputNoticeTBox.IsEnabled = true;
                        wrap1.Visibility = Visibility.Collapsed;
                        wrap2.Visibility = Visibility.Collapsed;
                        RaiseEvent(e);
                    }
                }
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox ttb = sender as TextBox;
            string btname = input.Content.ToString();
            if (btname == "+")
            {
                if (ttb.Text != "")
                {
                    input.FontSize = 10;
                    input.Content = "发送";
                    InputNoticeTBox.Text = ttb.Text;
                }
            }
            else if (btname == "发送")
            {
                if (ttb.Text == "")
                {
                    input.FontSize = 18;
                    input.Content = "+";
                }
            }

        }

        private void docButton_Click(object sender, RoutedEventArgs e)
        {
            Teams.DocPublish k = new Teams.DocPublish();
            k.Show();
        }

        private void videoButton_Click(object sender, RoutedEventArgs e)
        {
            CameraWin cameraWin = new CameraWin();

            cameraWin.ShowDialog();
        }

        private void taskButton_Click(object sender, RoutedEventArgs e)
        {
            WpfClient.Teams.Control.Task trs = new WpfClient.Teams.Control.Task();
            trs.ShowDialog();
        }

        private void Tvi_Range_Selected(object sender, RoutedEventArgs e)
        {
            //Expander_Range.Header = (TreeView_range.SelectedItem as TreeViewItem).Header;

            lbName = (TreeView_range.SelectedItem as TreeViewItem).Header.ToString();
            selectTreeViewParent(TreeView_range.SelectedItem as TreeViewItem);
            Expander_Range.Header = lbName;
            Expander_Range.IsExpanded = false;

            Show(Expander_Range.Header.ToString(), UserName);
        }


        string lbName = "";
        /// <summary>
        /// 遍历查找父节点
        /// </summary>
        /// <param name="tvItem"></param>
        void selectTreeViewParent(TreeViewItem tvItem)
        {
            if (tvItem.Parent != null)
            {
                var aaa = tvItem.Parent;
                if (aaa is TreeViewItem)
                {
                    lbName = (tvItem.Parent as TreeViewItem).Header.ToString() + "->" + lbName;
                    selectTreeViewParent(tvItem.Parent as TreeViewItem);
                }
                else
                {
                    return;
                }
            }
        }

        /// <summary>
        /// 添加群成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_AddGroupMember_Click(object sender, RoutedEventArgs e)
        {
            Win_NewUserToNormalGroup Win_nutg = new Win_NewUserToNormalGroup();
            Win_nutg.CurGroup = CurrentGroup;
            Win_nutg.ShowDialog();
            if (Win_nutg.AddedUser.Members.Count > 0)
            {
                lbox_GroupMember.ItemsSource = null;
                lbox_GroupMember.ItemsSource = Win_nutg.AddedUser.Members;
            }
        }


        /// <summary>
        /// 移除组成员
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void btn_RemoveGroupMember_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (lbox_GroupMember.SelectedItem != null)
                {
                    GroupMemberDTO selectedContact = lbox_GroupMember.SelectedItem as GroupMemberDTO;

                    HttpClient client = new HttpClient();
                    client.BaseAddress = new Uri("http://localhost:37768/");
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    HttpResponseMessage response = await client.GetAsync("api/User/RemoveUserFromGroup?userId=" + MainClient.CurrentUser.ID + "&groupId=" + CurrentGroup.Id + "&groupMemberId=" + selectedContact.Id);
                    response.EnsureSuccessStatusCode();
                    if (response.IsSuccessStatusCode)
                    {
                        string ds = await response.Content.ReadAsStringAsync();
                        CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                        if (result.Success)
                        {
                            //成功移除,刷新界面
                            LoadGroupMembers();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("请选择要移除的成员");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("移除失败");
            }
        }

        /// <summary>
        /// 获取该分组成员并加载
        /// </summary>
        async void LoadGroupMembers()
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/User/GetGroupMember?groupId=" + CurrentGroup.Id);
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        groupMembers = JsonConvert.DeserializeObject<List<GroupMemberDTO>>(result.Data);
                        lbox_GroupMember.ItemsSource = null;
                        lbox_GroupMember.ItemsSource = groupMembers;
                        lbox_GroupMember.DisplayMemberPath = "Name";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("成员获取失败");
            }
        }

        /// <summary>
        /// 发送图片按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_Image_Click(object sender, RoutedEventArgs e)
        {
            string filePath = "";
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "图片文件|*.jpg;*.jpeg;*.bmp;*.ico;*.png";
            if (ofd.ShowDialog() == true)
            {
                using (var client = new HttpClient())
                using (var content = new MultipartFormDataContent())
                {
                    // Make sure to change API address  
                    client.BaseAddress = new Uri("http://localhost:37768/");

                    // Add first file content   
                    byte[] b = File.ReadAllBytes(ofd.FileName);
                    Console.WriteLine(b.Length);
                    var fileContent1 = new ByteArrayContent(b);
                    fileContent1.Headers.ContentDisposition = new ContentDispositionHeaderValue("attachment")
                    {
                        FileName = ofd.SafeFileName
                    };

                    content.Add(fileContent1);

                    // Make a call to Web API  
                    client.Timeout = new TimeSpan(1, 1, 1);
                    var result = client.PostAsync("/api/User/UpLoadFile?fileName=" + ofd.SafeFileName, content).Result;
                    result.EnsureSuccessStatusCode();
                    if (result.IsSuccessStatusCode)
                    {
                        Task<string> ds = result.Content.ReadAsStringAsync();
                        CustomMessage result1 = JsonConvert.DeserializeObject<CustomMessage>(ds.Result);
                        if (result1.Success)
                        {
                            filePath =JsonConvert.DeserializeObject<String>(result1.Data);


                            //FileStream fs = new FileStream(ofd.FileName, FileMode.Open);//可以是其他重载方法 
                            //byte[] byData = new byte[fs.Length];
                            //fs.Read(byData, 0, byData.Length);
                            //fs.Close();

                            //string context1 = Convert.ToBase64String(byData);              
                            SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTGImgPackage(filePath, ofd.SafeFileName, MainClient.CurrentUser.ID, CurrentGroup.Id);
                            srmp.SMType = SignalRMessageType.Img;
                            string json_srmp = JsonConvert.SerializeObject(srmp);
                            LoginWin.SignalRProxy.SendMessage(json_srmp);


                            //用流的方式来读取图片不会占用图片，直接用uri的方式则会
                            BitmapImage myBitmapImage = new BitmapImage();
                            myBitmapImage.BeginInit();
                            myBitmapImage.StreamSource = new MemoryStream(b);
                            myBitmapImage.EndInit();

                            System.Windows.Controls.Image img = new System.Windows.Controls.Image();
                            img.Source = myBitmapImage;
                            if (img != null)
                            {
                                RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                                rightMessageBoxUControl.Init(MainClient.CurrentUser.ActualName, "", img, "Image");
                                this.NoticeStackPanel.Children.Add(rightMessageBoxUControl);
                            }
                        }
                        else
                        {
                            MessageBox.Show("图片上传失败");//上传失败
                        }
                    }
                        
                    
             
                }
            }

        }


        //-----------------------------------胡勇代码begin-------------------------------------------
        //static void Main(string[] args)
        //{
        //    DownLoad(@"D:\Adobe_Photoshop_CS5.zip");
        //}



        //static bool DownLoad(string SaveFileName)
        //{
        //Uri server = new Uri(String.Format("{0}?filename={1}", api, ServerFileName));
        //        HttpClient httpClient = new HttpClient();

        //        string p = Path.GetDirectoryName(SaveFileName);

        //            if (!Directory.Exists(p))
        //                Directory.CreateDirectory(p);

        //            HttpResponseMessage responseMessage = httpClient.GetAsync("http://localhost:37768/api/User/DownloadFile?fileName=Adobe_Photoshop_CS5_path201609071626546900.zip").Result;

        //            if (responseMessage.IsSuccessStatusCode)
        //            {
        //                using (FileStream fs = File.Create(SaveFileName))
        //                {
        //                    Stream streamFromService = responseMessage.Content.ReadAsStreamAsync().Result;
        //        streamFromService.CopyTo(fs);
        //                    return true;
        //                }
        //}
        //            else
        //                return false;
        //}

        //-------------------------------胡勇代码END------------------------------------------------
    }
}

