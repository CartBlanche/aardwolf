﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REST0
{
    public static class UTF8
    {
        public static readonly System.Text.UTF8Encoding WithoutBOM = new System.Text.UTF8Encoding(false);
        public static readonly System.Text.UTF8Encoding WithBOM = new System.Text.UTF8Encoding(true);
    }
}
