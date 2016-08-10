using BCP.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;

namespace BCP.WebAPI.Helpers
{
    public class JsonHelper
    {
        public static HttpResponseMessage GetResponseMessage(bool isSuccess, String message,Type type,bool isGeneric,Object data)
        {
            String str = JsonConvert.SerializeObject(new CustomMessage() { Success = isSuccess, Message = message, Type = type,IsGeneric=isGeneric, Data = JsonConvert.SerializeObject(data) });
           return new HttpResponseMessage { Content = new StringContent(str, Encoding.GetEncoding("UTF-8"), "application/json") };
        }
    }
}