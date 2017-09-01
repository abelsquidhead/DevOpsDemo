#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{

    public class HarrisBenedictPrincipleCalculator : IBasalMetabolicRateCalculator
    {

        public double CalculateBmr(Gender gender, int weightInKilograms, int heightInCentimeters, int ageInYears)
        {
            switch (gender)
            {
                case Gender.Male:
                    return 88.362 + (13.397 * weightInKilograms) + (4.799 * heightInCentimeters) - (5.677 * ageInYears);
                case Gender.Female:
                    return 447.593 + (9.247 * weightInKilograms) + (3.098 * heightInCentimeters) - (4.330 * ageInYears);
                default:
                    throw new ArgumentException("invalid gender provided. Valid values are 'male' or 'female'.", "gender");
            }
        }

    }

}
