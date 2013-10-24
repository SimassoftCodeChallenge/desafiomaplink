using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace br.com.maplink.calculorota.common.wcf
{
    public static class Extensions
    {
        public static void ProcessUnhandledException(this Exception ex, string appName)
        {
            //log to Windows EventLog
            try
            {
                string sSource = System.Reflection.Assembly.GetEntryAssembly().FullName;
                string sLog = "Application";
                string sEvent = string.Format("Unhandled exception in {0}: {1}", appName, ex.ToString());
                if (!EventLog.SourceExists(sSource))
                    EventLog.CreateEventSource(sSource, sLog);

                EventLog.WriteEntry(sSource, sEvent);
                EventLog.WriteEntry(sSource, sEvent, EventLogEntryType.Error, 999);
            }
            catch
            {
                //do nothing if this one fails
            }
        }

    }
}
