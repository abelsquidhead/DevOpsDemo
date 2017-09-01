using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using MercuryHealth.Models;
using MercuryHealth.Web.Models;

namespace MercuryHealth.Web.Api
{
    public class ExerciseApiController : ApiController
    {
        private readonly ApplicationDbContext db = new ApplicationDbContext();

        public ExerciseApiController()
        {
        }

        // GET: api/ExerciseApi
        public async Task<IEnumerable<Exercise>> Get()
        {
            return await db.Exercises.ToListAsync();
        }

        // GET: api/ExerciseApi/5
        public async Task<Exercise> Get(Guid id)
        {
            return await db.Exercises.FindAsync(id);
        }

        // POST: api/ExerciseApi
        public async void Post([FromBody]Exercise value)
        {
            db.Exercises.Add(value);
            await db.SaveChangesAsync();
        }

        // PUT: api/ExerciseApi/5
        public async void Put(Guid id, [FromBody]Exercise value)
        {
            var item = await db.Exercises.FindAsync(id);

            if (null == item)
                return;

            item.Description = value.Description;
            item.Equipment = value.Equipment;
            item.ImageUrls = value.ImageUrls;
            item.VideoUrl = value.VideoUrl;
            item.Name = value.Name;
            item.MusclesInvolved = value.MusclesInvolved;            

            await db.SaveChangesAsync();
        }

        // DELETE: api/ExerciseApi/5
        public async void Delete(Guid id)
        {
            var item = db.Exercises.Find(id);
            if (null == item)
                return;

            db.Exercises.Remove(item);
            await db.SaveChangesAsync();
        }
    }
}
