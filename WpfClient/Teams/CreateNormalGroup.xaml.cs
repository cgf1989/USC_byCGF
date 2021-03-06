﻿using BCP.ViewModel;
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

namespace WpfClient.Teams
{
    /// <summary>
    /// AddNewContactWin.xaml 的交互逻辑
    /// </summary>
    public partial class CreateNormalGroup : MyMacClass_noneMaxBtn
    {
        public bool IsRefresh { set; get; }

        public CreateNormalGroup()
        {
            InitializeComponent();
            IsRefresh = false;

            //生成群号
            Random rNum = new Random();
            tb_GroupNum.Text ="100"+rNum.Next(1000).ToString();
        }

        private async void btn_Confirm_Click(object sender, RoutedEventArgs e)
        {
            if (tb_GroupName.Text.Trim() != "")
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:37768/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage response = await client.GetAsync("api/User/RegisterGroup?userId=" + MainClient.CurrentUser.ID+ "&groupNumber=" +tb_GroupNum.Text+ "&groupName="+tb_GroupName.Text+ "&groupNotes="+"1"+"&groupType="+tb_GroupType.Text+ "&groupValidate="+"1");
                response.EnsureSuccessStatusCode();
                if (response.IsSuccessStatusCode)
                {
                    string ds = await response.Content.ReadAsStringAsync();
                    CustomMessage result = JsonConvert.DeserializeObject<CustomMessage>(ds);
                    if (result.Success)
                    {
                        IsRefresh = true;
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("创建失败");
                    }
                }

                    
            }
            else
            {
                MessageBox.Show("群名不能为空");
            }
        }
    }
}
