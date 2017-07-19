﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuantTrade.Core;


namespace QuantTrade.Core.Indicators
{
    public class RelativeStrengthIndex : BaseIndicator, IIndicator
    {
        

        /// <summary>
        /// Constructor
        /// </summary>
        public RelativeStrengthIndex(int length)
        {
            this.Buffer = new List<decimal>();
            Length = length;
        }
       
        /// <summary>
        /// Gets called from the CSVReader
        /// </summary>
        public void UpdateIndicator(TradeBar data)
        {
            
        }
    }
}
