using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotch.Log
{
    /// <summary>
    /// 日志
    /// </summary>
    public class Instance
    {
        #region 实例方法
        private ILog logger;

        public Instance(string name="日志")
        {
            this.logger = LogFactory.GetLogger(name);
        }
        
        public void Debug(object message)
        {
            this.logger.Debug(message);
        }

        public void Error(object message)
        {
            this.logger.Error(message);
        }

        public void Error(Exception ex, string message=null)
        {
            if(ex!=null){
                this.logger.Error(ex.Message);
                if(ex.InnerException!=null){
                    Error(ex.InnerException,null);
                }
            }
            
            if(message!=null)
            this.logger.Error(message);
        }

        public void Info(object message)
        {
            this.logger.Info(message);
        }

        public void Warn(object message)
        {
            this.logger.Warn(message);
        }
        #endregion

        /// <summary>
        /// Log耗时测试,20万数据耗时14479[13153、13255]毫秒,启用buffer速度更快?12966[12945]
        /// </summary>
        /// <param name="otal"></param>
        /// <returns></returns>
        public static string Test(int otal = 200000)
        {
            var total = 200000;
            var sw = new Stopwatch();
            var log = LogFactory.GetLogger("日志"); 

            sw.Start();

            for (int i = 0; i < total; i++)
            {
                log.Info("log4 bigdata test: " + i);
            }

            sw.Stop();
            var msg = "total: " + total + ", Elapsed:" + sw.ElapsedMilliseconds;

            log.Info(msg);

            return msg;
        }

    }
}