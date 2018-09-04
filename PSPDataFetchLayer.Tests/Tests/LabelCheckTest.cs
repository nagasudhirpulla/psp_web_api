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
        public void PassingTest()
        {
            Assert.Equal(4, 4);
        }

        //todo create a test that does label checking on day before yest data
    }
}
