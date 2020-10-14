using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NewsTestPlatform.Models.Logging
{
    public class Logger
    {
        public static string GetLogLocation(object obj)
        {
            return obj.ToString() + new StackTrace(false).GetFrame(0).GetMethod().Name;
        }

        public static void GetLogExeption(ILogger logger, Exception ex, object obj)
        {
            logger.LogInformation(GetLogLocation(obj) + ex.Message);
        }

        public static void GetLogError(ILogger logger, string err)
        {
            logger.LogInformation(err);
        }

    }
}
