using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSPDataFetchLayer.DbUtils;
using PSPDataFetchLayer.Models;

namespace LabelChecksDataLayer.Models
{
    public class LabelCheckUtils
    {
        public static readonly List<string> CheckTypes = new List<string> { CheckTypeNotNull, CheckTypeNotBlank, CheckTypeNumeric, CheckTypeLimit, CheckTypeDevPercLimit };

        public const string CheckTypeNotNull = "not_null";
        public const string CheckTypeNotBlank = "not_blank";
        public const string CheckTypeNumeric = "is_numeric";
        public const string CheckTypeLimit = "limit";
        public const string CheckTypeDevPercLimit = "perc_dev_limit";

        public static readonly DateTime DefaultCheckConsiderStartTime = DateTime.Parse("2018-01-01");
        public static readonly DateTime DefaultCheckConsiderEndTime = DateTime.Parse("2030-01-01");

        public static void ProcessLabelCheck(LabelChecksDbContext labelChecksDbContext, string connStr, LabelCheck labelCheck, DateTime fromTime, DateTime toTime)
        {
            List<LabelCheckResult> labelCheckResults = GetLabelCheckResults(connStr, labelCheck, fromTime, toTime);
            //iterate through each result, find if record already exists and update the database
            for (int resIter = 0; resIter < labelCheckResults.Count; resIter++)
            {
                LabelCheckResult targetRes = labelCheckResults[resIter];
                LabelCheckResult foundRes = labelChecksDbContext.LabelCheckResults.Where(res => res.LabelCheckId == targetRes.LabelCheckId &&
                                                                res.CheckProcessEndTime == targetRes.CheckProcessEndTime &&
                                                                res.CheckProcessStartTime == targetRes.CheckProcessStartTime).FirstOrDefault();
                if (foundRes == null)
                {
                    // the record doesnot exist, so insert into the db
                    labelChecksDbContext.LabelCheckResults.Add(targetRes);
                }
                else
                {
                    targetRes.Id = foundRes.Id;
                    labelChecksDbContext.LabelCheckResults.Update(targetRes);
                }
            }
            labelChecksDbContext.SaveChanges();
        }

        public static List<LabelCheckResult> GetLabelCheckResults(string connStr, LabelCheck labelCheck, DateTime fromTime, DateTime toTime)
        {
            // get measurement fetch helper
            PspDbHelper helper = new PspDbHelper() { ConnStr = connStr };

            // fetch the measurement values
            List<PspTimeValTuple> tuples = helper.GetPSPMeasVals(labelCheck.PspMeasurement, ConvertDateTimeToInt(fromTime), ConvertDateTimeToInt(toTime));

            // do the checking algorithm on each tuple to produce check results
            List<LabelCheckResult> labelCheckResults = new List<LabelCheckResult>();
            // initialize a checkresult for each date with remark, data not found for processing
            for (int dayIter = 0; dayIter < (toTime - fromTime).Days; dayIter++)
            {
                labelCheckResults.Add(new LabelCheckResult { IsSuccessful = false, CheckProcessStartTime = fromTime.AddDays(dayIter), CheckProcessEndTime = fromTime.AddDays(dayIter), LabelCheckId = labelCheck.Id, Remarks = "data not processed" });
            }

            // scan all the tuples to process the checks and replace with initial values
            for (int tupleIter = 0; tupleIter < tuples.Count; tupleIter++)
            {
                int targetResultInd;
                LabelCheckResult targetResult;
                PspTimeValTuple tuple = tuples[tupleIter];
                // find the tuple to be modified from the list of inititalized results
                targetResultInd = labelCheckResults.FindIndex(res =>
                                                    (res.CheckProcessStartTime == ConvertIntToDateTime(tuple.TimeInt) &&
                                                     res.CheckProcessStartTime == ConvertIntToDateTime(tuple.TimeInt)));
                if (targetResultInd == -1) { continue; }
                if (labelCheck.CheckType == CheckTypeNotNull)
                {
                    targetResult = labelCheckResults.ElementAt(targetResultInd);
                    if (tuple.Val == null)
                    {
                        targetResult.IsSuccessful = false;
                        targetResult.Remarks = "null value found";
                        labelCheckResults[targetResultInd] = targetResult;
                    }
                    else
                    {
                        targetResult.IsSuccessful = true;
                        targetResult.Remarks = "passed";
                        labelCheckResults[targetResultInd] = targetResult;
                    }
                }
                else if (labelCheck.CheckType == CheckTypeLimit)
                {
                    targetResult = labelCheckResults.ElementAt(targetResultInd);
                    if (tuple.Val >= labelCheck.Num1 && tuple.Val <= labelCheck.Num2)
                    {
                        targetResult.IsSuccessful = true;
                        targetResult.Remarks = "passed";
                        labelCheckResults[targetResultInd] = targetResult;
                    }
                    else if (tuple.Val == null)
                    {
                        targetResult.IsSuccessful = false;
                        targetResult.Remarks = "null value found";
                        labelCheckResults[targetResultInd] = targetResult;
                    }
                    else
                    {
                        targetResult.IsSuccessful = false;
                        targetResult.Remarks = "limits violated";
                        labelCheckResults[targetResultInd] = targetResult;
                    }
                }
            }
            return labelCheckResults;
        }

        public static int ConvertDateTimeToInt(DateTime dateTime)
        {
            //output integer should be like 20180531
            int res = dateTime.Year * 10000 + dateTime.Month * 100 + dateTime.Day;
            return res;
        }

        public static DateTime ConvertIntToDateTime(int timeInt)
        {
            //input integer should be like 20180531
            int yearInt = timeInt / 10000;
            int monthInt = (timeInt % 10000) / 100;
            int dayInt = timeInt % 100;
            DateTime res = new DateTime(yearInt, monthInt, dayInt);
            return res;
        }
    }
}
