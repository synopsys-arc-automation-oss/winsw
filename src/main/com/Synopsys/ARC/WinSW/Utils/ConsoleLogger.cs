using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace Synopsys.ARC.WinSW.Utils
{
    public class ConsoleLogger : IEventWriter
    {
        public void LogEvent(String message)
        {
            LogEvent(message, EventLogEntryType.Information);
        }

        public void LogEvent(String message, EventLogEntryType type)
        {
            Console.WriteLine("<" + type + ">: " + message);
        }
 
    }
}
