#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{

    /// <summary>
    /// Calculate RDEE using the Katch McArdle Formula
    /// </summary>
    public class RdeeCalculator
    {

        /// <summary>
        /// Calculate RDEE using the Katch McArdle Formula
        /// </summary>
        /// <param name="weightInKilograms"></param>
        /// <param name="bodyFatPercentage"></param>
        /// <returns></returns>
        public double CalculateRdee(int weightInKilograms, double bodyFatPercentage)
        {
            return 370 + (21.6 * weightInKilograms * (100 - bodyFatPercentage));
        }

    }

}
