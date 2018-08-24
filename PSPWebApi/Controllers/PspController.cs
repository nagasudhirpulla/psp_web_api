using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using PSPWebApi.DbUtils;
using PSPWebApi.Models;
using PSPWebApi.Models.PSP;

namespace PSPWebApi.Controllers
{
    [EnableCors("anyorigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PspController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }
        public AppDbContext _AppDbContext { get; set; }

        public PspController(IConfiguration config, AppDbContext ctx)
        {
            Configuration = config;
            _AppDbContext = ctx;
        }

        // GET: api/Psp
        [HttpGet]
        public TableRowsApiResultModel Get([BindRequired, FromQuery] string label, [BindRequired, FromQuery] int from_time, [BindRequired, FromQuery] int to_time)
        {
            PspDbHelper helper = new PspDbHelper { ConnStr = Configuration["dbinfo:ConnectionString"] };
            //return helper.GetDbTableRows("select * from DIM_CONDUCTOR");
            try
            {
                PspDbMeasurement pspDbMeasurement = _AppDbContext.PspDbMeasurements.Single(m => m.Label == label);
                return helper.GetLabelData(pspDbMeasurement, from_time, to_time);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new TableRowsApiResultModel();
            }
            
        }

        // GET: api/Psp/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Psp
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Psp/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
