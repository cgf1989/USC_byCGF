using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media.Imaging;

namespace WpfClient.Contacts
{
    class KeyDownEvent
    {
    }

    public class KeyDownExtension
    {
        /// <summary>
        /// 返回null 数据类型包括(文本 ,Bitmap,文件路径)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <returns></returns>
        public static object Window_KeyDown(object sender, KeyEventArgs e)
        {
            Dictionary<Type, KeyDownEventBase> dict = GetLinkList();
            if (dict != null && dict.Count > 0)
            {
                return dict[dict.Keys.First()].Window_KeyDown(sender, e, dict);
            }

            throw new NotImplementedException("未找到合适的处理程序");
        }

        private static Dictionary<Type, KeyDownEventBase> GetLinkList()
        {
            Dictionary<Type, KeyDownEventBase> dict = new Dictionary<Type, KeyDownEventBase>();
            var assembly = Assembly.GetExecutingAssembly();
            var types = assembly.GetTypes();
            foreach (var type in types)
            {
                if (type.IsSubclassOf(typeof(KeyDownEventBase)))
                {
                    dict.Add(type, (KeyDownEventBase)Activator.CreateInstance(type));
                }
            }
            return dict;
        }
    }

    public abstract class KeyDownEventBase
    {
        /// <summary>
        /// return null or object
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        /// <param name="dict"></param>
        /// <returns>return null if has no suitable method or return dataObject</returns>
        public abstract object Window_KeyDown(object sender, KeyEventArgs e, Dictionary<Type, KeyDownEventBase> dict);
    }

    public class Ctrl_V_Text_KeyDown : KeyDownEventBase
    {
        public override object Window_KeyDown(object sender, KeyEventArgs e, Dictionary<Type, KeyDownEventBase> dict)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & (ModifierKeys.Control)) == (ModifierKeys.Control))
            {
                var data = Clipboard.GetDataObject();
                if (data.GetDataPresent(DataFormats.Text))
                {
                    return data.GetData(DataFormats.Text).ToString();
                }
            }

            if (dict != null && dict.Keys.Count > 1)
            {
                dict.Remove(this.GetType());
                return dict[dict.Keys.First()].Window_KeyDown(sender, e, dict);
            }

            return null;
        }
    }

    public class Ctrl_V_BitMap_KeyDown : KeyDownEventBase
    {
        public override object Window_KeyDown(object sender, KeyEventArgs e, Dictionary<Type, KeyDownEventBase> dict)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & (ModifierKeys.Control)) == (ModifierKeys.Control))
            {
                var data = Clipboard.GetDataObject();
                if (data.GetDataPresent(DataFormats.Bitmap))
                {
                    InteropBitmap bits = (InteropBitmap)data.GetData(DataFormats.Bitmap);
                    BitmapSource bmpSource = bits as BitmapSource;
                    MemoryStream ms = new MemoryStream();
                    BitmapEncoder encoder = new PngBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(bmpSource));
                    encoder.Save(ms);
                    ms.Seek(0, SeekOrigin.Begin);


                    System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);
                    return bitmap;
                }
            }

            if (dict != null && dict.Keys.Count > 1)
            {
                dict.Remove(this.GetType());
                return dict[dict.Keys.First()].Window_KeyDown(sender, e, dict);
            }

            return null;
        }
    }

    public class Ctrl_V_FileDrop_KeyDown : KeyDownEventBase
    {
        public override object Window_KeyDown(object sender, KeyEventArgs e, Dictionary<Type, KeyDownEventBase> dict)
        {
            if (e.Key == Key.V && (Keyboard.Modifiers & (ModifierKeys.Control)) == (ModifierKeys.Control))
            {
                var data = Clipboard.GetDataObject();
                if (data.GetDataPresent(DataFormats.FileDrop))
                {
                    return data.GetData(DataFormats.FileDrop);
                }
            }

            if (dict != null && dict.Keys.Count > 1)
            {
                dict.Remove(this.GetType());
                return dict[dict.Keys.First()].Window_KeyDown(sender, e, dict);
            }

            return null;
        }
    }
}
