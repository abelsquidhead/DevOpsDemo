#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{

    public class MyMetricsViewModel
    {
        
        public MemberProfile MemberProfile { get; set; }
        
        public BmrCalculatorOption BmrCalculatorOption { get; set; }
        
        public double Bmr
        {
            get
            {
                return CalculateBmr(BmrCalculatorOption, MemberProfile);
            }
        }
        
        public double CalculateBmr(BmrCalculatorOption calculatorOption, MemberProfile profile)
        {
            IBasalMetabolicRateCalculator bmrCalculator;
            if (BmrCalculatorOption == BmrCalculatorOption.HarrisBenedictPrinciple)
            {
                bmrCalculator = new HarrisBenedictPrincipleCalculator();
            }
            else
            {
                bmrCalculator = new MifflinStJeorEquationCalculator();
            }

            // calculate age
            var age = profile.CalculateAge();

            return bmrCalculator.CalculateBmr(
                profile.Gender,
                profile.WeightInKilograms,
                profile.HeightInCentimeters,
                age);
            
        }

    }

}
