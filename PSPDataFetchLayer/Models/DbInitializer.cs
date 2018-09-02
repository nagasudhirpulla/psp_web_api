using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PSPDataFetchLayer.Models
{
    public class DbInitializer
    {
        public static PspMeasurement[] GetSeeds()
        {
            PspMeasurement[] objs = new PspMeasurement[] {
                new PspMeasurement {
                    MeasId = 1, Label = "gujarat_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "GUJARAT"
                },
                new PspMeasurement {
                    MeasId = 2, Label = "maharashtra_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "MAHARASHTRA"
                },
                new PspMeasurement {
                    MeasId = 3, Label = "madhya_pradesh_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "MADHYA PRADESH"
                },
                new PspMeasurement {
                    MeasId = 4, Label = "dd_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "DAMAN AND DIU"
                },
                new PspMeasurement {
                    MeasId = 5, Label = "dnh_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "DADRA AND NAGAR HAVELI"
                },
                new PspMeasurement {
                    MeasId = 6, Label = "esil_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "ESIL"
                },
                new PspMeasurement {
                    MeasId = 7, Label = "chhattisgarh_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "CHHATISGARH"
                },
                new PspMeasurement {
                    MeasId = 8, Label = "goa_thermal_mu",
                    PspTable = "STATE_LOAD_DETAILS", PspTimeCol = "DATE_KEY", PspValCol = "THERMAL",
                    EntityCol= "STATE_NAME",
                    EntityVal= "GOA"
                }
            };
            return objs;
        }
    }
}
