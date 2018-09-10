using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabelChecksDataLayer.Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LabelChecksDataLayer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddDbContext<LabelChecksDbContext>(options => options.UseSqlServer("Server=NAGASUDHIR\\SQLEXPRESS01;Database=labelsdb;Integrated Security=True;Trusted_Connection=True;MultipleActiveResultSets=true;"));
        }

        public void Configure(IApplicationBuilder app)
        {

        }
    }
}
