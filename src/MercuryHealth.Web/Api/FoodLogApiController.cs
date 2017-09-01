using System.Collections.Generic;
using System.Web.Http;
using MercuryHealth.Models;
using MercuryHealth.Web.Models;

namespace MercuryHealth.Web.Api
{
    public class FoodLogApiController : ApiController
    {
        private IFoodLogEntryRepository foodDb;

        public FoodLogApiController()
        {
            foodDb = new FoodLogEntrySqlRepository();
        }

        // GET: api/FoodLogApi
        public IEnumerable<FoodLogEntry> Get()
        {
            var items = foodDb.GetAll();

            return items;
        }

        // GET: api/FoodLogApi/5
        public FoodLogEntry Get(int id)
        {
            var item = foodDb.Get(id);

            return item;
        }

        // POST: api/FoodLogApi
        public void Post([FromBody]FoodLogEntry value)
        {            
            foodDb.Create(value);
        }

        // PUT: api/FoodLogApi/5
        public void Put(int id, [FromBody]FoodLogEntry value)
        {
            var item = foodDb.Get(id);
            if (null == item)
            {
                foodDb.Create(value);
            }

            foodDb.Update(value);
        }

        // DELETE: api/FoodLogApi/5
        public void Delete(int id)
        {
            var item = foodDb.Get(id);

            if (null == item)
            {
                return;
            }

            foodDb.Delete(id);            
        }
    }
}
