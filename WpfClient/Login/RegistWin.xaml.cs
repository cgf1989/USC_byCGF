﻿using Microsoft.Win32;
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
using Newtonsoft.Json;

namespace WpfClient.Login
{
    /// <summary>
    /// RegistWin.xaml 的交互逻辑
    /// </summary>
    public partial class RegistWin : MyMacClass_noneMaxBtn
    {
        public RegistWin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 浏览插入头像
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btn_browse_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new Microsoft.Win32.OpenFileDialog();
            //op.InitialDirectory = lblSavePath.Text;//默认的打开路径
            //op.RestoreDirectory = true;
            op.Filter = " 图片文件(*.jpg、*.png)|*.jpg;*.jpeg;*.png|所有文件(*.*)|*.*";
            //txtLocalUrl.Text = op.FileName;

            try
            {
                if (op.ShowDialog() == true)
                {
                    Img_Header.Source = new BitmapImage(new Uri(op.FileName));
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("文件格式不正确");
            }
        }

        private async void btn_Regist_Click(object sender, RoutedEventArgs e)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:37768/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage response = await client.GetAsync("api/User/RegisterUser?userName=" + tb_userName.Text.Trim() + "&userPwd=" + tb_Password.Password + "&ActualName=" +tb_ActureName.Text.Trim());
           
            if (response.IsSuccessStatusCode)
            {
                string ds = await response.Content.ReadAsStringAsync();
                CustomMessage result=JsonConvert.DeserializeObject<CustomMessage>(ds);
                if (result.Success)
                {
                    MessageBox.Show("注册成功！");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("注册失败");
                }
            }
        }


        //增
        //api/User/RegisterUser?userName=" + tb_userName.Text.Trim() + "&userPwd=" + tb_Password.Password + "&Status=" + "" + "&LimiteTime=" + "20160810" + "&Note=" + "" + "&EventTime=" + 1
        //删
        //"&userId="+id
        //改密码
        //"&userId="+id+"&userPwd"+userPwd
        

    }
}
