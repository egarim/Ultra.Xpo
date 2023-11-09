using DevExpress.Xpo.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using static DevExpress.Utils.BindToTypePolicy;

namespace Ultra.Xpo.Loggers
{

    public class XpoFileLogger : ILogger
    {
        private readonly string _filePath;
        private readonly object _lock = new();
        public int Count => 0;
        public int LostMessageCount => 0;
        public bool IsServerActive => true;
        public bool Enabled { get; set; } = true;
        public int Capacity => 0;
        public void ClearLog() { }
        public XpoFileLogger(string filePath)
        {
            _filePath = filePath;
        }
        public void Log(LogMessage message)
        {
            // Implement your custom logic (for instance, to output messages in Console)
            if (Enabled)
            {

                //Console.WriteLine(message.ToString());
                lock (_lock)
                {
                    string jsonString = JsonSerializer.Serialize(message);
                    File.AppendAllText(_filePath, $"{jsonString}{Environment.NewLine}");
                    //File.AppendAllText(_filePath, $"{message.ToString()}{Environment.NewLine}");
                }
            }
        }

        public void Log(LogMessage[] messages)
        {
            foreach (var msg in messages)
            {
                Log(msg);
            }
        }
    }
}
