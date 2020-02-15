using System.Collections.Generic;
using System.Threading.Tasks;
using PersonDiary.Person.Domain.Models;

namespace PersonDiary.Person.Domain.DataAccess
{
    public interface IPersonDao
    {
        Task<List<PersonModel>> GetAllAsync(int pageNo, int pageSize);
        
        Task<PersonModel> GetByIdAsync(int id);

        Task<int> SaveOrUpdateAsync(PersonModel model);

        Task DeleteByIdAsync(int id);
    }
}