using System;
using System.Collections.Generic;
using System.Data;
using Oracle.ManagedDataAccess.Client; // ODP.NET, Managed Driver 
using System.Linq;
using System.Threading.Tasks;
using PSPDataFetchLayer.Models;

namespace PSPDataFetchLayer.DbUtils
{
    public class PspDbHelper
    {
        public string ConnStr { get; set; } = "";

        public TableRowsApiResultModel GetDbTableRows(string sqlStr)
        {
            // initiate the result
            TableRowsApiResultModel rows = new TableRowsApiResultModel();

            // create and open the connection
            OracleConnection conn = new OracleConnection(ConnStr); // C#
            conn.Open();
            try
            {
                // create the command for querying
                OracleCommand cmd = new OracleCommand
                {
                    Connection = conn,
                    CommandText = sqlStr,
                    CommandType = CommandType.Text
                };

                // execute command and read into an oracle data reader object
                OracleDataReader dr = cmd.ExecuteReader();

                // populate the column names
                for (int i = 0; i < dr.FieldCount; i++)
                {
                    string colName = dr.GetName(i);
                    rows.TableColNames.Add(colName);
                    string colType = dr.GetFieldType(i).Name;
                    rows.TableColTypes.Add(colType);
                }

                // populate the rows of the query table
                while (dr.Read())
                {
                    object[] objs = new object[dr.FieldCount];
                    dr.GetValues(objs);
                    rows.TableRows.Add(new List<object>(objs));
                    //Console.WriteLine(dr.GetInt32(dr.GetOrdinal("ID")));
                    //Console.WriteLine(dr.GetString(dr.GetOrdinal("LINE_NAME")));
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            //close the connection
            conn.Close();

            // free the resources
            conn.Dispose();

            // return the result
            return rows;
        }

        public TableRowsApiResultModel GetLabelData(PspMeasurement pspMeasurement, int fromTime, int toTime)
        {
            // get the label details from the sqlite context
            string sql = $"select {pspMeasurement.PspTimeCol}, {pspMeasurement.PspValCol} from {pspMeasurement.PspTable} where {pspMeasurement.EntityCol}='{pspMeasurement.EntityVal}' AND ({pspMeasurement.PspTimeCol} BETWEEN {fromTime} AND {toTime}) ORDER BY {pspMeasurement.PspTimeCol} ASC";
            return GetDbTableRows(sql);

            //todo handle if sqlStr attribute of pspDbMeasurement is not null
        }
    }
}

/*
    Oracle dataReader methods documentation - https://docs.microsoft.com/en-us/dotnet/api/system.data.oracleclient.oracledatareader.getstring?view=netframework-1.1
    
    use the following to get the column type of a data row
    dr.GetFieldType(ordinal).Name 

    use the following to get all the column names of a data row 
    dr.GetFieldType(ordinal);

    use the following to retrieve the columns of a row into an object array
    object[] objs = new object[20];
    dr.GetValues(objs);

    use the following to get the ordinal index of a column
    int ordinal = dr.GetOrdinal("LINE_NAME")

    Use the following to get the field vaue by column name
    dr.GetInt32(dr.GetOrdinal("ID"))
    dr.GetString(dr.GetOrdinal("LINE_NAME"))

    parameterized queries with oracle connection
    https://www.codeproject.com/Tips/1076851/Oracle-Parameterized-Queries-for-the-NET-Developer

     */
