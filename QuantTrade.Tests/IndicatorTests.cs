﻿/*
* BSD 2-Clause License 
* Copyright (c) 2017, Rich Lane 
* All rights reserved. 
* 
* Redistribution and use in source and binary forms, with or without 
* modification, are permitted provided that the following conditions are met: 
* 
* Redistributions of source code must retain the above copyright notice, this 
* list of conditions and the following disclaimer. 
* 
* Redistributions in binary form must reproduce the above copyright notice, 
* this list of conditions and the following disclaimer in the documentation 
* and/or other materials provided with the distribution. 
* 
* THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" 
* AND ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE 
* IMPLIED WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE 
* DISCLAIMED. IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE 
* FOR ANY DIRECT, INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL 
* DAMAGES (INCLUDING, BUT NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR 
* SERVICES; LOSS OF USE, DATA, OR PROFITS; OR BUSINESS INTERRUPTION) HOWEVER 
* CAUSED AND ON ANY THEORY OF LIABILITY, WHETHER IN CONTRACT, STRICT LIABILITY, 
* OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) ARISING IN ANY WAY OUT OF THE USE 
* OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY OF SUCH DAMAGE. 
*/

using Microsoft.VisualStudio.TestTools.UnitTesting;
using QuantTrade.Core;
using System;
using QuantTrade.Core.Indicators;

namespace QuantTrade.Tests
{
    [TestClass()]
    public class IndicatorTests
    {

        [TestMethod()]
        public void EMATest()
        {
            int period =6;

            //Read a string
            double[] vars = { 145.44, 139.8, 140.8, 137.8, 145.8, 146.3, 144.1, 143.1, 145, 147, 145.8, 147, 144.8, 144.4, 140.3, 141.9, 140.8, 140.3, 135.9, 139.6 };
            ExponentialMovingAverage ema = new Core.Indicators.ExponentialMovingAverage(period, MovingAverageType.Wilders );
            
            for (int i = 0; i < vars.Length; i++)
            {
                ema.UpdateIndicator(Convert.ToDecimal(vars[i]));

                if (i+1 == period) Assert.IsTrue(ema.IsReady);

                if (i == 5) Assert.IsTrue(Math.Round(ema.Value,2) == 142.66m, "Assert 5");
                if (i == 6) Assert.IsTrue(Math.Round(ema.Value, 2) == 142.90m, "Assert 6");
                if (i == 7) Assert.IsTrue(Math.Round(ema.Value, 2) == 142.93m, "Assert 7");
                if (i == 8) Assert.IsTrue(Math.Round(ema.Value, 2) == 143.28m, "Assert 8");
                if (i == 9) Assert.IsTrue(Math.Round(ema.Value, 2) == 143.90m, "Assert 9");

            }

        }

        [TestMethod()]
        public void RSITest()
        {
            int period = 2;

            //Read a string
            double[] vars = { 242.64, 244.66, 243.01, 242.95, 242.84, 243.13, 243.29, 241.33, 243.49, 241.35, 241.8, 242.21, 242.77, 240.55, 242.11, 242.37, 242.19, 244.01, 244.42, 245.56, 245.53 };

            RelativeStrengthIndex rsi = new RelativeStrengthIndex(period, MovingAverageType.Wilders);

            for (int i = 0; i < vars.Length; i++)
            {
                rsi.UpdateIndicator(Convert.ToDecimal(vars[i]));

                if (i == period * 5)
                    Assert.IsTrue(rsi.IsReady);

                if (i == 0) Assert.IsTrue(Math.Round(rsi.Value, 0) == 100m, "Assert 0");
                if (i == 1) Assert.IsTrue(Math.Round(rsi.Value, 0) == 100m, "Assert 1");
                if (i == 2) Assert.IsTrue(Math.Round(rsi.Value, 0) == 55m, "Assert 2");
                if (i == 3) Assert.IsTrue(Math.Round(rsi.Value, 0) == 53m, "Assert 3");
                if (i == 4) Assert.IsTrue(Math.Round(rsi.Value, 0) == 48m, "Assert 4");

                if (i == 5) Assert.IsTrue(Math.Round(rsi.Value, 0) == 66m, "Assert 5");
                if (i == 6) Assert.IsTrue(Math.Round(rsi.Value, 0) == 76m, "Assert 6");
                if (i == 7) Assert.IsTrue(Math.Round(rsi.Value, 0) == 10m, "Assert 7");
                if (i == 8) Assert.IsTrue(Math.Round(rsi.Value, 0) == 69m, "Assert 8");
                if (i == 9) Assert.IsTrue(Math.Round(rsi.Value, 0) == 30m, "Assert 9");
                
            }
            
        }

        [TestMethod()]
        public void SMATest()
        {
            int period = 2;

            //Read a string
            double[] vars = { 242.64, 244.66, 243.01, 242.95, 242.84, 243.13, 243.29, 241.33, 243.49, 241.35, 241.8, 242.21, 242.77, 240.55, 242.11, 242.37, 242.19, 244.01, 244.42, 245.56, 245.53 };

            SimpleMovingAverage sma = new SimpleMovingAverage(period);

            for (int i = 0; i < vars.Length; i++)
            {
                sma.UpdateIndicator(Convert.ToDecimal(vars[i]));

                if (i == 1) Assert.IsTrue(sma.IsReady);
                
                if (i == 0) Assert.IsTrue(Math.Round(sma.Value, 2) == 242.64m, "Assert 0");
                if (i == 1) Assert.IsTrue(Math.Round(sma.Value, 2) == 243.65m, "Assert 1");
                if (i == 2) Assert.IsTrue(Math.Round(sma.Value, 2) == 243.84m, "Assert 2");
                if (i == 3) Assert.IsTrue(Math.Round(sma.Value, 2) == 242.98m, "Assert 3");
                if (i == 4) Assert.IsTrue(Math.Round(sma.Value, 2) == 242.90m, "Assert 4");

                //Debug.WriteLine(Math.Round(sma.Value,2));

            }

        }
        
    }

}