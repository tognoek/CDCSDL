﻿using System;
using System.Collections.Generic;
using WebApplication.Models;

namespace WebApplication.Models
{
    public class Send
    {
        public string phuongthuc { get; set; }
        public string ketqua { get; set; }
        public string tognoek { get; set; }
        public List<LoiKhuyen> LoiKhuyens { get; set; }
    }
}