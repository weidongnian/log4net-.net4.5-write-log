using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using log4net;
using log4net.Appender;

namespace Hotch.Log {
    public class LogFactory {
        static LogFactory () {
            //通过文件来配置
            log4net.Repository.ILoggerRepository repository = log4net.LogManager.CreateRepository ("NetLogRepository");

            var fileInfo = new FileInfo (AppDomain.CurrentDomain.BaseDirectory+"Config/log4net.config");

            log4net.Config.XmlConfigurator.Configure (repository, fileInfo);

            log4net.Config.BasicConfigurator.Configure (repository);

            log4net.ILog log = log4net.LogManager.GetLogger (repository.Name, "NetLogRepository");
        }

        public static log4net.ILog GetLogger (string str) {
            return log4net.LogManager.GetLogger ("NetLogRepository", str);
        }
    }
}