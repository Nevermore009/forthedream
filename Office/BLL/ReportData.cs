using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace BLL
{
    public class ReportData
    {
        public DataTable GetDaily(string date)
        {
            string procedureName = "DailyReport";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@date",date) };
            return SqlHelper.GetProcedureDataSet(procedureName, parameters).Tables[0];
        }

        public DataTable GetMonthly(int year, int month)
        {
            string procedureName = "MonthlyReport";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@year", year), new SqlParameter("@month", month) };
            return SqlHelper.GetProcedureDataSet(procedureName, parameters).Tables[0];
        }

        public DataTable GetQuarterly(int year, int quarter)
        {
            string procedureName = "QuarterlyReport";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@year", year), new SqlParameter("@quarter", quarter) };
            return SqlHelper.GetProcedureDataSet(procedureName, parameters).Tables[0];
        }

        public DataTable GetAnnual(int year)
        {
            string procedureName = "AnnualReport";
            SqlParameter[] parameters = new SqlParameter[] { new SqlParameter("@year", year) };
            return SqlHelper.GetProcedureDataSet(procedureName, parameters).Tables[0];
        }
    }
}
