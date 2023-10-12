using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ViewModels
{
    public class ResponseObj<T> where T : class
    {
        public bool isSuccess { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
}
