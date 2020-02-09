using System.Threading.Tasks;
using Dapper;
using PersonDiary.Infrastucture.Domain.DataAccess;
using PersonDiary.Infrastucture.Domain.Models.DataAccess;
using PersonDiary.Person.DataAccess.Queries;
using PersonDiary.Person.Domain.DataAccess;
using PersonDiary.Person.Domain.Models;

namespace PersonDiary.Person.DataAccess
{
    public class PersonDao : IPersonDao
    {
        private readonly IDbExecutor dbExecutor;
        
        public PersonDao(IDbExecutor dbExecutor)
        {
            this.dbExecutor = dbExecutor;
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