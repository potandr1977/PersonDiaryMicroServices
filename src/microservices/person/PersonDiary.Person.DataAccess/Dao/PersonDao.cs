using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDiary.Infrastucture.Domain.Models.DataAccess;
using PersonDiary.Person.DataAccess.Dao.Queries;
using PersonDiary.Person.Domain.DataAccess;
using PersonDiary.Person.Domain.DataAccess.Executor;
using PersonDiary.Person.Domain.Models;

namespace PersonDiary.Person.DataAccess.Dao
{
    public class PersonDao : IPersonDao
    {
        private readonly IPersonDbExecutor dbExecutor;
        
        public PersonDao(IPersonDbExecutor dbExecutor)
        {
            this.dbExecutor = dbExecutor;
        }
        
        public Task<List<PersonModel>> GetAllAsync(int pageNo, int pageSize)
        {
            var query = new QueryObject(PersonDaoQueries.GetAll, new { pageNo, pageSize});
            
            return dbExecutor.QueryAsync<PersonModel>(query);
        }
        
        public Task<PersonModel> GetByIdAsync(int id)
        {
            var query = new QueryObject(PersonDaoQueries.GetById, new { Id = id });

            return dbExecutor.QueryFirstOrDefaultAsync<PersonModel>(query);
        }
        
        public Task<int> SaveOrUpdateAsync(PersonModel model)
        {
            var query = new QueryObject(PersonDaoQueries.SaveOrUpdate, model);

            return dbExecutor.QueryFirstOrDefaultAsync<int>(query);
        }
        
        public Task DeleteByIdAsync(int id)
        {
            var query = new QueryObject(
                PersonDaoQueries.DeleteById,
                new
                {
                    Id = id
                });

            return dbExecutor.ExecuteAsync(query);
        }

    }
}