using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using PSPDataFetchLayer.Models;
using Microsoft.EntityFrameworkCore;

namespace PSPDataFetchLayer.Repos
{
    public class PSPMeasRepo : IRepo<PspMeasurement>
    {
        private readonly PSPMeasDbContext _dbContext;

        public PSPMeasRepo(PSPMeasDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IEnumerable<PspMeasurement> List
        {
            get
            {
                return _dbContext.PspDbMeasurements;
            }
        }

        public async Task<List<PspMeasurement>> ListAsync()
        {
            return await _dbContext.PspDbMeasurements.ToListAsync();
        }

        public void Add(PspMeasurement entity)
        {
            throw new NotImplementedException();
        }

        public void Delete(PspMeasurement entity)
        {
            throw new NotImplementedException();
        }

        public PspMeasurement FindById(int Id)
        {
            throw new NotImplementedException();
        }

        public void Update(PspMeasurement entity)
        {
            throw new NotImplementedException();
        }
    }
}
