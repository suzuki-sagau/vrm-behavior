using System;
using System.IO;
using UnityEngine;

namespace VRMBehavior {
    public class Config {
        static public Config instance = new ();
        private string configDataPath = @"Assets/Data/config.json";
        private ConfigData configData;

        public ConfigData Data => configData;

        public Config() {
            StreamReader reader = new StreamReader(configDataPath);
            string jsonData = reader.ReadToEnd();
            reader.Close(); 
            configData = JsonUtility.FromJson<ConfigData>(jsonData);
        }
        
        [Serializable]
        public class ConfigData {
            public string csvPath;
        }    
}
}