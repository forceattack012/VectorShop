﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Identity.Application.DTOs
{
    public class LoginResponse
    {
        public bool IsSuccess { get; set; }
        public string Error { get; set; }
    }
}
