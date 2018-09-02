using PSPDataFetchLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LabelChecksDataLayer.Models
{
    public class DbInitializer
    {
        public static void SetLabelSeeds(LabelChecksDbContext labelChecksDbContext)
        {
            List<string> labels = new List<string>
            {
                "gujarat_thermal_mu", "maharashtra_thermal_mu"
            };

            int labelIdCounter = 0;
            for (int labelIter = 0; labelIter < labels.Count; labelIter++)
            {
                PspMeasurement meas = labelChecksDbContext.PspDbMeasurements.First(m => m.Label == labels.ElementAt(labelIter));
                if (meas == null)
                {
                    continue;
                }
                labelChecksDbContext.LabelChecks.Add(new LabelCheck
                {
                    Id = labelIdCounter++,
                    PspMeasurement = meas,
                    CheckType = LabelCheckUtils.CheckTypeNotNull
                });
            }
        }
    }
}
