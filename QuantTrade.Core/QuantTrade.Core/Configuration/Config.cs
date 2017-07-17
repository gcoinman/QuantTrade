﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace QuantTrade.Core.Configuration
{
    public static class Config
    {
        //Location of the configuration file.
        private const string _configurationFileName = "config.json";
        private static JObject _settings;

        static Config()
        {
            if(_settings == null)
            {
                _settings = JObject.Parse(File.ReadAllText(_configurationFileName));
            }
        }

     
     
        public static string GetToken(string key)
        {
            return _settings.SelectToken(key).ToString();
          
        }

    }
}
