﻿/** 
* Copyright (c) 2018 [Kronox]
*
* Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the “Software”), to deal in the Software without restriction, including without limitation the rights
* to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
*
* The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
*
* THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
* 
* ------------------------------------
* Created by Kronox on March 28, 2018
* ------------------------------------
**/

using Asphalt.Api.Util;

namespace AdvancedTeleportation.config
{
    class ConfigManager
    {
        private static ConfigManager instance;

        private readonly string filePath = "Mods/AdvancedTeleportation/";
        private readonly string fileName = "config.json";
        private AdvancedTeleportationConfig config;

        //Instance

        public static ConfigManager Instance
        {
            get
            {
                if (instance == null)
                    instance = new ConfigManager();
                return instance;
            }
        }

        public ConfigManager()
        {
            LoadConfigFile();
        }

        //File IO

        public void LoadConfigFile()
        {
            config = ClassSerializer<AdvancedTeleportationConfig>.Deserialize(filePath, fileName);
        }

        //Config Actions

        public object GetObject(string key)
        {
            object val;
            config.GetConfigValues().TryGetValue(key, out val);
            return val;
        }

        public string GetString(string key)
        {
            return this.GetObject(key).ToString();
        }

        public int GetInt(string key)
        {
            return int.Parse(this.GetString(key));
        }

        public float GetFloat(string key)
        {
            return float.Parse(this.GetString(key));
        }
    }
}