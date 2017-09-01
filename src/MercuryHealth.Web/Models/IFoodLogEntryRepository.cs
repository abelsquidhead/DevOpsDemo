#region Namespaces
using MercuryHealth.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
#endregion

namespace MercuryHealth.Web.Models
{

    public interface IFoodLogEntryRepository
    {

        FoodLogEntry Get(int? id);

        IQueryable<FoodLogEntry> GetAll();

        void Create(FoodLogEntry newFoodLogEntry);

        void Update(FoodLogEntry updatedFoodLogEntry);

        void Delete(int id);

    }

}