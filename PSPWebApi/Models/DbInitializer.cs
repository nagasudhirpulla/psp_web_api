using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSPWebApi.Models
{
    public class DbInitializer
    {
        public static PspDbMeasurement[] GetSeeds()
        {
            PspDbMeasurement[] objs = new PspDbMeasurement[] {
                new PspDbMeasurement {
                    Id = 1, Label = "gujarat_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "GUJARAT"
                },
                new PspDbMeasurement {
                    Id = 2, Label = "maharashtra_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "MAHARASHTRA"
                },
                new PspDbMeasurement {
                    Id = 3, Label = "madhya_pradesh_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "MADHYA PRADESH"
                },
                new PspDbMeasurement {
                    Id = 4, Label = "dd_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "DAMAN AND DIU"
                },
                new PspDbMeasurement {
                    Id = 5, Label = "dnh_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "DADRA AND NAGAR HAVELI"
                },
                new PspDbMeasurement {
                    Id = 6, Label = "esil_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "ESIL"
                },
                new PspDbMeasurement {
                    Id = 7, Label = "chhattisgarh_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "CHHATISGARH"
                },
                new PspDbMeasurement {
                    Id = 8, Label = "goa_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "GOA"
                }
            };
            return objs;
        }
    }
}
