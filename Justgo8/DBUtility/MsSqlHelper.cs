using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using Common;

namespace DBUtility
{
    public class MsSqlHelper
    {
        public static string ConnectionStr = ConfigurationManager.AppSettings["mssqlconn"];

        /// <summary>
        /// 实例化数据连接字符串
        /// </summary>
        /// <returns>返回数据连接</returns>
        public SqlConnection GetCon()
        {
            SqlConnection con = new SqlConnection(ConnectionStr);
            return con;
        }

        /// <summary>
        /// 查看结果
        /// </summary>
        /// <param name="sql">SQL语句</param>
        /// <returns>返回DataTable</returns>
        public DataTable SeeResults(string sql)
        {
            SqlConnection con = GetCon();
            DataTable dt = new DataTable();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);
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
            SqlConnection con = GetCon();
            SqlCommand cmd = new SqlCommand(sql, con);
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
            SqlConnection con = GetCon();
            SqlCommand cmd = new SqlCommand(sql, con);
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
            SqlCommand cmd = new SqlCommand();
            SqlConnection con = GetCon();
            DataSet ds = new DataSet();
            try
            {
                SqlDataAdapter da = new SqlDataAdapter(sql, con);  //自动打开连接

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
