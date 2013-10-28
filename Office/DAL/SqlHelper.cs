using System;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public class SqlHelper
{
    public static string CONNECTIONSTRING = ConfigurationManager.ConnectionStrings["connection"].ConnectionString;


    /// <summary>
    /// 获取数据库的一个连接
    /// </summary>
    /// <returns>数据库的一个已打开连接</returns>
    public static SqlConnection GetConnection()
    {
        SqlConnection con = new SqlConnection(CONNECTIONSTRING);
        try
        {
            con.Open();
        }
        catch
        {
            throw;
        }
        return con;
    }

    /// <summary>
    /// 使用指定连接字符串创建数据库的一个连接
    /// </summary>
    /// <returns>数据库的一个已打开连接</returns>
    public static bool IsConnectionStringAvailable(string connectionString)
    {
        SqlConnection con = new SqlConnection(connectionString);
        try
        {
            con.Open();
            if (con.State == ConnectionState.Open)
                return true;
            else
                return false;
        }
        catch
        {
            return false;
        }
        finally
        {
            con.Dispose();
        }
    }

    /// <summary>
    /// 获取command对象
    /// </summary>
    /// <returns>已打开数据库连接的command对象</returns>
    public static SqlCommand GetCommand(params SqlParameter[] parameters)
    {
        SqlCommand cmd;
        try
        {
            cmd = GetConnection().CreateCommand();
            if (parameters != null)
                foreach (SqlParameter p in parameters)
                {
                    cmd.Parameters.Add(p);
                }
            return cmd;
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 获取DataAdapter
    /// </summary>
    /// <returns>对应数据库的DataAdapter</returns>
    public static SqlDataAdapter GetDataAdapter()
    {
        return new SqlDataAdapter(GetCommand());
    }



    #region 执行简单sql语句

    /// <summary>
    /// 执行sql语句并返回受影响的行数,如果为查询语句则返回-1
    /// </summary>
    /// <param name="sql">sql语句</param>
    /// <param name="canshu">参数</param>
    /// <returns>受影响的行数</returns>
    public static int ExecuteSql(string sql, params SqlParameter[] parameters)
    {
        SqlCommand cmd = GetCommand(parameters);
        try
        {
            cmd.CommandText = sql;
            return cmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    /// <summary>
    /// 执行查询，并返回查询所返回的结果集中第一行的第一列。所有其他的列和行将被忽略。
    /// </summary>
    /// <param name="sql">sql查询语句</param>
    /// <param name="parameters">参数</param>
    /// <returns>结果集中第一行的第一列</returns>
    public static object ExecuteScalar(string sql, params SqlParameter[] parameters)
    {
        SqlCommand cmd = GetCommand(parameters);
        try
        {
            cmd.CommandText = sql;
            return cmd.ExecuteScalar();
        }
        catch
        {
            throw;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    /// <summary>
    /// 执行查询语句，返回对应数据库的DataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
    /// </summary>
    /// <param name="sql">sql查询语句</param>
    /// <param name="parameters">参数</param>
    /// <returns>对应数据库的DataReader</returns>
    public static SqlDataReader GetDataReader(string sql, params SqlParameter[] parameters)
    {
        SqlCommand cmd = GetCommand(parameters);
        try
        {
            cmd.CommandText = sql;
            return cmd.ExecuteReader();
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 使用已知的SelectCommandText创建SqlDataAdapter对象
    /// </summary>
    /// <returns>对应数据库的DataAdapter</returns>
    public static SqlDataAdapter GetDataAdapter(string selectCommandText, params SqlParameter[] parameters)
    {
        SqlDataAdapter da = new SqlDataAdapter(selectCommandText, CONNECTIONSTRING);
        foreach (SqlParameter p in parameters)
            da.SelectCommand.Parameters.Add(p);
        return da;
    }
    /// <summary>
    /// 执行查询语句，返回DataSet
    /// </summary>
    /// <param name="sql">sql查询语句</param>
    /// <param name="parameters">参数字典</param>
    /// <returns>结果集DataSet</returns>
    public static DataSet GetDataSet(string sql, params SqlParameter[] parameters)
    {
        SqlDataAdapter da = null;
        try
        {
            da = GetDataAdapter(sql, parameters);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        catch
        {
            throw;
        }
        finally
        {
            da.Dispose();
        }
    }

    #endregion

    #region 执行多条sql语句

    /// <summary>
    /// 执行多条SQL语句，实现数据库事务。当有语句执行无受影响行数时,将作为执行失败处理
    /// </summary>
    /// <param name="sqls">sql语句集合，按顺序执行</param>
    /// <param name="parameters">二维数组的第n维参数为第n条语句所需参数</param>
    /// <returns>事务执行是否成功</returns>
    public static bool ExeTransaction(string[] sqls, params SqlParameter[][] parameters)
    {
        SqlConnection con = GetConnection();
        SqlCommand cmd = con.CreateCommand();
        SqlTransaction transaction = con.BeginTransaction();
        cmd.Transaction = transaction;
        try
        {
            for (int i = 0; i < sqls.Length; i++)
            {
                cmd.CommandText = sqls[i];
                cmd.Parameters.Clear();
                if (i <= parameters.Rank)
                {
                    foreach (SqlParameter p in parameters[i])
                    {
                        cmd.Parameters.Add(p);
                    }
                }
                cmd.ExecuteNonQuery();
            }
            transaction.Commit();
            return true;
        }
        catch
        {
            transaction.Rollback();
            throw;
        }
        finally
        {
            cmd.Dispose();
            con.Close();
            con.Dispose();
        }
    }

    #endregion

    #region 执行存储过程

    /// <summary>
    /// 执行存储过程，返回对应DataReader ( 注意：调用该方法后，一定要对SqlDataReader进行Close )
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数字典,null表示无参数</param>
    /// <returns>对应数据库DataReader</returns>
    public static SqlDataReader GetProcedureDataReader(string storedProcName, params SqlParameter[] parameters)
    {
        SqlCommand cmd = GetCommand(parameters);
        try
        {
            cmd.CommandText = storedProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd.ExecuteReader();
        }
        catch
        {
            throw;
        }
    }

    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数,null表示无参数</param>
    /// <param name="tableName">DataSet结果中的表名</param>
    /// <returns>DataSet</returns>
    public static DataSet GetProcedureDataSet(string storedProcName, params SqlParameter[] parameters)
    {
        SqlCommand cmd = GetCommand(parameters);
        try
        {
            cmd.CommandText = storedProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataAdapter da = GetDataAdapter();
            da.SelectCommand = cmd;
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds;
        }
        catch
        {
            throw;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    /// <summary>
    /// 执行存储过程
    /// </summary>
    /// <param name="storedProcName">存储过程名</param>
    /// <param name="parameters">存储过程参数,null表示无参数</param>
    /// <returns></returns>
    public static void ExecuteProcedure(string storedProcName, params SqlParameter[] parameters)
    {
        SqlCommand cmd = GetCommand(parameters);
        try
        {
            cmd.CommandText = storedProcName;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.ExecuteNonQuery();
        }
        catch
        {
            throw;
        }
        finally
        {
            cmd.Connection.Close();
            cmd.Connection.Dispose();
            cmd.Dispose();
        }
    }

    #endregion

    #region 公用方法

    /// <summary>
    /// 返回表中指定列最大项
    /// </summary>
    /// <param name="FieldName">指定的列</param>
    /// <param name="TableName">表名</param>
    /// <returns>无最大项返回NULL,字符串按Unicode码位排序</returns>
    public static string GetMaxID(string fieldName, string tableName)
    {
        string strsql = "select max(@fieldName) from @tableName ";
        SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@fieldName", fieldName), new SqlParameter("@tableName", tableName) };
        object obj = ExecuteScalar(strsql, parameters);
        return obj.Equals(null) ? null : obj.ToString();
    }

    /// <summary>
    /// 对查询结果的首行首列进行判断,空值及0返回false,否则返回true
    /// </summary>
    /// <param name="sql">查询语句</param>
    /// <param name="parameters">参数</param>
    /// <returns></returns>
    public static bool Exists(string sql, params SqlParameter[] parameters)
    {
        object obj = ExecuteScalar(sql, parameters);
        if ((Object.Equals(obj, null)) || (Object.Equals(obj, System.DBNull.Value)) || obj.ToString() == "0")
            return false;
        else
            return true;
    }

    /// <summary>
    /// 表是否存在
    /// </summary>
    /// <param name="TableName"></param>
    /// <returns></returns>
    public static bool TabExists(string tableName)
    {
        string sql = "select count(*) from sysobjects where id = object_id(N'[@TableName]') and OBJECTPROPERTY(id, N'IsUserTable') = 1";
        SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tableName", tableName) };
        return Exists(sql, parameters);
    }

    /// <summary>
    /// 指定表是否存在指定列
    /// </summary>
    /// <param name="tableName">表名称</param>
    /// <param name="columnName">列名称</param>
    /// <returns>是否存在</returns>
    public static bool ColumnExists(string tableName, string columnName)
    {
        string sql = "select count(*) from syscolumns where [id]=object_id(@tablename) and [name]=@columnName";
        SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@tableName", tableName), new SqlParameter("@columnName", columnName) };
        return Exists(sql, parameters);
    }
    #endregion
}
