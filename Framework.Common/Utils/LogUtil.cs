using log4net;
using System.Collections.Concurrent;
using System.Threading;

[assembly: log4net.Config.XmlConfigurator(Watch = true, ConfigFile = "log4net.config")]
namespace Framework.Common.Utils
{
    public static class LogUtil
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(LogUtil));
        private static BlockingCollection<string> _queue = new BlockingCollection<string>(new ConcurrentQueue<string>());

        static LogUtil()
        {
            Thread t = new Thread(new ThreadStart(ThreadLog));
            t.IsBackground = true;
            t.Start();
        }

        public static void Debug(string message)
        {
            _queue.TryAdd("1 " + message);
        }

        public static void Info(string message)
        {
            _queue.TryAdd("2 " + message);
        }

        public static void Warn(string message)
        {
            _queue.TryAdd("3 " + message);
        }

        public static void Error(string message)
        {
            _queue.TryAdd("4 " + message);
        }

        private static void ThreadLog()
        {
            while (true)
            {
                try
                {
                    string message = null;
                    bool ok = _queue.TryTake(out message, -1);
                    if (ok)
                    {
                        switch (message[0])
                        {
                            case '1':
                                _log.Debug(message);
                                break;

                            case '2':
                                _log.Info(message);
                                break;

                            case '3':
                                _log.Warn(message);
                                break;

                            case '4':
                                _log.Error(message);
                                break;
                        }
                    }
                }
                catch { }
            }
        }
    }
}
