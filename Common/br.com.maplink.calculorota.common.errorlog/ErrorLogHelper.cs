using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace br.com.maplink.calculorota.common.errorlog
{
    public class ErrorLogHelper
    {
        private const string FileName = ".\\Error.log";

        public void Log(Exception e)
        {
            StringBuilder tab = new StringBuilder();
            Exception ex = e;

            do
            {
                WriteExceptionToFile(ex, tab.ToString());
                tab.Append("\t");
                ex = ex.InnerException;
            } while (ex != null);
        }

        private void WriteExceptionToFile(Exception e, string tabLevel)
        {
            var frmt = string.Format("---------------------------------------------------------------------------" +
                                     "\n{0}\t{1}\n{2}{3}", DateTime.Now, e.Message, tabLevel, e.StackTrace);

            File.AppendAllText(FileName, frmt);
        }
    }
}
