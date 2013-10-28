using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using System.Configuration;
using System.Drawing;
using BLL;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;
using UI.Properties;

namespace UI
{
    static class Program
    {
        public static Sunisoft.IrisSkin.SkinEngine se = null;

        public static string userName = "";
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            try
            {
                int processcount = 0;
                Process[] pc = Process.GetProcesses();
                foreach (Process test in pc)
                {
                    if (test.ProcessName.ToLower() == Process.GetCurrentProcess().ProcessName.ToLower())
                    {
                        processcount++;
                        if (processcount > 1 && Process.GetCurrentProcess().ProcessName.ToLower() == "办公室节能管理系统")
                        {
                            MessageBox.Show("办公室节能管理系统已经打开，不允许重复打开，您可以查看是否最小化在右下角通知栏！", "提示", MessageBoxButtons.OK);
                            Process.GetCurrentProcess().Dispose();
                            Process.GetCurrentProcess().Kill();
                            return;
                        }
                    }
                }

                //处理未捕获的异常
                Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
                //处理UI线程异常
                Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(Application_ThreadException);
                //处理非UI线程异常
                AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(CurrentDomain_UnhandledException);

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                se = new Sunisoft.IrisSkin.SkinEngine();
                se.SkinAllForm = true;
                se.SkinFile = ConfigurationManager.AppSettings["skin"];
      
                LoginUI.Login login = new LoginUI.Login();
                login.LoginClick += () =>
                {
                    User user = new User();
                    if (user.LoginCheck(login.cmbname.Text, login.Password))
                    {
                        login.Visible = false;
                        userName = login.cmbname.Text;
                        (new MainForm()).Show();
                        //MainForm mainform = new MainForm();
                        //mainform.Owner =;
                        //mainform.Show();
                        return true;
                    }
                    else
                    {
                        MessageBox.Show("登录失败,用户名或密码错误!", "提示消息");
                        return false;
                    }
                };
                login.Text = ConfigurationManager.AppSettings["applicationname"];
                login.Icon = new Icon(ConfigurationManager.AppSettings["logo"]);
                login.BackgroundImage = Image.FromFile("images/background.jpg");

                Application.Run(login);
            }
            catch (Exception ex)
            {
                string str = "";
                string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";

                if (ex != null)
                {
                    str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                    ex.GetType().Name, ex.Message, ex.StackTrace);
                }
                else
                {
                    str = string.Format("应用程序线程错误:{0}", ex);
                }
                writeLog(str);
            }
        } 
        //LoginUI.Login login = new LoginUI.Login();
        //public string passText
        //{
        //    get { return login.cmbname.Text; }
        //} 
        private static bool Login_Check()
        {
            User user = new User();
            (new MainForm()).Show();
            return true;
        }


        #region 捕捉全局异常代码
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
        {
            string str = "";
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            Exception error = e.Exception as Exception;
            if (error != null)
            {
                str = string.Format(strDateInfo + "异常类型：{0}\r\n异常消息：{1}\r\n异常信息：{2}\r\n",
                error.GetType().Name, error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("应用程序线程错误:{0}", e);
            }
            writeLog(str);
        }

        static void CurrentDomain_UnhandledException(object sender, UnhandledExceptionEventArgs e)
        {
            string str = "";
            Exception error = e.ExceptionObject as Exception;
            string strDateInfo = "出现应用程序未处理的异常：" + DateTime.Now.ToString() + "\r\n";
            if (error != null)
            {
                str = string.Format(strDateInfo + "Application UnhandledException:{0};\n\r堆栈信息:{1}", error.Message, error.StackTrace);
            }
            else
            {
                str = string.Format("Application UnhandledError:{0}", e);
            }
            writeLog(str);
        }

        /// <summary>
        /// 写文件
        /// </summary>
        /// <param name="str"></param>
        static void writeLog(string str)
        {
            string ErrPath = AppDomain.CurrentDomain.BaseDirectory;

            if (!Directory.Exists(ErrPath))
            {
                Directory.CreateDirectory(ErrPath);
            }
            using (StreamWriter sw = new StreamWriter(@"ErrLog.txt", true))
            {
                sw.WriteLine(str);
                sw.WriteLine("-------------------------------------------------------------------------------");
                sw.Close();
            }
        }
        #endregion
    }
}
