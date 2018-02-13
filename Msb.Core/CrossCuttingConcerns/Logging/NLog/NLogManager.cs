using System;
using NLog;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Msb.Core.CrossCuttingConcerns.Logging.NLog
{
    public class NLogManager : ILogManager
    {
        private readonly ILogger _logger;

        public NLogManager()
        {
            _logger = LogManager.GetLogger("MsbManager");
        }

        public void Debug(string message)
        {
            if (_logger.IsDebugEnabled)
            {
                _logger.Debug(message);
            }
        }

        public void Error(string message)
        {
            if (_logger.IsErrorEnabled)
            {
                _logger.Error(message);
            }
        }

        public void Fatal(string message)
        {
            if (_logger.IsFatalEnabled)
            {
                _logger.Fatal(message);
            }
        }

        public void Info(string message)
        {
            if (_logger.IsInfoEnabled)
            {
                _logger.Info(message);
            }
        }

        public void Warning(string message)
        {
            if (_logger.IsWarnEnabled)
            {
                _logger.Warn(message);
            }
        }
    }
}
