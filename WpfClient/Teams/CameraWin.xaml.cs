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
using System.Windows.Interop;

namespace WpfClient.Teams
{
    /// <summary>
    /// CameraWin.xaml 的交互逻辑
    /// </summary>
    public partial class CameraWin : MyMacClass
    {
        public CameraWin()
        {
            InitializeComponent();
        }

        public void Video()
        {
            Video video;
            //Video = new Video(panelPreview.Handle, panelPreview.Width, panelPreview.Height);
            video = new Video(((HwndSource)PresentationSource.FromVisual(this.TreeViewContent)).Handle, (int)this.Width, (int)this.Height);
            video.StartWebCam();
            video.get();
            video.Capparms.fYield = true;
            video.Capparms.fAbortLeftMouse = false;
            video.Capparms.fAbortRightMouse = false;
            video.set();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Video();
        }
    }
}
