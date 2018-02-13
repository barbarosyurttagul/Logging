using log4net;
using log4net.Config;

namespace Msb.Core.CrossCuttingConcerns.Logging.Log4Net
{
    public class Log4NetManager : ILogManager
    {
        private readonly ILog _log;

        public Log4NetManager()
        {
            _log = LogManager.GetLogger("MsbManager");
            XmlConfigurator.Configure();
        }

        public void Debug(string message)
        {
            if (_log.IsDebugEnabled)
            {
                _log.Debug(message);
            }
        }

        public void Error(string message)
        {
            if (_log.IsErrorEnabled)
            {
                _log.Error(message);
            }
        }

        public void Fatal(string message)
        {
            if (_log.IsFatalEnabled)
            {
                _log.Fatal(message);
            }
        }

        public void Info(string message)
        {
            if (_log.IsInfoEnabled)
            {
                _log.Info(message);
            }
        }

        public void Warning(string message)
        {
            if (_log.IsWarnEnabled)
            {
                _log.Warn(message);
            }
        }
    }
}
