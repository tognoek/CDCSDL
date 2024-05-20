using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class ResSend
    {
        public List<Send> Sends { get; set; }
        public List<LoiKhuyen> LoiKhuyens { get; set; }
    }
}