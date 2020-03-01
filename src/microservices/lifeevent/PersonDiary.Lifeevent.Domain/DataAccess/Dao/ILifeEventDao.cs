using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDiary.Person.Domain.Models;

namespace PersonDiary.Person.Domain.DataAccess
{
    public interface ILifeEventDao
    {
        Task<List<LifeEventModel>> GetAllAsync(int pageNo, int pageSize);
        
        Task<LifeEventModel> GetByIdAsync(int id);

        Task<int> SaveOrUpdateAsync(LifeEventModel model);

        Task DeleteByIdAsync(int id);
    }
}