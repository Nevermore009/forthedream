using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
using System.Data.OleDb;
using System.Web;
using System.Data;
using Common;

namespace DBUtility
{
    public class OleSqlHelper
    {
        public static string ConnectionStr = string.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0}", HttpContext.Current.Request.PhysicalApplicationPath + ConfigurationSettings.AppSettings["mainconn"]);

        /// <summary>
        /// 实例化数据连接字符串
        /// </summary>
        /// <returns>返回数据连接</returns>
        public OleDbConnection GetCon()
        {
            OleDbConnection con = new OleDbConnection(ConnectionStr);
            return con;
        }

        /// <summary>
        /// 查看结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataTable</returns>
        public DataTable SeeResults(string sql)
        {
            OleDbConnection con = GetCon();
            DataTable dt = new DataTable();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);
                da.Fill(dt);
            }
            catch (Exception err)
            {
                ErrorLog.AddErrorLog(err);
            }
            return dt;

        }

        /// <summary>
        /// 增删改
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回结果</returns>
        public int GetNum(string sql)
        {
            int Results = 0;
            OleDbConnection con = GetCon();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            try
            {
                con.Open();
                Results = cmd.ExecuteNonQuery();
            }
            catch (Exception err)
            {
                ErrorLog.AddErrorLog(err);
            }
            finally
            {
                con.Close();
            }
            return Results;
        }

        /// <summary>
        /// 执行SQL语句，并返回第一行第一列结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns></returns>
        public string RunSqlReturn(string sql)
        {
            string strReturn = "";
            OleDbConnection con = GetCon();
            OleDbCommand cmd = new OleDbCommand(sql, con);
            try
            {
                con.Open();
                strReturn = cmd.ExecuteScalar().ToString();
            }
            catch (Exception err)
            {
                ErrorLog.AddErrorLog(err);
            }
            finally
            {
                con.Close();
            }
            return strReturn;
        }

        /// <summary>
        /// sql分页
        /// </summary>
        /// <param name="sql"></param>
        /// <param name="PageIndex">索引</param>
        /// <param name="PageSize">每页条数</param>
        /// <returns></returns>
        public DataTable GetTable(string sql, int PageIndex, int PageSize)
        {
            OleDbCommand cmd = new OleDbCommand();
            OleDbConnection con = GetCon();
            DataSet ds = new DataSet();
            try
            {
                OleDbDataAdapter da = new OleDbDataAdapter(sql, con);  //自动打开连接

                da.Fill(ds, PageIndex, PageSize, "TablePage");

            }
            catch (Exception ex)
            {
                ErrorLog.AddErrorLog(ex);
            }
            return ds.Tables[0];
        }
    }
}
