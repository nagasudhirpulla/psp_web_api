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
using LabelChecksDataLayer.Models;

namespace PSPDataFetchLayer.Tests.Tests
{
    public class LabelCheckTest
    {
        public IConfiguration Configuration { get; set; }

        public LabelCheckTest()
        {
            // https://patrickhuber.github.io/2017/07/26/avoid-secrets-in-dot-net-core-tests.html
            var builder = new ConfigurationBuilder()
                .AddUserSecrets<PSPMainDataTest>();

            Configuration = builder.Build();
        }

        [Fact]
        public void LabelProcessTest()
        {
            try
            {
                //test that does label checking on day before yest data
                string mainConnStr = Configuration["pspdbinfo:ConnectionString"];
                Assert.NotNull(mainConnStr);

                string connStr = Configuration["psplabelsdbinfo:ConnectionString"];
                Assert.NotNull(connStr);
                DbContextOptionsBuilder<LabelChecksDbContext> builder = new DbContextOptionsBuilder<LabelChecksDbContext>().UseSqlServer(connStr);
                LabelChecksDbContext labelChecksDbContext = new LabelChecksDbContext(builder.Options);

                // do processing
                DateTime fromTime = DateTime.Now.AddDays(-1);
                DateTime toTime = DateTime.Now.AddDays(-1);
                //LabelCheckUtils.ProcessAllLabelChecks(labelChecksDbContext, mainConnStr, fromTime, toTime);
            }
            catch (Exception e)
            {
                // fail the test
                Console.WriteLine(e.Message);
                Assert.Equal(4, 3);
            }
        }        
    }
}
