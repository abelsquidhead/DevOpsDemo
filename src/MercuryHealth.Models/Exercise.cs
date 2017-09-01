#region Namespaces
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
#endregion

namespace MercuryHealth.Models
{

    public class Exercise
    {

        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }
        
        public Dictionary<int, string> ImageUrls { get; set; }

        public string VideoUrl { get; set; }

        public string MusclesInvolved { get; set; }

        public string Equipment { get; set; }

        public List<Exercise> RelatedExercises { get; set; }
        
    }

}
