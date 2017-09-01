#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{
    
    public interface IBasalMetabolicRateCalculator
    {

        double CalculateBmr(Gender gender, int weightInKilograms, int heightInCentimeters, int ageInYears);

    }

}
