using log4net;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace wmsWF
{
    public class LogHelper
    {
        public static readonly ILog loginfo = log4net.LogManager.GetLogger("loginfo");
        public static readonly ILog logerror = log4net.LogManager.GetLogger("logerror");

        public static void WriteLog(string info)
        {
            if (loginfo.IsInfoEnabled)
            {
                loginfo.Info(info);
            }
        }

        public static void WriteLog(string info, Exception se)
        {
            if (logerror.IsErrorEnabled)
            {
                logerror.Error(info, se);
            }
        }
    }
}
