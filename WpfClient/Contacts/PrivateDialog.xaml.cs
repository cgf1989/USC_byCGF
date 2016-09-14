using BCP.ViewModel;
using BCP.WebAPI.SignalR;
using Microsoft.Win32;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
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

namespace WpfClient.Contacts
{
    /// <summary>
    /// PrivateDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PrivateDialog : MyMacClass
    {
        private readonly ResourceDictionary mWindowResouce = new ResourceDictionary();
        private readonly ControlTemplate mTemplate;

        private const int WM_NCHITTEST = 0x0084;
        private const int WM_GETMINMAXINFO = 0x0024;

        private const int CORNER_WIDTH = 12; //拐角宽度  
        private const int MARGIN_WIDTH = 4; // 边框宽度  
        private Point mMousePoint = new Point(); //鼠标坐标  
        private Button mMaxButton;
        private bool mIsShowMax = true;
        private bool IsShowMax = false;

        //public SignalRProxy SignalRProxy { get; set; }

        /// <summary>
        /// 聊天对象
        /// </summary>
        public String To { get; set; }

        public int ReplyId { get; set; }

        /// <summary>
        /// 自己
        /// </summary>
        public String Self { get; set; }

        private BackGroundType mBackGroundType = BackGroundType.Blue;

        public PrivateDialog()
        {
            InitializeComponent();
            InputBtn.Click += InputBtn_Click;
            //mWindowResouce.Source = new Uri("XJControls;component/Themes/Window.xaml", UriKind.Relative);
            mWindowResouce.Source = new Uri("WpfClient;component/Contacts/MyWindow.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(mWindowResouce);
            //this.Style = (Style)mWindowResouce["WindowStyle"];
            //var windowTemplate = (ControlTemplate)mWindowResouce["WindowTemplate"];
            //this.Template = windowTemplate;
            //mTemplate = windowTemplate;
            this.Loaded += new RoutedEventHandler(WindowBase_Loaded);
            this.KeyDown += PrivateDialog_KeyDown; ; //窗口CTRL+C事件
            //InputTBox.KeyDown += InputTBox_KeyDown;  //文本输入框按键事件
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            mBackGroundType = BackGroundType.Blue;
            //Init();
        }

      

        /// <summary>
        /// 键盘按下事件，CTRL+V 复制粘贴文本、图片、文件用,窗口用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PrivateDialog_KeyDown(object sender, KeyEventArgs e)
        {
            object clipboardType = KeyDownExtension.Window_KeyDown(sender, e);
            if (clipboardType != null)
            {

                if (clipboardType.GetType() == typeof(String)) //文本信息
                {
                    InputTBox.Text = clipboardType.ToString();
                }
                else if (clipboardType.GetType() == typeof(System.String[])) //文件
                {
                    MessageBox.Show("剪切板内容为文件，暂不支持");
                }
                else if (clipboardType.GetType() == typeof(System.Drawing.Bitmap)) //图片，与文件不同，比如截图这些，而不是图片文件
                {
                    System.Drawing.Bitmap clipboardImg = clipboardType as System.Drawing.Bitmap;
                    
                    string filePath = "";

                    using (var client = new HttpClient())
                    using (var content = new MultipartFormDataContent())
                    {
                        // Make sure to change API address  
                        client.BaseAddress = new Uri("http://localhost:37768/");

                        // Add first file content   
                        byte[] b = File.ReadAllBytes(clipboardType.ToString());
                        Console.WriteLine(b.Length);
                        var fileContent1 = new ByteArrayContent(b);

                        content.Add(fileContent1);

                        // Make a call to Web API  
                        client.Timeout = new TimeSpan(1, 1, 1);
                        var result = client.PostAsync("/api/User/UpLoadFile?fileName=" + clipboardType.ToString().Split('\\').LastOrDefault(), content).Result;
                        result.EnsureSuccessStatusCode();
                        if (result.IsSuccessStatusCode)
                        {
                            Task<string> ds = result.Content.ReadAsStringAsync();
                            CustomMessage result1 = JsonConvert.DeserializeObject<CustomMessage>(ds.Result);
                            if (result1.Success)
                            {
                                filePath = JsonConvert.DeserializeObject<String>(result1.Data);


                                SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTPImgPackage(filePath, clipboardType.ToString().Split('\\').LastOrDefault(), MainClient.CurrentUser.ID, ReplyId);
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
                                    this.MessageStackPanel.Children.Add(rightMessageBoxUControl);
                                }
                            }
                            else
                            {
                                MessageBox.Show("图片发送失败");//发送失败
                            }
                        }

                    }

                }
            }
        }

        /// <summary>
        /// 键盘按下事件，CTRL+V 复制粘贴文本、图片、文件用，文本框用
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTBox_KeyDown(object sender, KeyEventArgs e)
        {
            object clipboardType = KeyDownExtension.Window_KeyDown(sender, e);
            if (clipboardType != null)
            {
                MessageBox.Show(clipboardType.ToString());
            }
        }


        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            //((Border)mTemplate.FindName("FussWindowBorder", this)).MouseLeftButtonDown += (s1, e1) => this.DragMove();
            //((TextBlock)mTemplate.FindName("TitleText", this)).Text = this.Title;
            //((Image)mTemplate.FindName("ImgApp", this)).Source = this.Icon;

            //var backBorder = (Border)mTemplate.FindName("BorderBack", this);
            //var headBorder = (Border)mTemplate.FindName("TitleBar", this);
            //switch (mBackGroundType)
            //{
            //    case BackGroundType.Green:
            //        backBorder.Style = (Style)mWindowResouce["BackStyleWhite"];
            //        headBorder.Style = (Style)mWindowResouce["HeadStyleGreen"];
            //        break;
            //    case BackGroundType.Blue:
            //        backBorder.Style = (Style)mWindowResouce["BackStyleWhite"];
            //        headBorder.Style = (Style)mWindowResouce["HeadStyleBlue"];
            //        break;
            //    //case BackGroundType.Image:
            //    //    backBorder.Style = (Style)mWindowResouce["BackStyleImage"];
            //    //    backBorder.Background = new ImageBrush(mBackImage);
            //    //    headBorder.Style = (Style)mWindowResouce["HeadStyleTransparent"];
            //    //    break;
            //    default:
            //        backBorder.Style = (Style)mWindowResouce["BackStyleWhite"];
            //        headBorder.Style = (Style)mWindowResouce["HeadStyleGreen"];
            //        break;
            //}

            //mMaxButton = (Button)mTemplate.FindName("MaxButton", this);
            //if (!IsShowMax)
            //{
            //    mMaxButton.Visibility = Visibility.Collapsed;
            //    var rectangle = mTemplate.FindName("MaxSplitter", this) as Rectangle;
            //    if (rectangle != null)
            //        rectangle.Visibility = Visibility.Collapsed;
            //}
            //else mMaxButton.Visibility = Visibility.Visible;

            //this.SizeChanged += (s1, e1) =>
            //{
            //    if (this.WindowState == WindowState.Normal)
            //    {
            //        mMaxButton.Style = (Style)mWindowResouce["WinNormalButton"];
            //    }
            //    else if (mMaxButton.Style != (Style)mWindowResouce["WinMaxButton"]
            //        && this.WindowState == WindowState.Maximized)
            //    {
            //        mMaxButton.Style = (Style)mWindowResouce["WinMaxButton"];
            //    }
            //};

            //((Button)mTemplate.FindName("MiniButton", this)).Click += (s2, e2) =>
            //{
            //    this.WindowState = WindowState.Minimized;
            //};
            //mMaxButton.Click += (s3, e3) =>
            //{
            //    this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
            //};

            //((Button)mTemplate.FindName("CloseButton", this)).Click += (s4, e4) => this.Close();



            //var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            //if (hwndSource != null)
            //{
            //    hwndSource.AddHook(new HwndSourceHook(WndProc));
            //}
        }

        void InputBtn_Click(object sender, RoutedEventArgs e)
        {
            String message = this.InputTBox.Text.Trim();
            try
            {
                SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTPTextPackage(message, MainClient.CurrentUser.ID, ReplyId);
                //SignalRMessagePackage srmp = new SignalRMessagePackage(message, MainClient.CurrentUser.ID, ReplyId);
                string json_srmp = JsonConvert.SerializeObject(srmp);
                LoginWin.SignalRProxy.SendMessage(json_srmp);


                RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                rightMessageBoxUControl.Init(Self, new UserMessageDTO() { Content = message });
                this.MessageStackPanel.Children.Add(rightMessageBoxUControl);

            }
            catch (Exception ex)
            {
                MessageBox.Show("发生未知错误！");
            }
        }

        public void Init()
        {
            this.TitleLabel.Content = this.To;
            this.Title = "与 " + this.To + " 聊天中";
     
            InputTBox.Focus();

            //if (LoginWin.SignalR_MsgPackage.FromUserId == MainClient.CurrentUser.ID && LoginWin.SignalR_MsgPackage.ToUserId == ReplyId)
            //{
            //    if (MainClient.CurrentUser.ID.Equals(LoginWin.SignalR_MsgPackage.ToUserId))
            //    {
            //        LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
            //        leftMessageBoxUControl.Init(To, LoginWin.SignalR_MsgPackage.Context.ToString());
            //        this.MessageStackPanel.Children.Add(leftMessageBoxUControl);
            //    }
            //    else
            //    {
            //        RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
            //        rightMessageBoxUControl.Init(Self, LoginWin.SignalR_MsgPackage.Context.ToString(), null, "Text");
            //        this.MessageStackPanel.Children.Add(rightMessageBoxUControl);
            //    }
            //}


            //if (LoginWin.SignalRProxy == null)
            //{
            //    LoginWin.SignalRProxy = new SignalRProxy();
            //}
            //LoginWin.SignalRProxy.ConnectAsync();


            #region //注册SignalR客户端方法
            //if (SignalRProxy.ReceviceFialureMessage == null)
            //{
            //    SignalRProxy.ReceviceFialureMessage = (message) =>
            //    {
            //        this.Dispatcher.Invoke(() =>
            //        {
            //            MessageBox.Show(message);
            //        });
            //    };
            //}

            //if (SignalRProxy.ReceviceMessage == null)
            //{
            //    SignalRProxy.ReceviceMessage = (username, message) =>
            //    {
            //        this.Dispatcher.Invoke(() =>
            //        {
            //            LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
            //            leftMessageBoxUControl.Init(username, message);
            //            this.MessageStackPanel.Children.Add(leftMessageBoxUControl);
            //        });
            //    };
            //}


            //if (SignalRProxy.ReceviceRecord == null)
            //{
            //    SignalRProxy.ReceviceRecord = (username, record) =>
            //    {
            //        this.Dispatcher.Invoke(() =>
            //        {
            //            if (username.Equals(To))
            //            {
            //                LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
            //                leftMessageBoxUControl.Init(To, record);
            //                this.MessageStackPanel.Children.Add(leftMessageBoxUControl);
            //            }
            //            else
            //            {
            //                RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
            //                rightMessageBoxUControl.Init(Self, record);
            //                this.MessageStackPanel.Children.Add(rightMessageBoxUControl);
            //            }
            //        });
            //    };
            //}
            #endregion

            //if (LoginWin.SignalRProxy.ReceviceMessage == null)
            //{
            //    LoginWin.SignalRProxy.ReceviceMessage = (package) =>
            //      {
            //          this.Dispatcher.Invoke(() =>
            //          {
            //              if (package.SMType == SignalRMessageType.StateMessage) { return; }

            //              if (MainClient.CurrentUser.ID.Equals(package.ToUserId))
            //              {
            //                  LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
            //                  leftMessageBoxUControl.Init(To, package.Context.ToString());
            //                  this.MessageStackPanel.Children.Add(leftMessageBoxUControl);
            //              }
            //              else
            //              {
            //                  RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
            //                  rightMessageBoxUControl.Init(Self, package.Context.ToString(),null,"Text");
            //                  this.MessageStackPanel.Children.Add(rightMessageBoxUControl);
            //              }
            //          }
            //          );

            //      };
            //}
        }


        /// <summary>
        /// 测试用，发送图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItem_Click(object sender, RoutedEventArgs e)
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
                            filePath = JsonConvert.DeserializeObject<String>(result1.Data);


                            //FileStream fs = new FileStream(ofd.FileName, FileMode.Open);//可以是其他重载方法 
                            //byte[] byData = new byte[fs.Length];
                            //fs.Read(byData, 0, byData.Length);
                            //fs.Close();

                            //string context1 = Convert.ToBase64String(byData);              
                            SignalRMessagePackage srmp = SignalRMessagePackageFactory.GetPTPImgPackage(filePath, ofd.SafeFileName, MainClient.CurrentUser.ID, ReplyId);
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
                                this.MessageStackPanel.Children.Add(rightMessageBoxUControl);
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
    }

    public enum BackGroundType
    {
        /// <summary>  
        /// 绿色调  
        /// </summary>  
        Green,
        /// <summary>  
        /// 蓝色调  
        /// </summary>  
        Blue,
        /// <summary>  
        /// 背景图片  
        /// </summary>  
        Image
    }
}
