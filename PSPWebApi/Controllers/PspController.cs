using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using PSPWebApi.DbUtils;
using PSPWebApi.Models.PSP;

namespace PSPWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PspController : ControllerBase
    {
        public IConfiguration Configuration { get; set; }

        public PspController(IConfiguration config)
        {
            Configuration = config;
        }

        // GET: api/Psp
        [HttpGet]
        public TableRowsApiResultModel Get()
        {
            PspDbHelper helper = new PspDbHelper { ConnStr = Configuration["dbinfo:ConnectionString"] };
            return helper.GetDbTableRows();
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
