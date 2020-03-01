using PersonDiary.Person.Domain.DataAccess;
using PersonDiary.Person.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PersonDiary.Person.DataAccess.Dao
{
    public class LifeEventDao : ILifeEventDao
    {
        public Task DeleteByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<List<LifeEventModel>> GetAllAsync(int pageNo, int pageSize)
        {
            throw new System.NotImplementedException();
        }

        public Task<LifeEventModel> GetByIdAsync(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<int> SaveOrUpdateAsync(LifeEventModel model)
        {
            throw new System.NotImplementedException();
        }
    }
}