using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RegisterAndLoginApp.Utility
{
    public class MyLogger : ILogger
    {
        private static MyLogger instance;
        private static Logger logger;

        public static MyLogger GetInstance()
        {
            if (instance == null)
            {
                instance = new MyLogger();
            }
            return instance;
        }

        public Logger GetLogger()
        {
            if (MyLogger.logger == null)
            {
                MyLogger.logger = LogManager.GetLogger("RegisterLoginAppRule");
            }
            return MyLogger.logger;
        }

        public void Debug(string message)
        {
            GetLogger().Debug(message);
        }

        public void Error(string message)
        {
            GetLogger().Error(message);
        }

        public void Info(string message)
        {
            GetLogger().Info(message);
        }

        public void Warning(string message)
        {
            GetLogger().Warn(message);
        }
    }
}
