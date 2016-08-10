using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCP.ViewModel
{
    public class CustomMessage
    {
        public bool Success { get; set; }
        public String Message { get; set; }
        public Type Type { get; set; }
        public String Data { get; set; }
        public bool IsGeneric { get; set; }
    }
}
