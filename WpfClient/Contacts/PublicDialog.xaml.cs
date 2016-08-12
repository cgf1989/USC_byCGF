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
using WpfClient.Teams;

namespace WpfClient.Contacts
{
    /// <summary>
    /// PublicDialog.xaml 的交互逻辑
    /// </summary>
    public partial class PublicDialog : Window
    {
        public String TitleLable { set; get; }

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
        private BackGroundType mBackGroundType = BackGroundType.Blue; 

        private SignalRProxy SignalRProxy { get; set; }
        private String Group { get; set; }
        private String UserName { get; set; }
        private System.Guid CommentId { get; set; }

        public PublicDialog()
        {
            InitializeComponent();
            mWindowResouce.Source = new Uri("WpfClient;component/Contacts/MyWindow.xaml", UriKind.Relative);
            this.Resources.MergedDictionaries.Add(mWindowResouce);
            this.Style = (Style)mWindowResouce["WindowStyle"];
            var windowTemplate = (ControlTemplate)mWindowResouce["WindowTemplate"];
            this.Template = windowTemplate;
            mTemplate = windowTemplate;
            this.Loaded += new RoutedEventHandler(WindowBase_Loaded);
            this.MaxWidth = SystemParameters.MaximizedPrimaryScreenWidth;
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
            mBackGroundType = BackGroundType.Blue;

            input.Click += InputNoticeBtn_Click;
            InputNoticeTBox.TextChanged += InputNoticeTBox_TextChanged;
            
        }

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

            String keyWord = "";

            if (input.ToolTip.Equals("发送"))
            {
                //SignalRProxy.PublicSend(Group, false, String.Empty, System.Guid.Empty,keyWord, this.InputNoticeTBox.Text.Trim(), SignalCore.MessageType.Text);
            }
            else
            {
                //SignalRProxy.PublicSend(Group, true, String.Empty, CommentId,keyWord, this.InputNoticeTBox.Text.Trim(), SignalCore.MessageType.Text);
            }
        }

        private void WindowBase_Loaded(object sender, RoutedEventArgs e)
        {
            ((Border)mTemplate.FindName("FussWindowBorder", this)).MouseLeftButtonDown += (s1, e1) => this.DragMove();
            ((TextBlock)mTemplate.FindName("TitleText", this)).Text = this.Title;
            ((Image)mTemplate.FindName("ImgApp", this)).Source = this.Icon;

            var backBorder = (Border)mTemplate.FindName("BorderBack", this);
            var headBorder = (Border)mTemplate.FindName("TitleBar", this);
            switch (mBackGroundType)
            {
                case BackGroundType.Green:
                    backBorder.Style = (Style)mWindowResouce["BackStyleWhite"];
                    headBorder.Style = (Style)mWindowResouce["HeadStyleGreen"];
                    break;
                case BackGroundType.Blue:
                    backBorder.Style = (Style)mWindowResouce["BackStyleWhite"];
                    headBorder.Style = (Style)mWindowResouce["HeadStyleBlue"];
                    break;
                //case BackGroundType.Image:
                //    backBorder.Style = (Style)mWindowResouce["BackStyleImage"];
                //    backBorder.Background = new ImageBrush(mBackImage);
                //    headBorder.Style = (Style)mWindowResouce["HeadStyleTransparent"];
                //    break;
                default:
                    backBorder.Style = (Style)mWindowResouce["BackStyleWhite"];
                    headBorder.Style = (Style)mWindowResouce["HeadStyleGreen"];
                    break;
            }

            mMaxButton = (Button)mTemplate.FindName("MaxButton", this);
            if (!IsShowMax)
            {
                mMaxButton.Visibility = Visibility.Collapsed;
                var rectangle = mTemplate.FindName("MaxSplitter", this) as Rectangle;
                if (rectangle != null)
                    rectangle.Visibility = Visibility.Collapsed;
            }
            else mMaxButton.Visibility = Visibility.Visible;

            this.SizeChanged += (s1, e1) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    mMaxButton.Style = (Style)mWindowResouce["WinNormalButton"];
                }
                else if (mMaxButton.Style != (Style)mWindowResouce["WinMaxButton"]
                    && this.WindowState == WindowState.Maximized)
                {
                    mMaxButton.Style = (Style)mWindowResouce["WinMaxButton"];
                }
            };

            ((Button)mTemplate.FindName("MiniButton", this)).Click += (s2, e2) =>
            {
                this.WindowState = WindowState.Minimized;
            };
            mMaxButton.Click += (s3, e3) =>
            {
                this.WindowState = (this.WindowState == WindowState.Normal) ? WindowState.Maximized : WindowState.Normal;
            };

            ((Button)mTemplate.FindName("CloseButton", this)).Click += (s4, e4) => this.Close();

            //var hwndSource = PresentationSource.FromVisual(this) as HwndSource;
            //if (hwndSource != null)
            //{
            //    hwndSource.AddHook(new HwndSourceHook(WndProc));
            //}



            //-------------------给标头赋值------------------------

            lb_Title.Content =TitleLable;
        }

        public void Init(String userName,String group,SignalRProxy signalrProxy)
        {
            if (signalrProxy != null) this.SignalRProxy = signalrProxy;
            this.Group = group;
            this.UserName = userName;

            //if (SignalRProxy.ReceviceNotice == null)
            //{
            //    SignalRProxy.ReceviceNotice = (username, notice) => {
            //        this.Dispatcher.Invoke(() => {
            //            bool isExistence = false;
            //            foreach (var node in NoticeStackPanel.Children)
            //            {
            //                if ((node as PLeftMessageBoxUControl).Id == notice.Id)
            //                {
            //                    var item = node as PLeftMessageBoxUControl;
            //                    item.UpdateListBox(notice.Comments);
            //                    isExistence = true;
            //                    break;
            //                }
            //            }

            //            if (!isExistence)
            //            {
            //                PLeftMessageBoxUControl pLeftMessage = new PLeftMessageBoxUControl();
            //                pLeftMessage.Init(notice.Belongs, notice.Comments, notice.DateTime,
            //                    notice.From, notice.Id, notice.Message);
            //                pLeftMessage.Comment = (id) =>
            //                {
            //                    this.CommentId = id;
            //                    this.input.ToolTip=  "评论";
            //                    this.InputNoticeTBox.Text = userName + ":";
            //                };
            //                NoticeStackPanel.Children.Add(pLeftMessage);
            //            }
            //        });
            //    };
            //}

            SignalRProxy.ConnectAsync();
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

    
    }
}
