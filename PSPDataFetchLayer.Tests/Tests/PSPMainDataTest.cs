using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Oracle.ManagedDataAccess.Client; // ODP.NET, Managed Driver
using Xunit;
using PSPDataFetchLayer.Models;
using Microsoft.EntityFrameworkCore;
using System.Data.Common;
using PSPDataFetchLayer.DbUtils;
using LabelChecksDataLayer.Models;

namespace PSPDataFetchLayer.Tests.Tests
{
    public class PSPMainDataTest
    {
        public IConfiguration Configuration { get; set; }

        public PSPMainDataTest()
        {
            // https://patrickhuber.github.io/2017/07/26/avoid-secrets-in-dot-net-core-tests.html
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<PSPMainDataTest>();

            Configuration = builder.Build();
        }

        [Fact]
        public void PassingTest()
        {
            Assert.Equal(4, 4);
        }

        [Fact]
        public void GetConfigTest()
        {
            string connStr = Configuration["pspdbinfo:ConnectionString"];
            Assert.NotNull(connStr);
        }

        [Fact]
        public void PSPMainDBConnTest()
        {
            string connStr = Configuration["pspdbinfo:ConnectionString"];
            Assert.NotNull(connStr);
            // create and open the connection
            OracleConnection conn = new OracleConnection(connStr);
            bool isError = false;
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                isError = true;
            }
            finally
            {
                //close the connection
                conn.Close();

                // free the resources
                conn.Dispose();
            }
            if (isError)
            {
                Assert.True(false);
            }
            else
            {
                Assert.True(true);
            }
        }

        [Fact]
        public void PSPLabelsDBConnTest()
        {
            string connStr = Configuration["psplabelsdbinfo:ConnectionString"];

            Assert.NotNull(connStr);

            DbContextOptionsBuilder<PSPMeasDbContext> builder = new DbContextOptionsBuilder<PSPMeasDbContext>().UseSqlServer(connStr);

            PSPMeasDbContext measDbContext = new PSPMeasDbContext(builder.Options);
            DbConnection conn = measDbContext.Database.GetDbConnection();
            bool isError = false;
            try
            {
                conn.Open();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                isError = true;
            }
            finally
            {
                //close the connection
                conn.Close();

                // free the resources
                conn.Dispose();
            }
            if (isError)
            {
                Assert.True(false);
            }
            else
            {
                Assert.True(true);
            }

        }

        [Fact]
        public async void PSPMeasFetchTest()
        {
            string connStr = Configuration["psplabelsdbinfo:ConnectionString"];

            Assert.NotNull(connStr);

            DbContextOptionsBuilder<PSPMeasDbContext> builder = new DbContextOptionsBuilder<PSPMeasDbContext>().UseSqlServer(connStr);

            PSPMeasDbContext measDbContext = new PSPMeasDbContext(builder.Options);

            List<PspMeasurement> measurements = await measDbContext.PspDbMeasurements.ToListAsync();

            Assert.NotNull(measurements);
        }

        [Fact]
        public void PSPSQLMeasFetchTest()
        {
            string connStr = Configuration["pspdbinfo:ConnectionString"];
            Assert.NotNull(connStr);

            // get measurement fetch helper
            PspDbHelper helper = new PspDbHelper() { ConnStr = connStr };

            // fetch the measurement values
            DateTime fromTime = DateTime.Now.AddDays(-1);
            DateTime toTime = DateTime.Now.AddDays(-1);
            PspMeasurement meas = new PspMeasurement {
                PspTimeCol = "DATE_KEY",
                SqlStr = "select MAX(DATE_KEY) DATE_KEY, SUM(UI) UI from state_load_details where DATE_KEY  BETWEEN :from_time AND :to_time group by DATE_KEY ORDER BY DATE_KEY ASC",
                PspValCol= "UI"
            };
            List<PspTimeValTuple> tuples = helper.GetPSPMeasVals(meas, LabelCheckUtils.ConvertDateTimeToInt(fromTime), LabelCheckUtils.ConvertDateTimeToInt(toTime));

            Assert.False(tuples.Count == 0);
        }
    }
}