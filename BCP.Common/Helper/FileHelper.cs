﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.Common.Helper
{
    public class FileHelper
    {
        /// <summary>
        /// 从文件路径中取出真是文件名（去除参数）
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string Decrept(string fileName)
        {
            String first = fileName.Substring(0, fileName.LastIndexOf('.'));
            String last = fileName.Substring(fileName.LastIndexOf('.') + 1);
            return first.Substring(0, first.Length - 23)+"." + last;
        }

        /// <summary>
        /// 重组文件名
        /// </summary>
        /// <param name="fileName">原文件名</param>
        /// <returns></returns>
        public static String Encrept(String fileName)
        {
                
            String first = fileName.Substring(0, fileName.LastIndexOf('.'));
            String last = fileName.Substring(fileName.LastIndexOf('.') + 1);
            return first + "_path" + DateTime.Now.ToString("yyyyMMddHHmmssffff")+"." + last;
        }
    }
}