﻿using QuantTrade.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuantTrade.Core.Data
{
    public interface IGenerator
    {
        string GenerateData(string symbol, Resolution resolution);
    }
}
