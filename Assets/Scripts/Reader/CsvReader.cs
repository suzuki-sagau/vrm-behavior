using System;
using System.Collections.Generic;
using System.IO;

namespace VRMBehavior {
    public class CsvReader : Reader{
        public override void Play() {
            string path = Config.instance.Data.csvPath;
            var lines = new List<String>();
            using (StreamReader reader = new StreamReader(@path)) {
                while (!reader.EndOfStream) {
                    lines.Add(reader.ReadLine());
                }
                reader.Close();
            }
            onReceivedDelegate(lines);
        }
    }
}