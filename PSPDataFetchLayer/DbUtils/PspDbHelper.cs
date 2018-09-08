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
        public const string fromTimeParamName = "from_time";
        public const string toTimeParamName = "to_time";

        public string ConnStr { get; set; } = "";

        public TableRowsApiResultModel GetDbTableRows(string sqlStr, List<OracleParameter> parameters)
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

                if (parameters.Count>0)
                {
                    cmd.BindByName = true;
                    for (int paramIter = 0; paramIter < parameters.Count; paramIter++)
                    {
                        cmd.Parameters.Add(parameters[paramIter]);
                    }
                }

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
            string sql = "";
            List<OracleParameter> parameters = new List<OracleParameter>();

            if (String.IsNullOrWhiteSpace(pspMeasurement.PspTimeCol))
            {
                return new TableRowsApiResultModel();
            }

            if (!String.IsNullOrWhiteSpace(pspMeasurement.PspTable) && 
                !String.IsNullOrWhiteSpace(pspMeasurement.PspValCol) &&  
                !String.IsNullOrWhiteSpace(pspMeasurement.EntityCol) && 
                !String.IsNullOrWhiteSpace(pspMeasurement.EntityVal))
            {
                // get the label details from the sqlite context
                sql = $"select {pspMeasurement.PspTimeCol}, {pspMeasurement.PspValCol} from {pspMeasurement.PspTable} where {pspMeasurement.EntityCol}='{pspMeasurement.EntityVal}' AND ({pspMeasurement.PspTimeCol} BETWEEN {fromTime} AND {toTime}) ORDER BY {pspMeasurement.PspTimeCol} ASC";

            }

            if ((String.IsNullOrWhiteSpace(pspMeasurement.EntityCol) || String.IsNullOrWhiteSpace(pspMeasurement.EntityVal)) && !String.IsNullOrWhiteSpace(pspMeasurement.SqlStr))
            {
                // check if enitity info is not complete and sql string is available for execution                
                sql = pspMeasurement.SqlStr;
                if (!String.IsNullOrWhiteSpace(pspMeasurement.QueryParams) && !String.IsNullOrWhiteSpace(pspMeasurement.QueryParamVals))
                {
                    // add params if query params and query param vals strings are not null
                    List<string> queryParams = new List<string>();
                    List<string> queryParamVals = new List<string>();
                    queryParams = pspMeasurement.QueryParams.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
                    queryParamVals = pspMeasurement.QueryParamVals.Split(new string[] { "," }, StringSplitOptions.RemoveEmptyEntries).Select(p => p.Trim()).ToList();
                    for (int paramIter = 0; paramIter < queryParams.Count; paramIter++)
                    {
                        parameters.Add(new OracleParameter(queryParams[paramIter], queryParamVals[paramIter]));
                    }
                }
                // add function input params, the param names are taken by convention
                parameters.Add(new OracleParameter(fromTimeParamName, fromTime));
                parameters.Add(new OracleParameter(toTimeParamName, toTime));
            }

            return GetDbTableRows(sql, parameters);
        }

        public List<PspTimeValTuple> GetPSPMeasVals(PspMeasurement pspMeasurement, int fromTime, int toTime)
        {
            TableRowsApiResultModel fetchedData = GetLabelData(pspMeasurement, fromTime, toTime);
            List<List<object>> rows = fetchedData.TableRows;
            List<string> colNames = fetchedData.TableColNames;
            int timeInd = colNames.IndexOf(pspMeasurement.PspTimeCol);
            int valInd = colNames.IndexOf(pspMeasurement.PspValCol);
            List<PspTimeValTuple> results = new List<PspTimeValTuple>();
            if (timeInd == -1 || valInd == -1)
            {
                // desired result was not found
                return results;
            }
            for (int rowIter = 0; rowIter < rows.Count; rowIter++)
            {
                // todo check val types also
                int timeInt = Convert.ToInt32((decimal)rows.ElementAt(rowIter).ElementAt(timeInd));
                decimal? val = (decimal)rows.ElementAt(rowIter).ElementAt(valInd);
                results.Add(new PspTimeValTuple { TimeInt = timeInt, Val = val });
            }
            return results;
        }

        public PspTimeValTuple GetPSPMeasVal(PspMeasurement pspMeasurement, int fromTime)
        {
            TableRowsApiResultModel fetchedData = GetLabelData(pspMeasurement, fromTime, fromTime);
            List<List<object>> rows = fetchedData.TableRows;
            List<string> colNames = fetchedData.TableColNames;
            int timeInd = colNames.IndexOf(pspMeasurement.PspTimeCol);
            int valInd = colNames.IndexOf(pspMeasurement.PspValCol);
            if (timeInd == -1 || valInd == -1)
            {
                // desired result was not found
                return null;
            }
            if (rows.Count == 0)
            {
                // desired result was not found
                return null;
            }
            // todo check val types also
            int timeInt = Convert.ToInt32((decimal)rows.ElementAt(0).ElementAt(timeInd));
            decimal? val = (decimal)rows.ElementAt(0).ElementAt(valInd);
            PspTimeValTuple result = new PspTimeValTuple { TimeInt = timeInt, Val = val };
            return result;
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
