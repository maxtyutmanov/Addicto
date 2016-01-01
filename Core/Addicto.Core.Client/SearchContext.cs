﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Addicto.Core.Client
{
    public class SearchContext
    {
        public string Query { get; set; }
        public object Response { get; set; }

        public bool IsFinished
        {
            get
            {
                return Response != null;
            }
        }
    }
}
