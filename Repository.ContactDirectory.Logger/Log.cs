using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Repository.ContactDirectory.Logger
{
    public sealed class Log : ILog
    {
        
        private static Log instance = null;

        public static Log GetInstance
        {
            get
            {
                if (instance == null)
                    instance = new Log();
                return instance;
            }
        }
        
        private Log()
        {
           
        }

        public void LogException(string message)
        {
            string fileName = string.Format("{0}_{1}.log", "Exception", DateTime.Now.ToShortDateString());
            string logFilePath = string.Format(@"{0}\{1}", AppDomain.CurrentDomain.BaseDirectory, fileName);
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("----------------------------------------");
            sb.AppendLine(DateTime.Now.ToString());
            sb.AppendLine(message);
            using (StreamWriter writer = new StreamWriter(logFilePath, true))
            {
                writer.Write(sb.ToString());
                writer.Flush();
            }
        }
       
    }
}
