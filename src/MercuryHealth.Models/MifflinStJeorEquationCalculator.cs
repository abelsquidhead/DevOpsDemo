#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{

    public class MifflinStJeorEquationCalculator : IBasalMetabolicRateCalculator
    {

        public double CalculateBmr(Gender gender, int weightInKilograms, int heightInCentimeters, int ageInYears)
        {
            switch (gender)
            {
                case Gender.Male:
                    return 5 + (10 * weightInKilograms) + (6.25 * heightInCentimeters) - (5 * ageInYears);
                case Gender.Female:
                    return -161 + (10 * weightInKilograms) + (6.25 * heightInCentimeters) - (5 * ageInYears);
                default:
                    throw new ArgumentException("invalid gender provided. Valid values are 'male' or 'female'.", "gender");
            }
        }
        
    }

}
