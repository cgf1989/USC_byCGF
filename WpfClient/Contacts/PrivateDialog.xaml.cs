using BCP.ViewModel;
using BCP.WebAPI.SignalR;
using Newtonsoft.Json;
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

        public SignalRProxy SignalRProxy { get; set; }

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
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            mBackGroundType = BackGroundType.Blue;
            //Init();
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
                SignalRProxy.SendMessage(json_srmp);


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


            if (SignalRProxy == null)
            {
                SignalRProxy = new SignalRProxy();
            }
            SignalRProxy.ConnectAsync();


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

            if (SignalRProxy.ReceviceMessage == null)
            {
                SignalRProxy.ReceviceMessage = (package) =>
                  {
                      this.Dispatcher.Invoke(() =>
                      {
                          if (package.SMType == SignalRMessageType.StateMessage) { return; }

                          if (package.FromUserId.Equals(package.ToUserId))
                          {
                              LeftMessageBoxUControl leftMessageBoxUControl = new LeftMessageBoxUControl();
                              leftMessageBoxUControl.Init(To, package.Context.ToString());
                              this.MessageStackPanel.Children.Add(leftMessageBoxUControl);
                          }
                          else
                          {
                              RightMessageBoxUControl rightMessageBoxUControl = new RightMessageBoxUControl();
                              rightMessageBoxUControl.Init(Self, package.Context.ToString());
                              this.MessageStackPanel.Children.Add(rightMessageBoxUControl);
                          }
                      }
                      );

                  };
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
