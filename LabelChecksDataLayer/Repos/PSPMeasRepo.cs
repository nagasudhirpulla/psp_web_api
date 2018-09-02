using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PSPDataFetchLayer.Models;
using Microsoft.EntityFrameworkCore;
using LabelChecksDataLayer.Models;

namespace LabelChecksDataLayer.Repos
{
    public class PSPMeasRepo : IRepo<PspMeasurement>
    {
        private readonly LabelChecksDbContext _dbContext;

        public PSPMeasRepo(LabelChecksDbContext dbContext)
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

        public async Task<PspMeasurement> FindByLabelAsync(string label)
        {
            return await _dbContext.PspDbMeasurements.FirstAsync(m => m.Label == label);
            throw new NotImplementedException();
        }
    }
}
