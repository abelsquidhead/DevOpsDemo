using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MercuryHealthApp.Models
{
   public class Food
    {
        public int Id { get; set; }

        //public MemberProfile MemberProfile { get; set; }

        public string Description { get; set; }

        public float Quantity { get; set; }

        public DateTime MealTime { get; set; }

        public string Tags { get; set; }

        public int Calories { get; set; }

        public decimal ProteinInGrams { get; set; }

        public decimal FatInGrams { get; set; }

        public decimal CarbohydratesInGrams { get; set; }

        public decimal SodiumInGrams { get; set; }

        public string Color { get; set; }
    }
}
