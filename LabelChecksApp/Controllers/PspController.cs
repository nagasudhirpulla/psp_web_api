using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LabelChecksDataLayer.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Configuration;
using PSPDataFetchLayer.DbUtils;
using PSPDataFetchLayer.Models;

namespace LabelChecksApp.Controllers
{
    [EnableCors("anyorigin")]
    [Route("api/[controller]")]
    [ApiController]
    public class PspController : ControllerBase
    {
        private readonly LabelChecksDbContext _context;
        private IConfiguration Configuration { get; }

        public PspController(LabelChecksDbContext context, IConfiguration configuration)
        {
            _context = context;
            Configuration = configuration;
        }

        // GET: api/Psp
        [HttpGet]
        public TableRowsApiResultModel Get([BindRequired, FromQuery] string label, [BindRequired, FromQuery] int from_time, [BindRequired, FromQuery] int to_time)
        {
            PspDbHelper helper = new PspDbHelper { ConnStr = Configuration["pspdbinfo:ConnectionString"] };
            //return helper.GetDbTableRows("select * from DIM_CONDUCTOR");
            try
            {
                PspMeasurement pspDbMeasurement = _context.PspDbMeasurements.Single(m => m.Label == label);
                return helper.GetLabelData(pspDbMeasurement, from_time, to_time);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return new TableRowsApiResultModel();
            }
        }

        // POST: api/Psp
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }
    }
}
