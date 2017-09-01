#region Namespaces
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{

    public class FoodLogEntry
    {

        public int Id { get; set; }

        public MemberProfile MemberProfile { get; set; }

        public string Description { get; set; }

        public float Quantity { get; set; }

        [DisplayName("Meal Time")]
        public DateTime MealTime { get; set; }

        public string Tags { get; set; }

        public int Calories { get; set; }

        [DisplayName("Protein/g")]
        public decimal ProteinInGrams { get; set; }

        [DisplayName("Fat/g")]
        public decimal FatInGrams { get; set; }

        [DisplayName("Carbohydrates/g")]
        public decimal CarbohydratesInGrams { get; set; }

        [DisplayName("Sodium/g")]
        public decimal SodiumInGrams { get; set; }

        //[DisplayName("Color")]
        //public string Color { get; set; }


    }

}
