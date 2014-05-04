using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace Common
{
    public class SystemTimer
    {
        /// <summary> 
        /// 在指定时间过后执行指定的表达式 
        /// </summary> 
        /// <param name="interval">事件之间经过的时间（以毫秒为单位）</param> 
        /// <param name="action">要执行的表达式</param> 
        public static void SetTimeout(double interval, Action action)
        {
            System.Timers.Timer timer = new System.Timers.Timer(interval);
            timer.Elapsed += delegate(object sender, System.Timers.ElapsedEventArgs e)
              {
                  timer.Enabled = false;
                  action();
              };
            timer.Enabled = true;
        }

        /// <summary>
        /// 在指定时间周期重复执行指定的表达式
        /// </summary>
        /// <param name="action">要执行的动作的回调函数</param>
        /// <param name="state">数据</param>
        /// <param name="dueTime">在开始之前的延迟时间</param>
        /// <param name="period">间隔时间</param>
        /// <returns></returns>
        public static Timer SetInterval(TimerCallback action, object state, int dueTime, int period)
        {
            return new System.Threading.Timer(action,state,dueTime,period);    
        }
    }
}
