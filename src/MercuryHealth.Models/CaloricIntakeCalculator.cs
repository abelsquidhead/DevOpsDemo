#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{

    public class CaloricIntakeCalculator
    {

        public double CalculateDailyCaloricIntake(double bmr, ExerciseLevel exerciseLevel)
        {
            double activityModifier = 0.0;

            switch (exerciseLevel)
            {
                case ExerciseLevel.Sedentary:
                    activityModifier = bmr * 0.2;
                    break;
                case ExerciseLevel.LightlyActive:
                    activityModifier = bmr * 0.375;
                    break;
                case ExerciseLevel.ModeratelyActive:
                    activityModifier = bmr * 0.55;
                    break;
                case ExerciseLevel.VeryActive:
                    activityModifier = bmr * 0.725;
                    break;
                case ExerciseLevel.ExtraActive:
                    activityModifier = bmr * 0.9;
                    break;
                default:
                    throw new ArgumentException("invalid exercise level provided.", "exerciseLevel");
            }

            return bmr + activityModifier;
        }

    }

}
