using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace UI
{
    public class TimerTask
    {
        //定时器及定时列表
        public static Timer mytimer { set; get; }
        private static List<Task> tasklist = new List<Task>();

        public static void Init()
        {
            mytimer = new Timer();
            mytimer.Tick += DoWork;
        }

        public static void AddTask(Task task)
        {
            if (mytimer == null)
            {
                Init();
                AddCurrentDateTask(); 
            }
            lock (tasklist)
            {
                if (tasklist.Count <= 0)
                {
                    tasklist.Add(task);
                    mytimer.Interval = (int)Math.Floor((task.Time - DateTime.Now).TotalMilliseconds);
                    mytimer.Start();
                    return;
                }
                for (int i = 0; i < tasklist.Count; i++)
                {
                    if (task.Time < tasklist[i].Time)
                    {
                        tasklist.Insert(i, task);
                        mytimer.Interval = (int)Math.Floor((task.Time - DateTime.Now).TotalMilliseconds);
                        break;
                    }
                    else if (i == tasklist.Count - 1)
                    {
                        tasklist.Add(task);
                        break;
                    }
                }
            }
        }

        public static void AddTask(List<string> roomlist, DateTime starttime, DateTime endtime)
        {
            AddTask(new Task(starttime, TaskType.On, roomlist));
            AddTask(new Task(endtime, TaskType.Off, roomlist));
        }

        private static void DoWork(object sender,EventArgs e)
        {
            lock (tasklist)
            {
                if (tasklist[0].Type == TaskType.Init)   //初始化数据
                {
                    AddCurrentDateTask();
                }
                tasklist.RemoveAt(0);
                if (tasklist.Count > 0)
                {
                    int interval=(int)Math.Floor((tasklist[0].Time - DateTime.Now).TotalMilliseconds);
                    if (interval <= 0)   //如果已在执行的过程中超过了计划时间，则立即执行
                    {
                        interval = 1;
                    }
                    mytimer.Interval = interval;
                }
                else
                {
                    mytimer.Stop();
                }          
            }
        }

        private static void AddCurrentDateTask()
        {
 
        }

    }

    public class Task
    {
        public DateTime Time { set; get; }
        public TaskType Type { set; get; }
        public List<string> RoomList { set; get; }
        public Task(DateTime time, TaskType type, List<string> roomList)
        {
            this.Time = time;
            this.Type = type;
            this.RoomList = roomList;
        }   

    }

    /// <summary>
    /// 任务类型，On开启，Off关闭,Init初始化数据
    /// </summary>
    public enum TaskType { On, Off ,Init}

}
